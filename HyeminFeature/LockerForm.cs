using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace BOX.App
{
    /// <summary>
    /// 지점별 보관함 조회 및 보관함 선택 화면.
    /// 프로젝트에 기존 DBHelper.cs가 포함되어 있어야 합니다.
    /// </summary>
    public class LockerForm : Form
    {
        private readonly ComboBox branchComboBox = new ComboBox();
        private readonly DataGridView lockerGrid = new DataGridView();
        private readonly Button refreshButton = new Button();
        private readonly Button selectButton = new Button();
        private readonly Label branchLabel = new Label();

        public int SelectedLockerId { get; private set; }
        public string SelectedLockerSize { get; private set; }
        public string SelectedLockerLocation { get; private set; }

        public LockerForm()
        {
            InitializeForm();
            Load += LockerForm_Load;
        }

        private void InitializeForm()
        {
            Text = "지점 및 보관함 선택";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(820, 520);

            branchLabel.Text = "지점 선택";
            branchLabel.AutoSize = true;
            branchLabel.Location = new Point(20, 20);

            branchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            branchComboBox.Location = new Point(90, 16);
            branchComboBox.Width = 300;
            branchComboBox.SelectedIndexChanged += BranchComboBox_SelectedIndexChanged;

            refreshButton.Text = "새로고침";
            refreshButton.Location = new Point(410, 15);
            refreshButton.Width = 90;
            refreshButton.Click += RefreshButton_Click;

            lockerGrid.Location = new Point(20, 60);
            lockerGrid.Size = new Size(760, 350);
            lockerGrid.ReadOnly = true;
            lockerGrid.AllowUserToAddRows = false;
            lockerGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            lockerGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            selectButton.Text = "선택한 보관함으로 신청하기";
            selectButton.Location = new Point(560, 430);
            selectButton.Width = 220;
            selectButton.Click += SelectButton_Click;

            Controls.Add(branchLabel);
            Controls.Add(branchComboBox);
            Controls.Add(refreshButton);
            Controls.Add(lockerGrid);
            Controls.Add(selectButton);
        }

        private void LockerForm_Load(object sender, EventArgs e)
        {
            LoadBranches();
        }

        private void LoadBranches()
        {
            try
            {
                DataTable branches = DBHelper.ExecuteQuery(
                    "SELECT branch_id, branch_name, address FROM Branches ORDER BY branch_id");

                branchComboBox.DisplayMember = "branch_name";
                branchComboBox.ValueMember = "branch_id";
                branchComboBox.DataSource = branches;
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private void BranchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLockers();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadLockers();
        }

        private void LoadLockers()
        {
            if (branchComboBox.SelectedValue == null || !(branchComboBox.SelectedValue is int))
            {
                return;
            }

            try
            {
                DataTable lockers = DBHelper.ExecuteQuery(
                    "SELECT locker_id, locker_size, location_desc, status " +
                    "FROM Lockers WHERE branch_id = :branch_id ORDER BY locker_id",
                    new[]
                    {
                        new OracleParameter("branch_id", OracleDbType.Int32)
                        {
                            Value = Convert.ToInt32(branchComboBox.SelectedValue)
                        }
                    });

                lockerGrid.DataSource = lockers;
                if (lockerGrid.Columns.Contains("locker_id"))
                    lockerGrid.Columns["locker_id"].HeaderText = "보관함 번호";
                if (lockerGrid.Columns.Contains("locker_size"))
                    lockerGrid.Columns["locker_size"].HeaderText = "크기";
                if (lockerGrid.Columns.Contains("location_desc"))
                    lockerGrid.Columns["location_desc"].HeaderText = "상세 위치";
                if (lockerGrid.Columns.Contains("status"))
                    lockerGrid.Columns["status"].HeaderText = "상태";
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (lockerGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("보관함을 선택해주세요.");
                return;
            }

            DataGridViewRow row = lockerGrid.SelectedRows[0];
            string status = Convert.ToString(row.Cells["status"].Value);
            if (!string.Equals(status, "EMPTY", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("사용 가능한 빈 보관함만 선택할 수 있습니다.");
                return;
            }

            SelectedLockerId = Convert.ToInt32(row.Cells["locker_id"].Value);
            SelectedLockerSize = Convert.ToString(row.Cells["locker_size"].Value);
            SelectedLockerLocation = Convert.ToString(row.Cells["location_desc"].Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowDatabaseError(Exception ex)
        {
            MessageBox.Show("데이터베이스를 불러오지 못했습니다.\n" + ex.Message,
                "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
