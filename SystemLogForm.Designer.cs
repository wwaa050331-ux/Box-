namespace BOX.App
{
    partial class SystemLogForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.gr = new System.Windows.Forms.GroupBox();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnOpenDoor = new System.Windows.Forms.Button();
            this.grpLockerInfo = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblLockerNo = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.grpAuth = new System.Windows.Forms.GroupBox();
            this.lblAuthStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuthCode = new System.Windows.Forms.TextBox();
            this.btnAuthConfirm = new System.Windows.Forms.Button();
            this.grpLogs = new System.Windows.Forms.GroupBox();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.gr.SuspendLayout();
            this.grpLockerInfo.SuspendLayout();
            this.grpAuth.SuspendLayout();
            this.grpLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // gr
            // 
            this.gr.Controls.Add(this.btnComplete);
            this.gr.Controls.Add(this.btnOpenDoor);
            this.gr.Controls.Add(this.grpLockerInfo);
            this.gr.Controls.Add(this.grpAuth);
            this.gr.Location = new System.Drawing.Point(32, 27);
            this.gr.Name = "gr";
            this.gr.Size = new System.Drawing.Size(363, 397);
            this.gr.TabIndex = 0;
            this.gr.TabStop = false;
            this.gr.Text = "인증번호 및 본인인증";
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(179, 332);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(164, 45);
            this.btnComplete.TabIndex = 6;
            this.btnComplete.Text = "수령완료";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnOpenDoor
            // 
            this.btnOpenDoor.Location = new System.Drawing.Point(16, 332);
            this.btnOpenDoor.Name = "btnOpenDoor";
            this.btnOpenDoor.Size = new System.Drawing.Size(157, 45);
            this.btnOpenDoor.TabIndex = 3;
            this.btnOpenDoor.Text = "보관함 개방(문 열기)";
            this.btnOpenDoor.UseVisualStyleBackColor = true;
            this.btnOpenDoor.Click += new System.EventHandler(this.btnOpenDoor_Click);
            // 
            // grpLockerInfo
            // 
            this.grpLockerInfo.BackColor = System.Drawing.SystemColors.Window;
            this.grpLockerInfo.Controls.Add(this.lblStatus);
            this.grpLockerInfo.Controls.Add(this.lblLocation);
            this.grpLockerInfo.Controls.Add(this.lblLockerNo);
            this.grpLockerInfo.Controls.Add(this.lblBranch);
            this.grpLockerInfo.Location = new System.Drawing.Point(16, 162);
            this.grpLockerInfo.Name = "grpLockerInfo";
            this.grpLockerInfo.Size = new System.Drawing.Size(327, 164);
            this.grpLockerInfo.TabIndex = 2;
            this.grpLockerInfo.TabStop = false;
            this.grpLockerInfo.Text = "2. 보관함 상세위치";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 134);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 12);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "label5";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(30, 102);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(38, 12);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "label4";
            // 
            // lblLockerNo
            // 
            this.lblLockerNo.AutoSize = true;
            this.lblLockerNo.Location = new System.Drawing.Point(30, 72);
            this.lblLockerNo.Name = "lblLockerNo";
            this.lblLockerNo.Size = new System.Drawing.Size(38, 12);
            this.lblLockerNo.TabIndex = 3;
            this.lblLockerNo.Text = "label3";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(30, 40);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(38, 12);
            this.lblBranch.TabIndex = 2;
            this.lblBranch.Text = "label2";
            // 
            // grpAuth
            // 
            this.grpAuth.BackColor = System.Drawing.SystemColors.Window;
            this.grpAuth.Controls.Add(this.lblAuthStatus);
            this.grpAuth.Controls.Add(this.label1);
            this.grpAuth.Controls.Add(this.txtAuthCode);
            this.grpAuth.Controls.Add(this.btnAuthConfirm);
            this.grpAuth.Cursor = System.Windows.Forms.Cursors.Default;
            this.grpAuth.Location = new System.Drawing.Point(16, 20);
            this.grpAuth.Name = "grpAuth";
            this.grpAuth.Size = new System.Drawing.Size(327, 117);
            this.grpAuth.TabIndex = 1;
            this.grpAuth.TabStop = false;
            this.grpAuth.Text = "1. 본인인증";
            // 
            // lblAuthStatus
            // 
            this.lblAuthStatus.AutoSize = true;
            this.lblAuthStatus.Location = new System.Drawing.Point(43, 93);
            this.lblAuthStatus.Name = "lblAuthStatus";
            this.lblAuthStatus.Size = new System.Drawing.Size(38, 12);
            this.lblAuthStatus.TabIndex = 2;
            this.lblAuthStatus.Text = "label6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "인증번호 입력";
            // 
            // txtAuthCode
            // 
            this.txtAuthCode.Location = new System.Drawing.Point(45, 60);
            this.txtAuthCode.Name = "txtAuthCode";
            this.txtAuthCode.Size = new System.Drawing.Size(137, 21);
            this.txtAuthCode.TabIndex = 0;
            // 
            // btnAuthConfirm
            // 
            this.btnAuthConfirm.Location = new System.Drawing.Point(199, 52);
            this.btnAuthConfirm.Name = "btnAuthConfirm";
            this.btnAuthConfirm.Size = new System.Drawing.Size(106, 34);
            this.btnAuthConfirm.TabIndex = 0;
            this.btnAuthConfirm.Text = "인증";
            this.btnAuthConfirm.UseVisualStyleBackColor = true;
            this.btnAuthConfirm.Click += new System.EventHandler(this.btnAuthConfirm_Click);
            // 
            // grpLogs
            // 
            this.grpLogs.Controls.Add(this.dgvLogs);
            this.grpLogs.Location = new System.Drawing.Point(437, 27);
            this.grpLogs.Name = "grpLogs";
            this.grpLogs.Size = new System.Drawing.Size(329, 397);
            this.grpLogs.TabIndex = 1;
            this.grpLogs.TabStop = false;
            this.grpLogs.Text = "내 택배 이용 내역 및 시스템 로그";
            // 
            // dgvLogs
            // 
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(6, 39);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.RowTemplate.Height = 23;
            this.dgvLogs.Size = new System.Drawing.Size(317, 329);
            this.dgvLogs.TabIndex = 0;
            // 
            // ParcelPickupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpLogs);
            this.Controls.Add(this.gr);
            this.Name = "ParcelPickupForm";
            this.Text = "무인 택배 보관함";
            this.Load += new System.EventHandler(this.ParcelPickupForm_Load);
            this.gr.ResumeLayout(false);
            this.grpLockerInfo.ResumeLayout(false);
            this.grpLockerInfo.PerformLayout();
            this.grpAuth.ResumeLayout(false);
            this.grpAuth.PerformLayout();
            this.grpLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gr;
        private System.Windows.Forms.GroupBox grpAuth;
        private System.Windows.Forms.GroupBox grpLogs;
        private System.Windows.Forms.Button btnOpenDoor;
        private System.Windows.Forms.GroupBox grpLockerInfo;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblLockerNo;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuthCode;
        private System.Windows.Forms.Button btnAuthConfirm;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Label lblAuthStatus;
    }
}

