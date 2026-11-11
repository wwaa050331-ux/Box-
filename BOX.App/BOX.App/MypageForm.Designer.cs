namespace BOX.App
{
    partial class MypageForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtEditPhone = new System.Windows.Forms.TextBox();
            this.txtEditName = new System.Windows.Forms.TextBox();
            this.lblUserPhone = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lnkWithdraw = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(35, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "내 정보";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "회원정보를 확인하고 수정할 수 있습니다";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(24, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "사용자 ID";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(509, 27);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(79, 29);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "수정";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "확인";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.txtEditPhone);
            this.groupBox1.Controls.Add(this.txtEditName);
            this.groupBox1.Controls.Add(this.lblUserPhone);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblUserId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(42, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 259);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(136, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 34);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "정보저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(27, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 34);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtEditPhone
            // 
            this.txtEditPhone.Location = new System.Drawing.Point(115, 132);
            this.txtEditPhone.Name = "txtEditPhone";
            this.txtEditPhone.Size = new System.Drawing.Size(138, 28);
            this.txtEditPhone.TabIndex = 15;
            this.txtEditPhone.Visible = false;
            // 
            // txtEditName
            // 
            this.txtEditName.Location = new System.Drawing.Point(115, 87);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(98, 28);
            this.txtEditName.TabIndex = 14;
            this.txtEditName.Visible = false;
            // 
            // lblUserPhone
            // 
            this.lblUserPhone.AutoSize = true;
            this.lblUserPhone.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserPhone.Location = new System.Drawing.Point(112, 135);
            this.lblUserPhone.Name = "lblUserPhone";
            this.lblUserPhone.Size = new System.Drawing.Size(136, 18);
            this.lblUserPhone.TabIndex = 13;
            this.lblUserPhone.Text = "010-2222-3333";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(24, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "전화번호";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserName.Location = new System.Drawing.Point(112, 90);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(62, 18);
            this.lblUserName.TabIndex = 10;
            this.lblUserName.Text = "홍길동";
            this.lblUserName.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(24, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "이름";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserId.Location = new System.Drawing.Point(112, 42);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(64, 18);
            this.lblUserId.TabIndex = 8;
            this.lblUserId.Text = "user01";
            this.lblUserId.Click += new System.EventHandler(this.label4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(23, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "비밀번호 변경";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(42, 419);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(619, 176);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(136, 119);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 35);
            this.button3.TabIndex = 13;
            this.button3.Text = "변경";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(476, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "비밀번호를 찾기 및 변경하시려면 아래 버튼을 눌러주세요";
            // 
            // lnkWithdraw
            // 
            this.lnkWithdraw.AutoSize = true;
            this.lnkWithdraw.Location = new System.Drawing.Point(517, 623);
            this.lnkWithdraw.Name = "lnkWithdraw";
            this.lnkWithdraw.Size = new System.Drawing.Size(80, 18);
            this.lnkWithdraw.TabIndex = 13;
            this.lnkWithdraw.TabStop = true;
            this.lnkWithdraw.Text = "로그아웃";
            this.lnkWithdraw.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(617, 623);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(44, 18);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "탈퇴";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWithdraw_LinkClicked);
            // 
            // MypageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 802);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.lnkWithdraw);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Name = "MypageForm";
            this.Text = "MypageForm";
            this.Load += new System.EventHandler(this.MypageForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblUserPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtEditPhone;
        private System.Windows.Forms.TextBox txtEditName;
        private System.Windows.Forms.LinkLabel lnkWithdraw;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}