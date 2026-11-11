using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BOX.App
{
    public partial class SystemLogForm : Form // 클래스명 변경
    {
        private int currentParcelId = -1;
        private int currentLockerId = -1;
        private string currentUserId = string.Empty;

        public SystemLogForm() // 생성자명 변경
        {
            InitializeComponent();

            // Load 이벤트 연결 누락과 무관하게 폼 실행 즉시 100% 강제 실행
            InitDatabaseAndUI();
        }

        // ==========================================
        // 0. 프로그램 시작 시 DB 5개 튜플 강제 동기화 및 UI 초기화
        // ==========================================
        private void InitDatabaseAndUI()
        {
            try
            {
                // 1. 우측 이용 내역/로그 깨끗하게 비우기 (실행할 때마다 초기화)
                DBHelper.ExecuteNonQuery("DELETE FROM SystemLogs");

                // 2. 기존 택배 데이터 비우고 6자리 5개 튜플 통째로 재등록
                DBHelper.ExecuteNonQuery("DELETE FROM Parcels");

                string insertSql = @"
                    INSERT ALL
                      INTO Parcels VALUES (1, 'user01', 101, '111111', TO_DATE('2026-11-08 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-11 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-08 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'RETRIEVED')
                      INTO Parcels VALUES (2, 'user02', 102, '748291', TO_DATE('2026-11-09 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-12 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'STORED')
                      INTO Parcels VALUES (3, 'user03', 103, '123456', TO_DATE('2026-11-09 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-12 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'STORED')
                      INTO Parcels VALUES (4, 'user01', 101, '333444', TO_DATE('2026-11-05 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-08 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'EXPIRED')
                      INTO Parcels VALUES (5, 'user02', 105, '777888', TO_DATE('2026-11-09 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-12 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'RESERVED')
                    SELECT * FROM DUAL";
                DBHelper.ExecuteNonQuery(insertSql);

                // 3. 사물함 상태 복구
                DBHelper.ExecuteNonQuery("UPDATE Lockers SET status = 'OCCUPIED' WHERE locker_id IN (102, 103)");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DB 초기화 실패 (원인): {ex.Message}", "초기화 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ResetUI();
            LoadSystemLogs(); // 우측 그리드뷰 빈 상태로 시작
        }

        private void SystemLogForm_Load(object sender, EventArgs e)
        {
            // 이벤트명 동기화
        }

        // ==========================================
        // 1. 인증 확인 버튼: 6자리 번호 판별
        // ==========================================
        private void btnAuthConfirm_Click(object sender, EventArgs e)
        {
            string authCode = txtAuthCode.Text.Trim();

            if (string.IsNullOrEmpty(authCode))
            {
                MessageBox.Show("6자리 인증번호를 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"
                    SELECT p.parcel_id, p.user_id, p.locker_id, p.status,
                           NVL(b.branch_name, '부천대 본관점') AS branch_name,
                           NVL(l.location_desc, '본관 1층 무인택배 부스') AS location_desc
                    FROM Parcels p
                    LEFT JOIN Lockers l ON p.locker_id = l.locker_id
                    LEFT JOIN Branches b ON l.branch_id = b.branch_id
                    WHERE TRIM(p.auth_code) = :authCode";

                OracleParameter param = new OracleParameter("authCode", OracleDbType.Varchar2)
                {
                    Value = authCode
                };

                DataTable dt = DBHelper.ExecuteQuery(sql, new OracleParameter[] { param });

                if (dt == null || dt.Rows.Count == 0)
                {
                    string fallbackSql = $@"
                        SELECT p.parcel_id, p.user_id, p.locker_id, p.status,
                               NVL(b.branch_name, '부천대 본관점') AS branch_name,
                               NVL(l.location_desc, '본관 1층 무인택배 부스') AS location_desc
                        FROM Parcels p
                        LEFT JOIN Lockers l ON p.locker_id = l.locker_id
                        LEFT JOIN Branches b ON l.branch_id = b.branch_id
                        WHERE p.auth_code LIKE '%{authCode}%'";
                    dt = DBHelper.ExecuteQuery(fallbackSql);
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string status = row["status"].ToString().Trim();

                    if (status != "STORED")
                    {
                        string msg = status == "RETRIEVED" ? "이미 수령 완료된 택배입니다." :
                                     status == "EXPIRED" ? "보관 기간이 만료된 택배입니다." : "현재 보관 중인 택배가 아닙니다.";

                        lblAuthStatus.Text = $"❌ {msg}";
                        lblAuthStatus.ForeColor = Color.Red;
                        lblAuthStatus.Visible = true;
                        btnOpenDoor.Enabled = false;
                        return;
                    }

                    currentParcelId = Convert.ToInt32(row["parcel_id"]);
                    currentLockerId = Convert.ToInt32(row["locker_id"]);
                    currentUserId = row["user_id"].ToString();

                    lblAuthStatus.Text = "✔ 인증이 완료되었습니다.";
                    lblAuthStatus.ForeColor = Color.SeaGreen;
                    lblAuthStatus.Visible = true;

                    lblBranch.Text = $"지점명: {row["branch_name"]}";
                    lblLockerNo.Text = $"보관함 번호: {currentLockerId}호";
                    lblLocation.Text = $"상세 위치: {row["location_desc"]}";
                    lblStatus.Text = "상태: 보관중";
                    lblStatus.ForeColor = Color.DarkOrange;

                    btnOpenDoor.Enabled = true;
                    btnOpenDoor.BackColor = Color.MistyRose;
                }
                else
                {
                    lblAuthStatus.Text = "❌ 유효하지 않은 인증번호입니다.";
                    lblAuthStatus.ForeColor = Color.Red;
                    lblAuthStatus.Visible = true;
                    btnOpenDoor.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DB 조회 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnAuthConfirm_Click(sender, e);
        }

        // ==========================================
        // 2. 보관함 개방 (문 열기)
        // ==========================================
        private void btnOpenDoor_Click(object sender, EventArgs e)
        {
            if (currentParcelId == -1) return;

            grpLockerInfo.Text = "2. 보관함 개방";
            MessageBox.Show($"[{currentLockerId}호] 보관함 문이 개방되었습니다!\n물품을 꺼낸 후 문을 닫고 [수령 완료]를 눌러주세요.",
                            "보관함 개방 알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnOpenDoor.Enabled = false;
            btnOpenDoor.BackColor = SystemColors.Control;

            btnComplete.Enabled = true;
            btnComplete.BackColor = Color.MistyRose;
        }

        // ==========================================
        // 3. 수령 완료 처리
        // ==========================================
        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (currentParcelId == -1) return;

            try
            {
                // ① 택배 상태 변경
                string updateParcelSql = @"
                    UPDATE Parcels 
                    SET status = 'RETRIEVED', retrieved_at = SYSDATE 
                    WHERE parcel_id = :parcelId";
                DBHelper.ExecuteNonQuery(updateParcelSql, new OracleParameter[] {
                    new OracleParameter("parcelId", currentParcelId)
                });

                // ② 사물함 상태 비우기
                string updateLockerSql = @"
                    UPDATE Lockers 
                    SET status = 'EMPTY' 
                    WHERE locker_id = :lockerId";
                DBHelper.ExecuteNonQuery(updateLockerSql, new OracleParameter[] {
                    new OracleParameter("lockerId", currentLockerId)
                });

                // ③ 시스템 로그 저장
                string insertLogSql = @"
                    INSERT INTO SystemLogs (log_id, user_id, locker_id, type, description, created_at)
                    VALUES ((SELECT NVL(MAX(log_id), 0) + 1 FROM SystemLogs), :userId, :lockerId, '수령', '수령 완료 (사용자)', SYSDATE)";
                DBHelper.ExecuteNonQuery(insertLogSql, new OracleParameter[] {
                    new OracleParameter("userId", currentUserId),
                    new OracleParameter("lockerId", currentLockerId)
                });

                MessageBox.Show("수령이 완료되었습니다. 이용해 주셔서 감사합니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadSystemLogs();
                ResetUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"수령 처리 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 4. 우측 시스템 로그 및 수령 내역 조회
        // ==========================================
        private void LoadSystemLogs()
        {
            try
            {
                string sql = @"
                    SELECT TO_CHAR(created_at, 'YYYY-MM-DD HH24:MI') AS 일시,
                           type AS 구분,
                           locker_id || '호' AS 보관함,
                           description AS 처리내용
                    FROM SystemLogs
                    WHERE type IN ('수령', 'RETRIEVE', 'RETRIEVED')
                    ORDER BY created_at DESC, log_id DESC";

                DataTable dt = DBHelper.ExecuteQuery(sql);
                dgvLogs.DataSource = dt;
                dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLogs.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[로그 로드 오류]: {ex.Message}");
            }
        }

        // ==========================================
        // 5. 화면 상태 초기화 함수
        // ==========================================
        private void ResetUI()
        {
            currentParcelId = -1;
            currentLockerId = -1;
            currentUserId = string.Empty;

            txtAuthCode.Clear();
            lblAuthStatus.Visible = false;

            grpLockerInfo.Text = "2. 보관함 상세 위치 확인";
            lblBranch.Text = "지점명: -";
            lblLockerNo.Text = "보관함 번호: -";
            lblLocation.Text = "상세 위치: -";
            lblStatus.Text = "상태: 대기";
            lblStatus.ForeColor = Color.Black;

            btnOpenDoor.Enabled = false;
            btnOpenDoor.BackColor = SystemColors.Control;
            btnComplete.Enabled = false;
            btnComplete.BackColor = SystemColors.Control;
        }
    }
}