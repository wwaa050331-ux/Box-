namespace BOX.App
{
    partial class ManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFilterSearch = new System.Windows.Forms.Button();
            this.cmbLogType = new System.Windows.Forms.ComboBox();
            this.lvSystemLogs = new System.Windows.Forms.ListView();
            this.로그번호 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.일시 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.사용자 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.보관함 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.구분 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.처리내용 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.picCCTV = new System.Windows.Forms.PictureBox();
            this.btnTimeMove = new System.Windows.Forms.Button();
            this.btnLiveNow = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpCctvTime = new System.Windows.Forms.DateTimePicker();
            this.lblCctvStatus = new System.Windows.Forms.Label();
            this.lblCctvLocation = new System.Windows.Forms.Label();
            this.btnAddBranch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCCTV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBranch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnFilterSearch);
            this.groupBox1.Controls.Add(this.cmbLogType);
            this.groupBox1.Controls.Add(this.lvSystemLogs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 397);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "로그 및 시스템 기록";
            // 
            // cmbBranch
            // 
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Items.AddRange(new object[] {
            "전체",
            "수령",
            "STORE",
            "RETRIEVE",
            "ERROR",
            "LOGIN"});
            this.cmbBranch.Location = new System.Drawing.Point(69, 25);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(159, 20);
            this.cmbBranch.TabIndex = 12;
            this.cmbBranch.Text = "지점을 선택해주세요.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "지점 선택";
            // 
            // btnFilterSearch
            // 
            this.btnFilterSearch.Location = new System.Drawing.Point(284, 54);
            this.btnFilterSearch.Name = "btnFilterSearch";
            this.btnFilterSearch.Size = new System.Drawing.Size(75, 23);
            this.btnFilterSearch.TabIndex = 1;
            this.btnFilterSearch.Text = "조회";
            this.btnFilterSearch.UseVisualStyleBackColor = true;
            this.btnFilterSearch.Click += new System.EventHandler(this.btnFilterSearch_Click);
            // 
            // cmbLogType
            // 
            this.cmbLogType.FormattingEnabled = true;
            this.cmbLogType.Items.AddRange(new object[] {
            "전체",
            "수령",
            "STORE",
            "RETRIEVE",
            "ERROR",
            "LOGIN"});
            this.cmbLogType.Location = new System.Drawing.Point(68, 55);
            this.cmbLogType.Name = "cmbLogType";
            this.cmbLogType.Size = new System.Drawing.Size(159, 20);
            this.cmbLogType.TabIndex = 4;
            this.cmbLogType.Text = "전체";
            // 
            // lvSystemLogs
            // 
            this.lvSystemLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.로그번호,
            this.일시,
            this.사용자,
            this.보관함,
            this.구분,
            this.처리내용});
            this.lvSystemLogs.FullRowSelect = true;
            this.lvSystemLogs.GridLines = true;
            this.lvSystemLogs.HideSelection = false;
            this.lvSystemLogs.Location = new System.Drawing.Point(17, 83);
            this.lvSystemLogs.Name = "lvSystemLogs";
            this.lvSystemLogs.Size = new System.Drawing.Size(404, 289);
            this.lvSystemLogs.TabIndex = 2;
            this.lvSystemLogs.UseCompatibleStateImageBehavior = false;
            this.lvSystemLogs.View = System.Windows.Forms.View.Details;
            // 
            // 로그번호
            // 
            this.로그번호.Text = "로그번호";
            // 
            // 일시
            // 
            this.일시.Text = "일시";
            this.일시.Width = 98;
            // 
            // 사용자
            // 
            this.사용자.Text = "사용자";
            // 
            // 보관함
            // 
            this.보관함.Text = "보관함";
            // 
            // 구분
            // 
            this.구분.Text = "구분";
            // 
            // 처리내용
            // 
            this.처리내용.Text = "처리내용";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "기록 구분  ";
            // 
            // picCCTV
            // 
            this.picCCTV.BackColor = System.Drawing.Color.Black;
            this.picCCTV.Location = new System.Drawing.Point(22, 54);
            this.picCCTV.Name = "picCCTV";
            this.picCCTV.Size = new System.Drawing.Size(417, 242);
            this.picCCTV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCCTV.TabIndex = 5;
            this.picCCTV.TabStop = false;
            // 
            // btnTimeMove
            // 
            this.btnTimeMove.Location = new System.Drawing.Point(289, 17);
            this.btnTimeMove.Name = "btnTimeMove";
            this.btnTimeMove.Size = new System.Drawing.Size(75, 28);
            this.btnTimeMove.TabIndex = 6;
            this.btnTimeMove.Text = "시점 이동";
            this.btnTimeMove.UseVisualStyleBackColor = true;
            // 
            // btnLiveNow
            // 
            this.btnLiveNow.Location = new System.Drawing.Point(370, 16);
            this.btnLiveNow.Name = "btnLiveNow";
            this.btnLiveNow.Size = new System.Drawing.Size(75, 28);
            this.btnLiveNow.TabIndex = 7;
            this.btnLiveNow.Text = "현재 시점";
            this.btnLiveNow.UseVisualStyleBackColor = true;
            this.btnLiveNow.Click += new System.EventHandler(this.btnLiveNow_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(370, 368);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Location = new System.Drawing.Point(269, 368);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(95, 23);
            this.btnDeleteRecord.TabIndex = 9;
            this.btnDeleteRecord.Text = "선택 기록 삭제";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "시점 선택";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpCctvTime);
            this.groupBox2.Controls.Add(this.lblCctvStatus);
            this.groupBox2.Controls.Add(this.lblCctvLocation);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnDeleteRecord);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.picCCTV);
            this.groupBox2.Controls.Add(this.btnLiveNow);
            this.groupBox2.Controls.Add(this.btnTimeMove);
            this.groupBox2.Location = new System.Drawing.Point(476, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(445, 397);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "실시간 보관함 CCTV 화면";
            // 
            // dtpCctvTime
            // 
            this.dtpCctvTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCctvTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCctvTime.Location = new System.Drawing.Point(83, 21);
            this.dtpCctvTime.Name = "dtpCctvTime";
            this.dtpCctvTime.ShowUpDown = true;
            this.dtpCctvTime.Size = new System.Drawing.Size(134, 21);
            this.dtpCctvTime.TabIndex = 13;
            // 
            // lblCctvStatus
            // 
            this.lblCctvStatus.AutoSize = true;
            this.lblCctvStatus.ForeColor = System.Drawing.Color.Crimson;
            this.lblCctvStatus.Location = new System.Drawing.Point(20, 339);
            this.lblCctvStatus.Name = "lblCctvStatus";
            this.lblCctvStatus.Size = new System.Drawing.Size(38, 12);
            this.lblCctvStatus.TabIndex = 12;
            this.lblCctvStatus.Text = "label4";
            // 
            // lblCctvLocation
            // 
            this.lblCctvLocation.AutoSize = true;
            this.lblCctvLocation.Location = new System.Drawing.Point(20, 311);
            this.lblCctvLocation.Name = "lblCctvLocation";
            this.lblCctvLocation.Size = new System.Drawing.Size(38, 12);
            this.lblCctvLocation.TabIndex = 11;
            this.lblCctvLocation.Text = "label3";
            // 
            // btnAddBranch
            // 
            this.btnAddBranch.Location = new System.Drawing.Point(29, 430);
            this.btnAddBranch.Name = "btnAddBranch";
            this.btnAddBranch.Size = new System.Drawing.Size(93, 23);
            this.btnAddBranch.TabIndex = 14;
            this.btnAddBranch.Text = "[+ 지점 추가]";
            this.btnAddBranch.UseVisualStyleBackColor = true;
            this.btnAddBranch.Click += new System.EventHandler(this.btnAddBranch_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 465);
            this.Controls.Add(this.btnAddBranch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ManagerForm";
            this.Text = "오류 및 시스템 기록(CCTV)";
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCCTV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFilterSearch;
        private System.Windows.Forms.ComboBox cmbLogType;
        private System.Windows.Forms.ListView lvSystemLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picCCTV;
        private System.Windows.Forms.Button btnTimeMove;
        private System.Windows.Forms.Button btnLiveNow;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCctvStatus;
        private System.Windows.Forms.Label lblCctvLocation;
        private System.Windows.Forms.ColumnHeader 로그번호;
        private System.Windows.Forms.ColumnHeader 일시;
        private System.Windows.Forms.ColumnHeader 사용자;
        private System.Windows.Forms.ColumnHeader 보관함;
        private System.Windows.Forms.ColumnHeader 구분;
        private System.Windows.Forms.ColumnHeader 처리내용;
        private System.Windows.Forms.DateTimePicker dtpCctvTime;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddBranch;
    }
}