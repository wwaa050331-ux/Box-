using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace BOX.App
{
    public partial class ManagerLoginForm : Form
    {
        public bool IsLoginSuccessful = false;
        // ★ 추가된 부분: 로그인 성공 여부를 알려주는 스위치
     

        public ManagerLoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            this.ActiveControl = txtUserId;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtUserId.Text.Trim(); // (또는 textBox1)
            string pw = txtPassword.Text.Trim(); // (또는 textBox2)

            // ... (아이디 비번 검사 생략) ...

            // DB 확인 코드
            string sql = $"SELECT name FROM Users WHERE user_id = '{id}' AND password = '{pw}' AND role = 'ADMIN'";
            DataTable dt = DBHelper.ExecuteQuery(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                // ★ 2. 가장 중요! 로그인 성공했으니 스위치를 켭니다.
                IsLoginSuccessful = true;

                MessageBox.Show("관리자 로그인 성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 매니저폼 띄우고
                ManagerForm managerForm = new ManagerForm();
                managerForm.Show();

                // 로그인 창 닫기
                this.Close();
            }
            else
            {
                MessageBox.Show("로그인 실패", "에러");
            }
        }
    }
}