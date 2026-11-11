using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace BOX.App
{

    public partial class BranchForm : Form
    {
        private readonly string currentUserId;
        private int selectedBranchId;
        private string selectedBranchName;

        public BranchForm() : this("user01")
        {
        }

       

        public BranchForm(string userId)
        {
            currentUserId = userId;
            InitializeComponent();
        }
        // ==========================================
        // 1. 폼 로드 시 실행 (처음엔 목록 비워두기)
        // ==========================================
        private void BranchForm_Load(object sender, EventArgs e)
        {
            dgvBranches.AllowUserToAddRows = false;
            dgvBranches.ReadOnly = true;
            dgvBranches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBranches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 콤보박스 기본값 설정 ("전체"가 첫 번째로 선택되게)
            if (comboSearch.Items.Count > 0) comboSearch.SelectedIndex = 0;

            dgvBranches.DataSource = null;
            ClearDetailLabels();
        }

        // ==========================================
        // 2. DB에서 지점 목록 불러오기 (검색어 + 콤보박스 지역 필터)
        // ==========================================
        private void LoadBranchData(string regionFilter, string keyword)
        {
            try
            {
                // 기본 SQL 쿼리
                string sql = @"
                    SELECT 
                        b.branch_id AS ""지점번호"",
                        b.branch_name AS ""지점명"", 
                        b.address AS ""주소"", 
                        b.contact AS ""연락처"",
                        NVL(l.total_cnt, 0) AS ""전체"",
                        NVL(l.empty_cnt, 0) AS ""잔여""
                    FROM Branches b
                    LEFT JOIN (
                        SELECT branch_id, 
                               COUNT(*) AS total_cnt,
                               SUM(CASE WHEN status = 'EMPTY' THEN 1 ELSE 0 END) AS empty_cnt
                        FROM Lockers
                        GROUP BY branch_id
                    ) l ON b.branch_id = l.branch_id
                    WHERE b.branch_name LIKE '%' || :keyword || '%'";

                // 만약 콤보박스에서 "전체"가 아니라 특정 지역(예: 경기도)을 골랐다면 주소 조건 추가
                if (regionFilter != "전체" && !string.IsNullOrEmpty(regionFilter))
                {
                    sql += " AND b.address LIKE '%' || :region || '%'";
                }

                sql += " ORDER BY b.branch_name";

                // 파라미터 세팅
                OracleParameter[] parameters;
                if (regionFilter != "전체" && !string.IsNullOrEmpty(regionFilter))
                {
                    parameters = new OracleParameter[] {
                        new OracleParameter("keyword", keyword),
                        new OracleParameter("region", regionFilter)
                    };
                }
                else
                {
                    parameters = new OracleParameter[] {
                        new OracleParameter("keyword", keyword)
                    };
                }

                DataTable dt = DBHelper.ExecuteQuery(sql, parameters);
                dgvBranches.DataSource = dt;

                if (dgvBranches.Columns.Contains("지점번호")) dgvBranches.Columns["지점번호"].Visible = false;
                if (dgvBranches.Columns.Contains("연락처")) dgvBranches.Columns["연락처"].Visible = false;

                AdjustDataGridViewHeight();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"목록을 불러오는 중 오류가 발생했습니다.\n{ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 3. 버튼 및 검색 이벤트
        // ==========================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string region = comboSearch.SelectedItem != null ? comboSearch.SelectedItem.ToString() : "전체";
            string keyword = txtSearch.Text.Trim();

            // 콤보박스가 "전체"이고 검색어도 없다면 전체 조회 또는 안내
            LoadBranchData(region, keyword);
            ClearDetailLabels();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            if (comboSearch.Items.Count > 0) comboSearch.SelectedIndex = 0;
            dgvBranches.DataSource = null;
            ClearDetailLabels();
        }

        // ==========================================
        // 4. 표(DataGridView) 클릭 시 하단 라벨에 대입
        // ==========================================
        private void dgvBranches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBranches.Rows[e.RowIndex];

            selectedBranchId = Convert.ToInt32(row.Cells["지점번호"].Value);
            selectedBranchName = Convert.ToString(row.Cells["지점명"].Value);

            lblSelectedName.Text = selectedBranchName;
            lblSelectedAddress.Text = "주소: " + row.Cells["주소"].Value.ToString();
            lblSelectedPhone.Text = "연락처: " + row.Cells["연락처"].Value.ToString();

            int total = Convert.ToInt32(row.Cells["전체"].Value);
            int available = Convert.ToInt32(row.Cells["잔여"].Value);
            int inUse = total - available;

            lblTotal.Text = total.ToString();
            lblAvailable.Text = available.ToString();
            lblInUse.Text = inUse.ToString();
        }

        // ==========================================
        // 5. 그리드뷰 높이 자동 조절 함수
        // ==========================================
        private void AdjustDataGridViewHeight()
        {
            int totalHeight = dgvBranches.ColumnHeadersHeight;

            foreach (DataGridViewRow row in dgvBranches.Rows)
            {
                totalHeight += row.Height;
            }
            totalHeight += 5;

            int maxHeight = 250;

            if (totalHeight > maxHeight)
            {
                dgvBranches.Height = maxHeight;
                dgvBranches.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                dgvBranches.Height = Math.Max(totalHeight, 50);
                dgvBranches.ScrollBars = ScrollBars.None;
            }
        }

        private void ClearDetailLabels()
        {
            selectedBranchId = 0;
            selectedBranchName = null;
            lblSelectedName.Text = "선택된 지점 없음";
            lblSelectedAddress.Text = "주소: ";
            lblSelectedPhone.Text = "연락처: ";
            lblTotal.Text = "0";
            lblAvailable.Text = "0";
            lblInUse.Text = "0";
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 콤보박스에 선택된 값이 없으면 무시
            if (comboSearch.SelectedItem == null) return;

            string region = comboSearch.SelectedItem.ToString();
            string keyword = txtSearch.Text.Trim(); // 텍스트박스에 적힌 검색어 (없으면 빈 문자열)

            // 콤보박스를 바꾸는 순간 바로 데이터 조회!
            LoadBranchData(region, keyword);
            ClearDetailLabels();
        }

        private void btnParcelRequest_Click(object sender, EventArgs e)
        {
            if (selectedBranchId == 0 || string.IsNullOrWhiteSpace(selectedBranchName))
            {
                MessageBox.Show("먼저 신청할 지점을 목록에서 선택해주세요.", "지점 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (ParcelForm parcelForm = new ParcelForm(currentUserId, selectedBranchId, selectedBranchName))
            {
                Hide();
                parcelForm.ShowDialog(this);
                Show();
            }
        }
    }
}