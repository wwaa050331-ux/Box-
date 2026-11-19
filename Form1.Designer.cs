namespace BOX.App
{
    partial class Form1
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
            this.마이페이지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.택배지점선택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.보관신청ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.택배수령및확인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 마이페이지ToolStripMenuItem
            // 
            this.마이페이지ToolStripMenuItem.Name = "마이페이지ToolStripMenuItem";
            this.마이페이지ToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.마이페이지ToolStripMenuItem.Text = "마이페이지";
            this.마이페이지ToolStripMenuItem.Click += new System.EventHandler(this.마이페이지ToolStripMenuItem_Click);
            // 
            // 택배지점선택ToolStripMenuItem
            // 
            this.택배지점선택ToolStripMenuItem.Name = "택배지점선택ToolStripMenuItem";
            this.택배지점선택ToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.택배지점선택ToolStripMenuItem.Text = "택배지점선택";
            this.택배지점선택ToolStripMenuItem.Click += new System.EventHandler(this.택배지점선택ToolStripMenuItem_Click);
            // 
            // 보관신청ToolStripMenuItem
            // 
            this.보관신청ToolStripMenuItem.Name = "보관신청ToolStripMenuItem";
            this.보관신청ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.보관신청ToolStripMenuItem.Text = "보관신청";
            this.보관신청ToolStripMenuItem.Click += new System.EventHandler(this.보관신청ToolStripMenuItem_Click);
            // 
            // 택배수령및확인ToolStripMenuItem
            // 
            this.택배수령및확인ToolStripMenuItem.Name = "택배수령및확인ToolStripMenuItem";
            this.택배수령및확인ToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.택배수령및확인ToolStripMenuItem.Text = "택배수령및확인";
            this.택배수령및확인ToolStripMenuItem.Click += new System.EventHandler(this.택배수령및확인ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.마이페이지ToolStripMenuItem,
            this.택배지점선택ToolStripMenuItem,
            this.보관신청ToolStripMenuItem,
            this.택배수령및확인ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "무인 택배 서비스";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 마이페이지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 택배지점선택ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 보관신청ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 택배수령및확인ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}