using System;
using System.Windows.Forms;

namespace BOX.App
{
    public partial class Form1 : Form
    {
        private readonly string currentUserId;

        public Form1(string userId)
        {
            InitializeComponent();
            currentUserId = userId;
            this.IsMdiContainer = true; // 코드에서도 MDI 컨테이너 확실히 켜기
            this.Text = $"무인 택배함 ({currentUserId}님)";

            // 처음 열릴 때 기본으로 지점 선택 창 띄우기
            OpenMdiChild(new BranchForm(currentUserId));
        }

        public Form1() : this("user01")
        {
        }

        // 핵심: Form1 안에 창 형태로 띄우는 함수 (중복 실행 방지)
        private void OpenMdiChild(Form childForm)
        {
            // 이미 같은 종류의 창이 열려 있으면 그 창을 앞으로 가져옴
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm.GetType() == childForm.GetType())
                {
                    openForm.BringToFront();
                    openForm.Activate();
                    childForm.Dispose();
                    return;
                }
            }

            childForm.MdiParent = this; // Form1 안에 가두기
            childForm.Show();
        }

        // 1. 마이페이지
        private void 마이페이지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new MypageForm()); // userId 필요 시 new MypageForm(currentUserId)
        }

        // 2-1. 택배 -> 지점 선택
        private void 택배지점선택ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new BranchForm(currentUserId));
        }

        // 2-2. 택배 -> 보관 신청
        private void 보관신청ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new ParcelForm(currentUserId));
        }

        // 3. 택배 수령 및 확인
        private void 택배수령및확인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new SystemLogForm(currentUserId));
        }
    }
}