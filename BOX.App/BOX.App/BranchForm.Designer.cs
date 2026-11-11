namespace BOX.App
{
    partial class BranchForm
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSelectedName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvBranches = new System.Windows.Forms.DataGridView();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblInUse = new System.Windows.Forms.Label();
            this.lblSelectedAddress = new System.Windows.Forms.Label();
            this.lblSelectedPhone = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(43, 133);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(585, 40);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(732, 133);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 40);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(831, 133);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(35, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "지점 목록";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "원하는 지점의 위치와 잔여보관함을 확인하세요.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(39, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "선택지점";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "잔여 보관함";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "전체 보관함";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(40, 541);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "연락처:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(40, 507);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "주소:";
            // 
            // lblSelectedName
            // 
            this.lblSelectedName.AutoSize = true;
            this.lblSelectedName.Location = new System.Drawing.Point(138, 474);
            this.lblSelectedName.Name = "lblSelectedName";
            this.lblSelectedName.Size = new System.Drawing.Size(122, 18);
            this.lblSelectedName.TabIndex = 10;
            this.lblSelectedName.Text = "부천대 본관점";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInUse);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(539, 568);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 113);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAvailable);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(290, 568);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 113);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(43, 568);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 113);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // dgvBranches
            // 
            this.dgvBranches.AllowUserToAddRows = false;
            this.dgvBranches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBranches.Location = new System.Drawing.Point(42, 198);
            this.dgvBranches.Name = "dgvBranches";
            this.dgvBranches.ReadOnly = true;
            this.dgvBranches.RowHeadersWidth = 62;
            this.dgvBranches.RowTemplate.Height = 30;
            this.dgvBranches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBranches.Size = new System.Drawing.Size(882, 236);
            this.dgvBranches.TabIndex = 0;
            this.dgvBranches.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBranches_CellClick);
            // 
            // comboSearch
            // 
            this.comboSearch.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Items.AddRange(new object[] {
            "",
            "전체",
            "경기도"});
            this.comboSearch.Location = new System.Drawing.Point(633, 141);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(93, 32);
            this.comboSearch.TabIndex = 11;
            this.comboSearch.SelectedIndexChanged += new System.EventHandler(this.comboSearch_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "사용 중/고장";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotal.Location = new System.Drawing.Point(6, 70);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(23, 24);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "3";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAvailable.Location = new System.Drawing.Point(6, 70);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(23, 24);
            this.lblAvailable.TabIndex = 12;
            this.lblAvailable.Text = "1";
            // 
            // lblInUse
            // 
            this.lblInUse.AutoSize = true;
            this.lblInUse.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInUse.Location = new System.Drawing.Point(6, 70);
            this.lblInUse.Name = "lblInUse";
            this.lblInUse.Size = new System.Drawing.Size(23, 24);
            this.lblInUse.TabIndex = 13;
            this.lblInUse.Text = "2";
            // 
            // lblSelectedAddress
            // 
            this.lblSelectedAddress.AutoSize = true;
            this.lblSelectedAddress.Location = new System.Drawing.Point(96, 507);
            this.lblSelectedAddress.Name = "lblSelectedAddress";
            this.lblSelectedAddress.Size = new System.Drawing.Size(208, 18);
            this.lblSelectedAddress.TabIndex = 12;
            this.lblSelectedAddress.Text = "경기도 부천시 신흥로 56";
            // 
            // lblSelectedPhone
            // 
            this.lblSelectedPhone.AutoSize = true;
            this.lblSelectedPhone.Location = new System.Drawing.Point(114, 541);
            this.lblSelectedPhone.Name = "lblSelectedPhone";
            this.lblSelectedPhone.Size = new System.Drawing.Size(126, 18);
            this.lblSelectedPhone.TabIndex = 13;
            this.lblSelectedPhone.Text = "032-610-0114";
            // 
            // BranchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 848);
            this.Controls.Add(this.lblSelectedPhone);
            this.Controls.Add(this.lblSelectedAddress);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvBranches);
            this.Controls.Add(this.lblSelectedName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Name = "BranchForm";
            this.Text = "BranchForm";
            this.Load += new System.EventHandler(this.BranchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSelectedName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvBranches;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblInUse;
        private System.Windows.Forms.Label lblSelectedAddress;
        private System.Windows.Forms.Label lblSelectedPhone;
    }
}