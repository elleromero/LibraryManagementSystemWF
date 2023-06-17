namespace LibraryManagementSystemWF.views.Dashboard.GeneralUser
{
    partial class UserDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDashboard));
            this.sidebar = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.versionlbl = new System.Windows.Forms.Label();
            this.idLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.emailLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.topbar = new System.Windows.Forms.Panel();
            this.timerLbl = new System.Windows.Forms.Label();
            this.navLbl = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidebar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.topbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.White;
            this.sidebar.Controls.Add(this.linkLabel2);
            this.sidebar.Controls.Add(this.versionlbl);
            this.sidebar.Controls.Add(this.idLbl);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.button1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(288, 558);
            this.sidebar.TabIndex = 1;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(12, 454);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(134, 15);
            this.linkLabel2.TabIndex = 24;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Recent Announcements";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // versionlbl
            // 
            versionlbl.AutoSize = true;
            versionlbl.Location = new Point(12, 480);
            versionlbl.Name = "versionlbl";
            versionlbl.Size = new Size(80, 15);
            versionlbl.TabIndex = 23;
            versionlbl.Text = "Version Name";
            // 
            // idLbl
            // 
            idLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            idLbl.AutoEllipsis = true;
            idLbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            idLbl.ForeColor = Color.Black;
            idLbl.Location = new Point(12, 495);
            idLbl.Name = "idLbl";
            idLbl.Size = new Size(262, 15);
            idLbl.TabIndex = 2;
            idLbl.Text = "ID: ";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(-45, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(333, 376);
            this.panel3.TabIndex = 0;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(0, 43);
            button3.Name = "button3";
            button3.Size = new Size(333, 43);
            button3.TabIndex = 1;
            button3.Text = "My Repo";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(333, 43);
            button2.TabIndex = 0;
            button2.Text = "Discover";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(254, 206, 47);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(12, 513);
            button1.Name = "button1";
            button1.Size = new Size(262, 33);
            button1.TabIndex = 0;
            button1.Text = "Log Out";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(emailLbl);
            panel2.Controls.Add(nameLbl);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 57);
            panel2.TabIndex = 0;
            // 
            // emailLbl
            // 
            emailLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            emailLbl.AutoEllipsis = true;
            emailLbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            emailLbl.ForeColor = Color.Black;
            emailLbl.Location = new Point(47, 28);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(270, 15);
            emailLbl.TabIndex = 1;
            emailLbl.Text = "marklopez@gmail.com";
            // 
            // nameLbl
            // 
            nameLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameLbl.AutoEllipsis = true;
            nameLbl.AutoSize = true;
            nameLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            nameLbl.Location = new Point(47, 10);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(72, 15);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "Mark Lopez";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(7, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // topbar
            // 
            topbar.BackColor = Color.White;
            topbar.Controls.Add(timerLbl);
            topbar.Controls.Add(navLbl);
            topbar.Dock = DockStyle.Top;
            topbar.Location = new Point(288, 0);
            topbar.Name = "topbar";
            topbar.Size = new Size(710, 38);
            topbar.TabIndex = 2;
            // 
            // timerLbl
            // 
            timerLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            timerLbl.Location = new Point(336, 12);
            timerLbl.Name = "timerLbl";
            timerLbl.Size = new Size(362, 15);
            timerLbl.TabIndex = 1;
            timerLbl.Text = "Sept. 14 2023. Monday. 11:00:34 AM";
            timerLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // navLbl
            // 
            navLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            navLbl.AutoSize = true;
            navLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            navLbl.Location = new Point(6, 9);
            navLbl.Name = "navLbl";
            navLbl.Size = new Size(56, 21);
            navLbl.TabIndex = 0;
            navLbl.Text = "Books";
            navLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.Transparent;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(288, 38);
            mainPanel.Margin = new Padding(0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(710, 520);
            mainPanel.TabIndex = 3;
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(998, 558);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topbar);
            this.Controls.Add(this.sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserDashboard";
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.topbar.ResumeLayout(false);
            this.topbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel sidebar;
        private Label versionlbl;
        private Label idLbl;
        private Panel panel3;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private Label emailLbl;
        private Label nameLbl;
        private PictureBox pictureBox1;
        private Panel topbar;
        private Label timerLbl;
        private Label navLbl;
        private Panel mainPanel;
        private LinkLabel linkLabel2;
    }
}