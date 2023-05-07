namespace LibraryManagementSystemWF.views
{
    partial class SignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            button1 = new Button();
            button2 = new Button();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            panel1 = new Panel();
            btnMini = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(300, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 97);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(313, 127);
            label1.Name = "label1";
            label1.Size = new Size(96, 32);
            label1.TabIndex = 1;
            label1.Text = "LOG IN";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(211, 187);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "USERNAME";
            txtUsername.Size = new Size(291, 33);
            txtUsername.TabIndex = 3;
            txtUsername.TextAlign = HorizontalAlignment.Center;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(211, 234);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "PASSWORD";
            txtPassword.Size = new Size(291, 33);
            txtPassword.TabIndex = 4;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.BackColor = Color.DimGray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(368, 283);
            button1.Name = "button1";
            button1.Size = new Size(134, 34);
            button1.TabIndex = 10;
            button1.Text = "REGISTER";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DimGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(211, 283);
            button2.Name = "button2";
            button2.Size = new Size(134, 34);
            button2.TabIndex = 11;
            button2.Text = "LOG IN";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(255, 192, 128);
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-2, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(197, 318);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(241, 159);
            label2.Name = "label2";
            label2.Size = new Size(245, 17);
            label2.TabIndex = 13;
            label2.Text = "Welcome! Please login to your account";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(btnMini);
            panel1.Controls.Add(btnClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(519, 23);
            panel1.TabIndex = 14;
            // 
            // btnMini
            // 
            btnMini.BackColor = Color.LightGray;
            btnMini.BackgroundImage = (Image)resources.GetObject("btnMini.BackgroundImage");
            btnMini.BackgroundImageLayout = ImageLayout.Zoom;
            btnMini.Dock = DockStyle.Right;
            btnMini.Location = new Point(459, 0);
            btnMini.Name = "btnMini";
            btnMini.Size = new Size(30, 23);
            btnMini.TabIndex = 2;
            btnMini.UseVisualStyleBackColor = false;
            btnMini.Click += button5_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.LightGray;
            btnClose.BackgroundImage = (Image)resources.GetObject("btnClose.BackgroundImage");
            btnClose.BackgroundImageLayout = ImageLayout.Zoom;
            btnClose.Dock = DockStyle.Right;
            btnClose.Location = new Point(489, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 23);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += button3_Click;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(519, 329);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SignIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignIn";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox2;
        private Label label2;
        private Panel panel1;
        private Button btnMini;
        private Button btnClose;
    }
}