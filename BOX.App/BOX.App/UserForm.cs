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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();

            // 폼 로드 시 비밀번호 텍스트박스 암호화 기호(*) 처리
            textBox2.PasswordChar = '*';
            this.ActiveControl = textBox1;
        }

        // '회원가입' 링크 클릭 이벤트
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 현재는 폼이 5개뿐이므로, 추후 회원가입 화면(패널 전환 등) 구현 시 여기에 작성
            MessageBox.Show("회원가입 기능은 준비 중입니다.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // 제목 라벨 클릭 (사용 안 함)
        }

        // '로그인' 버튼 클릭 이벤트
        private void button1_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // 1. 빈칸 검사
            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("사용자 ID를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("비밀번호를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // 2. DB 로그인 조회 로직
            try
            {
                // 아이디, 비밀번호가 일치하고 상태가 ACTIVE인 사용자의 이름을 가져옴
                string sql = "SELECT name FROM Users WHERE user_id = :userId AND password = :password AND status = 'ACTIVE'";

                OracleParameter[] parameters = new OracleParameter[]
                {
                    new OracleParameter("userId", userId),
                    new OracleParameter("password", password)
                };

                // DBHelper를 통해 단일 값(이름) 반환
                object result = DBHelper.ExecuteScalar(sql, parameters);

                // 3. 결과 처리
                if (result != null)
                {
                    string userName = result.ToString();
                    MessageBox.Show($"{userName}님 환영합니다!", "로그인 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 로그인 성공 시 지점 목록 폼(BranchForm)을 띄우고 현재 폼 숨김
                    BranchForm branchForm = new BranchForm(userId);
                    branchForm.FormClosed += (closedSender, closedEventArgs) => this.Close();
                    branchForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("아이디 또는 비밀번호가 일치하지 않거나, 사용할 수 없는 계정입니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Clear();
                    textBox2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"로그인 처리 중 DB 오류가 발생했습니다.\n{ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // 더블클릭으로 잘못 생성된 이벤트 (삭제하면 디자인 파일 오류 나니까 그대로 둠)
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // 비밀번호 텍스트박스 변경 이벤트 (필요 시 작성)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 사용자 ID 텍스트박스 변경 이벤트 (필요 시 작성)
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("시스템 관리자(admin)에게 문의하시거나, 가입 시 등록한 전화번호로 찾기 기능이 제공될 예정입니다.", "비밀번호 찾기", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}