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
            sidebar = new Panel();
            versionlbl = new Label();
            idLbl = new Label();
            panel3 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            emailLbl = new Label();
            nameLbl = new Label();
            pictureBox1 = new PictureBox();
            topbar = new Panel();
            timerLbl = new Label();
            navLbl = new Label();
            mainPanel = new Panel();
            sidebar.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            topbar.SuspendLayout();
            SuspendLayout();
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.White;
            sidebar.Controls.Add(versionlbl);
            sidebar.Controls.Add(idLbl);
            sidebar.Controls.Add(panel3);
            sidebar.Controls.Add(button1);
            sidebar.Controls.Add(panel2);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(288, 558);
            sidebar.TabIndex = 1;
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
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button2);
            panel3.Location = new Point(-45, 75);
            panel3.Name = "panel3";
            panel3.Size = new Size(333, 402);
            panel3.TabIndex = 0;
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(998, 558);
            Controls.Add(mainPanel);
            Controls.Add(topbar);
            Controls.Add(sidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserDashboard";
            sidebar.ResumeLayout(false);
            sidebar.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            topbar.ResumeLayout(false);
            topbar.PerformLayout();
            ResumeLayout(false);
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
    }
}