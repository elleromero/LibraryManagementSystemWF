namespace LibraryManagementSystemWF.views
{
    partial class UserDb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDb));
            panelside = new Panel();
            button4 = new Button();
            panel3 = new Panel();
            btnReturn = new Button();
            btnBorrowed = new Button();
            btnHome = new Button();
            panel2 = new Panel();
            emailLbl = new Label();
            nameLbl = new Label();
            pictureBox1 = new PictureBox();
            mainPanel = new Panel();
            timerLbl = new Label();
            navLbl = new Label();
            topbar = new Panel();
            panelside.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            topbar.SuspendLayout();
            SuspendLayout();
            // 
            // panelside
            // 
            panelside.BackColor = Color.White;
            panelside.Controls.Add(button4);
            panelside.Controls.Add(panel3);
            panelside.Controls.Add(panel2);
            panelside.Dock = DockStyle.Left;
            panelside.Location = new Point(0, 0);
            panelside.Name = "panelside";
            panelside.Size = new Size(288, 558);
            panelside.TabIndex = 0;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.BackColor = Color.FromArgb(254, 206, 47);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(12, 513);
            button4.Name = "button4";
            button4.Size = new Size(262, 33);
            button4.TabIndex = 5;
            button4.Text = "Log Out";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(btnReturn);
            panel3.Controls.Add(btnBorrowed);
            panel3.Controls.Add(btnHome);
            panel3.Location = new Point(-45, 75);
            panel3.Name = "panel3";
            panel3.Size = new Size(333, 417);
            panel3.TabIndex = 4;
            // 
            // btnReturn
            // 
            btnReturn.Dock = DockStyle.Top;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReturn.Image = (Image)resources.GetObject("btnReturn.Image");
            btnReturn.Location = new Point(0, 86);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(333, 43);
            btnReturn.TabIndex = 3;
            btnReturn.Text = "Return";
            btnReturn.TextAlign = ContentAlignment.MiddleLeft;
            btnReturn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnBorrowed
            // 
            btnBorrowed.Dock = DockStyle.Top;
            btnBorrowed.FlatAppearance.BorderSize = 0;
            btnBorrowed.FlatStyle = FlatStyle.Flat;
            btnBorrowed.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBorrowed.Image = (Image)resources.GetObject("btnBorrowed.Image");
            btnBorrowed.Location = new Point(0, 43);
            btnBorrowed.Name = "btnBorrowed";
            btnBorrowed.Size = new Size(333, 43);
            btnBorrowed.TabIndex = 2;
            btnBorrowed.Text = "Borrow";
            btnBorrowed.TextAlign = ContentAlignment.MiddleLeft;
            btnBorrowed.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBorrowed.UseVisualStyleBackColor = true;
            btnBorrowed.Click += btnBorrowed_Click;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(333, 43);
            btnHome.TabIndex = 1;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(emailLbl);
            panel2.Controls.Add(nameLbl);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(12, 9);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 57);
            panel2.TabIndex = 3;
            // 
            // emailLbl
            // 
            emailLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            emailLbl.AutoEllipsis = true;
            emailLbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            emailLbl.ForeColor = Color.Black;
            emailLbl.Location = new Point(47, 25);
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
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.BackColor = Color.Transparent;
            mainPanel.Location = new Point(288, 38);
            mainPanel.Margin = new Padding(0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(710, 520);
            mainPanel.TabIndex = 3;
            // 
            // timerLbl
            // 
            timerLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            timerLbl.AutoSize = true;
            timerLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            timerLbl.Location = new Point(999, 12);
            timerLbl.Name = "timerLbl";
            timerLbl.Size = new Size(209, 15);
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
            // topbar
            // 
            topbar.BackColor = Color.White;
            topbar.Controls.Add(timerLbl);
            topbar.Controls.Add(navLbl);
            topbar.Dock = DockStyle.Top;
            topbar.Location = new Point(288, 0);
            topbar.Name = "topbar";
            topbar.Size = new Size(710, 38);
            topbar.TabIndex = 4;
            // 
            // UserDb
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(998, 558);
            Controls.Add(topbar);
            Controls.Add(mainPanel);
            Controls.Add(panelside);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserDb";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserDb";
            panelside.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            topbar.ResumeLayout(false);
            topbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelside;
        private Panel panel2;
        private Label nameLbl;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label emailLbl;
        private Button btnHome;
        private Button btnReturn;
        private Button btnBorrowed;
        private Button button4;
        private Panel mainPanel;
        private Label timerLbl;
        private Label navLbl;
        private Panel topbar;
    }
}