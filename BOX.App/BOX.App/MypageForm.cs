using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client; // 학교 실습용 오라클 참조 추가

namespace BOX.App
{
    public partial class MypageForm : Form
    {
        // 테스트용 로그인 계정 고정 (나중에 로그인 폼과 연결 시 변경)
        private string currentUserId = "user01";

        public MypageForm() : this("user01")
        {
        }

        public MypageForm(string userId)
        {
            currentUserId = userId;
            InitializeComponent();
            LoadUserInfo(); // 폼 로드 시 정보 불러오기
        }

        // ==========================================
        // 1. 사용자 정보 불러오기
        // ==========================================
        private void LoadUserInfo()
        {
            try
            {
                string sql = "SELECT name, phone FROM Users WHERE user_id = :userId";
                OracleParameter[] parameters = new OracleParameter[] {
                    new OracleParameter("userId", currentUserId)
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    lblUserId.Text = currentUserId;
                    lblUserName.Text = dt.Rows[0]["name"].ToString();
                    lblUserPhone.Text = dt.Rows[0]["phone"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"정보를 불러오는 중 오류가 발생했습니다.\n{ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 2. 정보 수정 / 취소 / 저장 버튼 클릭 이벤트
        // ==========================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtEditName.Text = lblUserName.Text;
            txtEditPhone.Text = lblUserPhone.Text;

            lblUserName.Visible = false;
            lblUserPhone.Visible = false;
            btnEdit.Visible = false;

            txtEditName.Visible = true;
            txtEditPhone.Visible = true;
            btnCancel.Visible = true;
            btnSave.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEditName.Visible = false;
            txtEditPhone.Visible = false;
            btnCancel.Visible = false;
            btnSave.Visible = false;

            lblUserName.Visible = true;
            lblUserPhone.Visible = true;
            btnEdit.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newName = txtEditName.Text.Trim();
            string newPhone = txtEditPhone.Text.Trim();

            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newPhone))
            {
                MessageBox.Show("이름과 전화번호를 모두 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "UPDATE Users SET name = :newName, phone = :newPhone WHERE user_id = :userId";
                OracleParameter[] parameters = new OracleParameter[]
                {
                    new OracleParameter("newName", newName),
                    new OracleParameter("newPhone", newPhone),
                    new OracleParameter("userId", currentUserId)
                };

                int result = DBHelper.ExecuteNonQuery(sql, parameters);

                if (result > 0)
                {
                    MessageBox.Show("정보가 성공적으로 수정되었습니다.", "수정 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblUserName.Text = newName;
                    lblUserPhone.Text = newPhone;
                    btnCancel_Click(sender, e); // 읽기 모드로 되돌림
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DB 오류: {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 3. 로그아웃 및 탈퇴 링크 이벤트
        // ==========================================
        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserForm loginForm = new UserForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void lnkWithdraw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("회원 탈퇴는 관리자에게 문의해주세요.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==========================================
        // 4. 실수로 생성된 빈 이벤트 (절대 지우지 마세요)
        // ==========================================
        private void label2_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { } // 새로 추가된 부분 반영 완료

        private void MypageForm_Load(object sender, EventArgs e)
        {

        }
    }
}