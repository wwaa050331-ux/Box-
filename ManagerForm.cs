using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace BOX.App
{
    public partial class ManagerForm : Form
    {
        DBClass dbc = new DBClass();

        private Timer liveTimer = new Timer();
        private bool isLiveMode = false;
        private string currentLocker = "101호";
        private string currentBranch = "전체 지점";
        private string currentStatus = "NORMAL";
        private string currentDesc = "";

        public ManagerForm()
        {
            
            InitializeComponent();

            // 창을 X 버튼으로 닫아도 숨겨진 UserForm까지 완전히 종료
            this.FormClosed += (s, e) => Application.Exit();

            // ★ 1. 표의 아무 칸이나 눌러도 한 줄 전체가 선택되도록 설정 + 이벤트 강제 연결
            lvSystemLogs.FullRowSelect = true;
            lvSystemLogs.SelectedIndexChanged -= lvSystemLogs_SelectedIndexChanged;
            lvSystemLogs.SelectedIndexChanged += lvSystemLogs_SelectedIndexChanged;

            // ★ 2. 날짜칸을 클릭하면 실시간 타이머를 멈춰서 날짜를 자유롭게 바꿀 수 있게 함
            dtpCctvTime.Enter += (s, e) => { liveTimer.Stop(); isLiveMode = false; };
            dtpCctvTime.MouseDown += (s, e) => { liveTimer.Stop(); isLiveMode = false; };

            // [시점 이동] 버튼 이벤트 연결
            btnTimeMove.Click -= btnTimeMove_Click;
            btnTimeMove.Click += btnTimeMove_Click;

            

            // [시점 이동] 버튼 이벤트가 디자인에서 끊어져 있어도 무조건 작동하도록 연결
            btnTimeMove.Click -= btnTimeMove_Click;
            btnTimeMove.Click += btnTimeMove_Click;

            dbc.DB_ObjCreate();
            dbc.DB_Open();

            dtpCctvTime.Format = DateTimePickerFormat.Custom;
            dtpCctvTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpCctvTime.ShowUpDown = true;

            dtpCctvTime.ValueChanged += dtpCctvTime_ValueChanged;

            liveTimer.Interval = 1000;
            liveTimer.Tick += LiveTimer_Tick;
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            LoadBranches();

            if (cmbLogType.Items.Count > 0)
                cmbLogType.SelectedIndex = 0;

            LoadLogs("전체", "전체");
            StartLiveMode();
        }

        // ==========================================================
        // DB에서 지점(Branches) 목록 가져오기
        // ==========================================================
        private void LoadBranches()
        {
            cmbBranch.Items.Clear();
            cmbBranch.Items.Add("전체");

            try
            {
                DataTable dt = DBHelper.ExecuteQuery("SELECT branch_name FROM Branches ORDER BY branch_id");
                foreach (DataRow row in dt.Rows)
                {
                    cmbBranch.Items.Add(row["branch_name"].ToString());
                }
            }
            catch
            {
                cmbBranch.Items.Add("부천대 본관점");
                cmbBranch.Items.Add("한길체육관점");
            }

            if (cmbBranch.Items.Count > 0)
                cmbBranch.SelectedIndex = 0;
        }

        // ==========================================================
        // 1. ListView 로그 조회 (3개 테이블 JOIN)
        // ==========================================================
        private void LoadLogs(string logType, string branchName)
        {
            lvSystemLogs.Items.Clear();

            string sql = @"
                SELECT s.log_id,
                       TO_CHAR(s.created_at, 'YYYY-MM-DD HH24:MI:SS') AS created_str,
                       NVL(s.user_id, '-') AS user_str,
                       NVL(TO_CHAR(s.locker_id), '-') AS locker_str,
                       s.type,
                       s.description,
                       NVL(b.branch_name, '시스템') AS branch_name
                FROM SystemLogs s
                LEFT JOIN Lockers l ON s.locker_id = l.locker_id
                LEFT JOIN Branches b ON l.branch_id = b.branch_id
                WHERE 1=1";

            if (logType != "전체" && !string.IsNullOrEmpty(logType))
                sql += $" AND s.type = '{logType}'";

            if (branchName != "전체" && !string.IsNullOrEmpty(branchName))
                sql += $" AND b.branch_name = '{branchName}'";

            sql += " ORDER BY s.log_id DESC";

            DataTable dt = DBHelper.ExecuteQuery(sql);

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["log_id"].ToString());
                item.SubItems.Add(row["created_str"].ToString());
                item.SubItems.Add(row["user_str"].ToString());

                string l_str = row["locker_str"].ToString();
                if (l_str == "-")
                    item.SubItems.Add("-");
                else
                    item.SubItems.Add($"[{row["branch_name"]}] {l_str}호");

                string typeStr = row["type"].ToString();
                item.SubItems.Add(typeStr);
                item.SubItems.Add(row["description"].ToString());

                // 오류 로그는 리스트에서도 빨간 글씨로 강조
                if (typeStr == "ERROR")
                {
                    item.ForeColor = Color.Red;
                }

                lvSystemLogs.Items.Add(item);
            }
        }

        // ==========================================================
        // 2. ListView 행 클릭 시 -> 해당 지점 및 과거 시점(REPLAY) CCTV
        // ==========================================================
        private void lvSystemLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSystemLogs.SelectedItems.Count == 0) return;

            liveTimer.Stop();
            isLiveMode = false;

            ListViewItem item = lvSystemLogs.SelectedItems[0];
            dbc.SelectedLogId = Convert.ToInt32(item.SubItems[0].Text);

            string timeStr = item.SubItems[1].Text;
            string fullLockerStr = item.SubItems[3].Text;
            currentStatus = item.SubItems[4].Text;
            currentDesc = item.SubItems[5].Text;

            if (fullLockerStr.Contains("]"))
            {
                int endIdx = fullLockerStr.IndexOf("]");
                currentBranch = fullLockerStr.Substring(1, endIdx - 1);
                currentLocker = fullLockerStr.Substring(endIdx + 1).Trim();
            }
            else
            {
                currentBranch = "시스템";
                currentLocker = "-";
            }

            if (DateTime.TryParse(timeStr, out DateTime parsedTime))
            {
                dtpCctvTime.Value = parsedTime;
            }

            UpdateCctvLabels();
            DrawCctvScreen(currentLocker, currentStatus, dtpCctvTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), false, currentDesc);
        }

        // ==========================================================
        // 3. [시점 이동] 버튼 클릭 시 -> 선택한 시간의 DB 로그 조회 후 CCTV 표시
        // ==========================================================
        private void btnTimeMove_Click(object sender, EventArgs e)
        {
            liveTimer.Stop();
            isLiveMode = false;

            string selectedTime = dtpCctvTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                // 선택한 시간 기준 ±30분 이내의 가장 가까운 로그 조회
                string sql = $@"
                    SELECT * FROM (
                        SELECT NVL(TO_CHAR(s.locker_id), '-') AS locker_str,
                               s.type,
                               s.description,
                               NVL(b.branch_name, '시스템') AS branch_name
                        FROM SystemLogs s
                        LEFT JOIN Lockers l ON s.locker_id = l.locker_id
                        LEFT JOIN Branches b ON l.branch_id = b.branch_id
                        WHERE ABS(s.created_at - TO_DATE('{selectedTime}', 'YYYY-MM-DD HH24:MI:SS')) <= (30 / 1440)
                        ORDER BY ABS(s.created_at - TO_DATE('{selectedTime}', 'YYYY-MM-DD HH24:MI:SS')) ASC
                    ) WHERE ROWNUM = 1";

                DataTable dt = DBHelper.ExecuteQuery(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string l_str = row["locker_str"].ToString();
                    currentLocker = (l_str == "-") ? "-" : $"{l_str}호";
                    currentBranch = row["branch_name"].ToString();
                    currentStatus = row["type"].ToString();
                    currentDesc = row["description"].ToString();
                }
                else
                {
                    currentBranch = cmbBranch.SelectedItem?.ToString() ?? "전체 지점";
                    currentLocker = "-";
                    currentStatus = "NORMAL";
                    currentDesc = "해당 시점 특이사항 없음";
                }
            }
            catch
            {
                currentStatus = "NORMAL";
                currentDesc = "해당 시점 녹화 재생";
            }

            UpdateCctvLabels();
            DrawCctvScreen(currentLocker, currentStatus, selectedTime, false, currentDesc);
        }

        private void UpdateCctvLabels()
        {
            lblCctvLocation.Text = $"감시 구역: {currentBranch} 무인택배 부스";

            if (currentStatus == "ERROR")
            {
                lblCctvStatus.Text = $"센서 상태: ⚠ {currentDesc} (ERROR)";
                lblCctvStatus.ForeColor = Color.Red;
            }
            else
            {
                lblCctvStatus.Text = $"센서 상태: ✔ {currentDesc} ({currentStatus})";
                lblCctvStatus.ForeColor = Color.SeaGreen;
            }
        }

        private void dtpCctvTime_ValueChanged(object sender, EventArgs e)
        {
            if (!isLiveMode)
            {
                string selectedTime = dtpCctvTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                DrawCctvScreen(currentLocker, currentStatus, selectedTime, false, currentDesc);
            }
        }

        private void btnLiveNow_Click(object sender, EventArgs e)
        {
            StartLiveMode();
        }

        private void StartLiveMode()
        {
            isLiveMode = true;
            currentStatus = "LIVE";
            currentDesc = "";
            dtpCctvTime.Value = DateTime.Now;

            string selectedBranch = cmbBranch.SelectedItem?.ToString() ?? "전체 지점";
            lblCctvLocation.Text = $"감시 구역: {selectedBranch} 실시간 모니터링 (LIVE)";
            lblCctvStatus.Text = "센서 상태: ✔ 현재 모든 보관함 센서 정상 작동 중";
            lblCctvStatus.ForeColor = Color.RoyalBlue;

            DrawCctvScreen("-", "LIVE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), true, "");
            liveTimer.Start();
        }

        private void LiveTimer_Tick(object sender, EventArgs e)
        {
            if (isLiveMode)
            {
                dtpCctvTime.Value = DateTime.Now;
                DrawCctvScreen("-", "LIVE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), true, "");
            }
        }

        private void DrawCctvScreen(string lockerNo, string logType, string timeStr, bool isLive, string desc = "")
        {
            Bitmap bmp = new Bitmap(380, 220);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(28, 33, 43));

                // ERROR 상태일 때 CCTV 화면 전체에 빨간 경고 테두리 표시
                if (logType == "ERROR")
                {
                    using (Pen errPen = new Pen(Color.Red, 4))
                    {
                        g.DrawRectangle(errPen, 2, 2, 376, 216);
                    }
                }

                int startX = 45, startY = 55;
                string[] lockers = { "101호", "102호", "103호", "104호", "105호" };

                for (int i = 0; i < lockers.Length; i++)
                {
                    Rectangle rect = new Rectangle(startX + (i * 58), startY, 52, 110);
                    bool isTarget = (lockers[i] == lockerNo);

                    Brush boxBrush = Brushes.DimGray;
                    if (isTarget)
                    {
                        boxBrush = (logType == "ERROR") ? Brushes.Crimson : Brushes.SteelBlue;
                    }

                    g.FillRectangle(boxBrush, rect);
                    g.DrawRectangle(Pens.Silver, rect);
                    g.DrawString(lockers[i], new Font("맑은 고딕", 9, FontStyle.Bold), Brushes.White, rect.X + 6, rect.Y + 40);

                    // 오류 보관함에 경고 문구 추가
                    if (isTarget && logType == "ERROR")
                    {
                        g.DrawString("⚠오류", new Font("맑은 고딕", 8, FontStyle.Bold), Brushes.Yellow, rect.X + 5, rect.Y + 65);
                    }
                }

                Brush recBrush = isLive ? Brushes.LimeGreen : Brushes.Red;
                string modeText = isLive ? "LIVE" : "REPLAY";
                string camText = (lockerNo == "-") ? "CAM-ALL" : $"CAM-{lockerNo.Replace("호", "")}";

                g.FillEllipse(recBrush, 12, 12, 12, 12);
                g.DrawString($"{camText} ({modeText})", new Font("Consolas", 10, FontStyle.Bold), Brushes.White, 30, 10);
                g.DrawString(timeStr, new Font("Consolas", 9, FontStyle.Bold), Brushes.Yellow, 225, 11);

                string footerText = isLive
                    ? "[실시간 관제 중] 이상 없음"
                    : (logType == "ERROR"
                        ? $"[오류 감지] ⚠ {(string.IsNullOrEmpty(desc) ? "보관함 문 열림 센서 오류" : desc)}"
                        : (lockerNo == "-" ? $"[과거 기록] {desc}" : $"[과거 기록] {lockerNo} 작업 시점 재생 중"));

                Brush footerBrush = (logType == "ERROR") ? Brushes.Yellow : Brushes.LightGreen;
                g.DrawString(footerText, new Font("맑은 고딕", 9, FontStyle.Bold), footerBrush, 15, 185);
            }

            picCCTV.Image = bmp;
        }

        private void btnFilterSearch_Click(object sender, EventArgs e)
        {
            string bName = cmbBranch.SelectedItem?.ToString() ?? "전체";
            string lType = cmbLogType.SelectedItem?.ToString() ?? "전체";
            LoadLogs(lType, bName);
            StartLiveMode();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (lvSystemLogs.SelectedItems.Count == 0)
            {
                MessageBox.Show("삭제할 기록을 먼저 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dbc.SelectedLogId = Convert.ToInt32(lvSystemLogs.SelectedItems[0].SubItems[0].Text);

            if (MessageBox.Show($"로그 번호 [{dbc.SelectedLogId}] 기록을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DBHelper.ExecuteNonQuery("DELETE FROM SystemLogs WHERE log_id = :id", new OracleParameter[] {
                    new OracleParameter("id", dbc.SelectedLogId)
                });

                MessageBox.Show("기록이 삭제되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string bName = cmbBranch.SelectedItem?.ToString() ?? "전체";
                string lType = cmbLogType.SelectedItem?.ToString() ?? "전체";
                LoadLogs(lType, bName);
                StartLiveMode();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddBranch_Click(object sender, EventArgs e)
        {
            Form popup = new Form()
            {
                Width = 340,
                Height = 230,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "신규 지점 등록",
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblName = new Label() { Left = 20, Top = 23, Text = "지점명 *", Width = 65 };
            TextBox txtName = new TextBox() { Left = 90, Top = 20, Width = 210 };

            Label lblAddr = new Label() { Left = 20, Top = 63, Text = "주소", Width = 65 };
            TextBox txtAddr = new TextBox() { Left = 90, Top = 60, Width = 210 };

            Label lblContact = new Label() { Left = 20, Top = 103, Text = "연락처", Width = 65 };
            TextBox txtContact = new TextBox() { Left = 90, Top = 100, Width = 210 };

            Button btnSave = new Button() { Text = "등록", Left = 135, Width = 80, Top = 145 };
            Button btnCancel = new Button() { Text = "취소", Left = 220, Width = 80, Top = 145, DialogResult = DialogResult.Cancel };

            btnSave.Click += (s, ev) =>
            {
                string branchName = txtName.Text.Trim();
                string address = txtAddr.Text.Trim();
                string contact = txtContact.Text.Trim();

                if (string.IsNullOrEmpty(branchName))
                {
                    MessageBox.Show("지점명을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                try
                {
                    string sql = @"
                        INSERT INTO Branches (branch_id, branch_name, address, contact)
                        VALUES ((SELECT NVL(MAX(branch_id), 0) + 1 FROM Branches), :name, :addr, :contact)";

                    OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter("name", branchName),
                        new OracleParameter("addr", address),
                        new OracleParameter("contact", contact)
                    };

                    DBHelper.ExecuteNonQuery(sql, parameters);

                    MessageBox.Show($"[{branchName}] 지점이 등록되었습니다.", "등록 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBranches();
                    popup.DialogResult = DialogResult.OK;
                    popup.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"지점 등록 중 오류가 발생했습니다.\n{ex.Message}", "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            popup.Controls.AddRange(new Control[] { lblName, txtName, lblAddr, txtAddr, lblContact, txtContact, btnSave, btnCancel });
            popup.AcceptButton = btnSave;
            popup.CancelButton = btnCancel;

            popup.ShowDialog(this);
        }
    }
}