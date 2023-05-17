namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    partial class AdminDashboard
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
            this.topbar = new System.Windows.Forms.Panel();
            this.timeLbl = new System.Windows.Forms.Label();
            this.timerLbl = new System.Windows.Forms.Label();
            this.navLbl = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.subtitleLbl = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pageLbl = new System.Windows.Forms.Label();
            this.nextLastBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.prevLastBtn = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.versionlbl = new System.Windows.Forms.Label();
            this.topbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // topbar
            // 
            this.topbar.BackColor = System.Drawing.Color.White;
            this.topbar.Controls.Add(this.timeLbl);
            this.topbar.Controls.Add(this.timerLbl);
            this.topbar.Controls.Add(this.navLbl);
            this.topbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topbar.Location = new System.Drawing.Point(0, 0);
            this.topbar.Name = "topbar";
            this.topbar.Size = new System.Drawing.Size(1182, 38);
            this.topbar.TabIndex = 2;
            // 
            // timeLbl
            // 
            this.timeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timeLbl.Location = new System.Drawing.Point(858, 14);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(312, 15);
            this.timeLbl.TabIndex = 2;
            this.timeLbl.Text = "Sept. 14 2023. Monday. 11:00:34 AM";
            this.timeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerLbl
            // 
            this.timerLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerLbl.AutoSize = true;
            this.timerLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timerLbl.Location = new System.Drawing.Point(1471, 12);
            this.timerLbl.Name = "timerLbl";
            this.timerLbl.Size = new System.Drawing.Size(209, 15);
            this.timerLbl.TabIndex = 1;
            this.timerLbl.Text = "Sept. 14 2023. Monday. 11:00:34 AM";
            this.timerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // navLbl
            // 
            this.navLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.navLbl.AutoSize = true;
            this.navLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navLbl.Location = new System.Drawing.Point(12, 9);
            this.navLbl.Name = "navLbl";
            this.navLbl.Size = new System.Drawing.Size(203, 21);
            this.navLbl.TabIndex = 0;
            this.navLbl.Text = "Administrator Dashboard";
            this.navLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button11.Location = new System.Drawing.Point(1080, 56);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(90, 27);
            this.button11.TabIndex = 13;
            this.button11.Text = "Open Menu";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // subtitleLbl
            // 
            this.subtitleLbl.AutoSize = true;
            this.subtitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.subtitleLbl.ForeColor = System.Drawing.Color.Gray;
            this.subtitleLbl.Location = new System.Drawing.Point(15, 80);
            this.subtitleLbl.Name = "subtitleLbl";
            this.subtitleLbl.Size = new System.Drawing.Size(247, 17);
            this.subtitleLbl.TabIndex = 12;
            this.subtitleLbl.Text = "You currently have 5 book(s) registered";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLbl.Location = new System.Drawing.Point(12, 50);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(205, 30);
            this.titleLbl.TabIndex = 11;
            this.titleLbl.Text = "Good Morning, Elle";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 115);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1155, 434);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // pageLbl
            // 
            this.pageLbl.AutoSize = true;
            this.pageLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageLbl.Location = new System.Drawing.Point(575, 571);
            this.pageLbl.Name = "pageLbl";
            this.pageLbl.Size = new System.Drawing.Size(30, 17);
            this.pageLbl.TabIndex = 19;
            this.pageLbl.Text = "1 | 1";
            this.pageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextLastBtn
            // 
            this.nextLastBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.nextLastBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextLastBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextLastBtn.Location = new System.Drawing.Point(644, 567);
            this.nextLastBtn.Name = "nextLastBtn";
            this.nextLastBtn.Size = new System.Drawing.Size(42, 27);
            this.nextLastBtn.TabIndex = 18;
            this.nextLastBtn.Text = ">>";
            this.nextLastBtn.UseVisualStyleBackColor = false;
            this.nextLastBtn.Click += new System.EventHandler(this.nextLastBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextBtn.Location = new System.Drawing.Point(611, 567);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(27, 27);
            this.nextBtn.TabIndex = 17;
            this.nextBtn.Text = ">";
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.prevBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.prevBtn.Location = new System.Drawing.Point(542, 567);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(27, 27);
            this.prevBtn.TabIndex = 16;
            this.prevBtn.Text = "<";
            this.prevBtn.UseVisualStyleBackColor = false;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // prevLastBtn
            // 
            this.prevLastBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.prevLastBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevLastBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.prevLastBtn.Location = new System.Drawing.Point(492, 567);
            this.prevLastBtn.Name = "prevLastBtn";
            this.prevLastBtn.Size = new System.Drawing.Size(42, 27);
            this.prevLastBtn.TabIndex = 15;
            this.prevLastBtn.Text = "<<";
            this.prevLastBtn.UseVisualStyleBackColor = false;
            this.prevLastBtn.Click += new System.EventHandler(this.prevLastBtn_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(1120, 605);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(50, 15);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Log Out";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // versionlbl
            // 
            this.versionlbl.AutoSize = true;
            this.versionlbl.Location = new System.Drawing.Point(15, 605);
            this.versionlbl.Name = "versionlbl";
            this.versionlbl.Size = new System.Drawing.Size(80, 15);
            this.versionlbl.TabIndex = 22;
            this.versionlbl.Text = "Version Name";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1182, 629);
            this.Controls.Add(this.versionlbl);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.pageLbl);
            this.Controls.Add(this.nextLastBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.prevLastBtn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.subtitleLbl);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.topbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.topbar.ResumeLayout(false);
            this.topbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel topbar;
        private Label timerLbl;
        private Label navLbl;
        private Label timeLbl;
        private Button button11;
        private Label subtitleLbl;
        private Label titleLbl;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label pageLbl;
        private Button nextLastBtn;
        private Button nextBtn;
        private Button prevBtn;
        private Button prevLastBtn;
        private LinkLabel linkLabel2;
        private Label versionlbl;
    }
}