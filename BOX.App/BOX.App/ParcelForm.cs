using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace BOX.App
{
    /// <summary>
    /// 택배 보관 신청, 인증번호 발급·복사, 택배기사 투입 완료 처리 화면.
    /// 로그인한 사용자의 userId를 생성자에서 전달받아 사용합니다.
    /// </summary>
    public class ParcelForm : Form
    {
        private readonly string userId;
        private int selectedLockerId;
        private string selectedLockerLocation;
        private string authCode;
        private int parcelId;

        private readonly TextBox userIdTextBox = new TextBox();
        private readonly TextBox lockerTextBox = new TextBox();
        private readonly TextBox locationTextBox = new TextBox();
        private readonly TextBox authCodeTextBox = new TextBox();
        private readonly Label statusLabel = new Label();
        private readonly Button selectLockerButton = new Button();
        private readonly Button requestButton = new Button();
        private readonly Button copyButton = new Button();
        private readonly Button depositButton = new Button();

        public ParcelForm(string userId)
        {
            this.userId = userId;
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "택배 보관 신청";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(620, 420);

            AddLabel("사용자 ID", 30, 30);
            userIdTextBox.Location = new Point(160, 26);
            userIdTextBox.Width = 250;
            userIdTextBox.ReadOnly = true;
            userIdTextBox.Text = userId;

            AddLabel("보관함", 30, 75);
            lockerTextBox.Location = new Point(160, 71);
            lockerTextBox.Width = 150;
            lockerTextBox.ReadOnly = true;
            selectLockerButton.Text = "보관함 선택";
            selectLockerButton.Location = new Point(330, 70);
            selectLockerButton.Width = 120;
            selectLockerButton.Click += SelectLockerButton_Click;

            AddLabel("상세 위치", 30, 120);
            locationTextBox.Location = new Point(160, 116);
            locationTextBox.Width = 290;
            locationTextBox.ReadOnly = true;

            AddLabel("인증번호", 30, 165);
            authCodeTextBox.Location = new Point(160, 161);
            authCodeTextBox.Width = 150;
            authCodeTextBox.ReadOnly = true;
            copyButton.Text = "인증번호 복사";
            copyButton.Location = new Point(330, 160);
            copyButton.Width = 120;
            copyButton.Click += CopyButton_Click;

            requestButton.Text = "보관 신청 및 인증번호 발급";
            requestButton.Location = new Point(160, 215);
            requestButton.Width = 290;
            requestButton.Height = 35;
            requestButton.Click += RequestButton_Click;

            depositButton.Text = "택배기사 투입 완료 처리";
            depositButton.Location = new Point(160, 265);
            depositButton.Width = 290;
            depositButton.Height = 35;
            depositButton.Click += DepositButton_Click;

            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(160, 325);
            statusLabel.Text = "상태: 보관함과 택배 정보를 입력하세요.";

            Controls.Add(userIdTextBox);
            Controls.Add(lockerTextBox);
            Controls.Add(locationTextBox);
            Controls.Add(authCodeTextBox);
            Controls.Add(selectLockerButton);
            Controls.Add(requestButton);
            Controls.Add(copyButton);
            Controls.Add(depositButton);
            Controls.Add(statusLabel);
        }

        private void AddLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            label.Location = new Point(x, y + 4);
            Controls.Add(label);
        }

        private void SelectLockerButton_Click(object sender, EventArgs e)
        {
            using (LockerForm form = new LockerForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    selectedLockerId = form.SelectedLockerId;
                    selectedLockerLocation = form.SelectedLockerLocation;
                    lockerTextBox.Text = selectedLockerId.ToString();
                    locationTextBox.Text = selectedLockerLocation;
                    statusLabel.Text = "상태: 보관함이 선택되었습니다.";
                }
            }
        }

        private void RequestButton_Click(object sender, EventArgs e)
        {
            if (selectedLockerId == 0)
            {
                MessageBox.Show("먼저 빈 보관함을 선택해주세요.");
                return;
            }

            try
            {
                authCode = GenerateAuthCode();
                object nextId = DBHelper.ExecuteScalar("SELECT seq_parcel_id.NEXTVAL FROM DUAL");
                parcelId = Convert.ToInt32(nextId);

                string sql =
                    "INSERT INTO Parcels " +
                    "(parcel_id, user_id, locker_id, auth_code, stored_at, expired_at, status) " +
                    "VALUES (:parcel_id, :user_id, :locker_id, :auth_code, SYSDATE, SYSDATE + 3, 'RESERVED')";

                DBHelper.ExecuteNonQuery(sql, new[]
                {
                    new OracleParameter("parcel_id", OracleDbType.Int32) { Value = parcelId },
                    new OracleParameter("user_id", OracleDbType.Varchar2) { Value = userId },
                    new OracleParameter("locker_id", OracleDbType.Int32) { Value = selectedLockerId },
                    new OracleParameter("auth_code", OracleDbType.Varchar2) { Value = authCode }
                });

                DBHelper.ExecuteNonQuery(
                    "UPDATE Lockers SET status = 'RESERVED' WHERE locker_id = :locker_id AND status = 'EMPTY'",
                    new[]
                    {
                        new OracleParameter("locker_id", OracleDbType.Int32) { Value = selectedLockerId }
                    });

                authCodeTextBox.Text = authCode;
                statusLabel.Text = "상태: 보관 신청이 완료되었습니다. 택배기사에게 인증번호를 전달하세요.";
                MessageBox.Show("보관 신청과 인증번호 발급이 완료되었습니다.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(authCodeTextBox.Text))
            {
                MessageBox.Show("먼저 보관 신청을 완료해주세요.");
                return;
            }

            Clipboard.SetText(authCodeTextBox.Text);
            MessageBox.Show("인증번호가 복사되었습니다.");
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            if (parcelId == 0)
            {
                MessageBox.Show("먼저 보관 신청을 완료해주세요.");
                return;
            }

            try
            {
                int parcelRows = DBHelper.ExecuteNonQuery(
                    "UPDATE Parcels SET status = 'STORED', stored_at = SYSDATE " +
                    "WHERE parcel_id = :parcel_id AND auth_code = :auth_code AND status = 'RESERVED'",
                    new[]
                    {
                        new OracleParameter("parcel_id", OracleDbType.Int32) { Value = parcelId },
                        new OracleParameter("auth_code", OracleDbType.Varchar2) { Value = authCode }
                    });

                if (parcelRows == 0)
                {
                    MessageBox.Show("투입 처리할 보관 신청을 찾지 못했습니다.");
                    return;
                }

                DBHelper.ExecuteNonQuery(
                    "UPDATE Lockers SET status = 'OCCUPIED' WHERE locker_id = :locker_id",
                    new[]
                    {
                        new OracleParameter("locker_id", OracleDbType.Int32) { Value = selectedLockerId }
                    });

                statusLabel.Text = "상태: 택배 투입 완료. 현재 보관 중입니다.";
                MessageBox.Show("택배 투입 처리가 완료되었습니다.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private string GenerateAuthCode()
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[4];
                rng.GetBytes(bytes);
                uint value = BitConverter.ToUInt32(bytes, 0) % 1000000;
                return value.ToString("D6");
            }
        }

        private void ShowDatabaseError(Exception ex)
        {
            MessageBox.Show("데이터베이스 작업에 실패했습니다.\n" + ex.Message,
                "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ParcelForm
            // 
            this.ClientSize = new System.Drawing.Size(274, 229);
            this.Name = "ParcelForm";
            this.Load += new System.EventHandler(this.ParcelForm_Load);
            this.ResumeLayout(false);

        }

        private void ParcelForm_Load(object sender, EventArgs e)
        {

        }
    }
}
