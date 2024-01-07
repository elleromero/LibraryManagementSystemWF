namespace LibraryManagementSystemWF.views
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            label1 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtRegUser = new TextBox();
            txtRegPass = new TextBox();
            button2 = new Button();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button3 = new Button();
            label8 = new Label();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            txtProfile = new TextBox();
            button1 = new Button();
            label10 = new Label();
            schoolNum = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(279, 25);
            label1.Name = "label1";
            label1.Size = new Size(180, 30);
            label1.TabIndex = 1;
            label1.Text = "Register Account";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFirstName.Location = new Point(282, 156);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(231, 29);
            txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtLastName.Location = new Point(519, 156);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(279, 29);
            txtLastName.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAddress.Location = new Point(282, 215);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(516, 29);
            txtAddress.TabIndex = 4;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPhone.Location = new Point(282, 275);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(231, 29);
            txtPhone.TabIndex = 5;
            txtPhone.KeyPress += txtPhone_KeyPress;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(519, 275);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(279, 29);
            txtEmail.TabIndex = 6;
            // 
            // txtRegUser
            // 
            txtRegUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRegUser.Location = new Point(282, 338);
            txtRegUser.Name = "txtRegUser";
            txtRegUser.Size = new Size(231, 29);
            txtRegUser.TabIndex = 7;
            // 
            // txtRegPass
            // 
            txtRegPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRegPass.Location = new Point(519, 338);
            txtRegPass.MaxLength = 11;
            txtRegPass.Name = "txtRegPass";
            txtRegPass.Size = new Size(279, 29);
            txtRegPass.TabIndex = 8;
            txtRegPass.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(254, 206, 47);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(958, 27);
            button2.Name = "button2";
            button2.Size = new Size(34, 34);
            button2.TabIndex = 10;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-2, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(250, 420);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(282, 55);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(96, 17);
            label2.TabIndex = 14;
            label2.Text = "It's always free";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(279, 136);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(74, 17);
            label3.TabIndex = 17;
            label3.Text = "First Name";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(517, 136);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(72, 17);
            label4.TabIndex = 18;
            label4.Text = "Last Name";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(281, 195);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(57, 17);
            label5.TabIndex = 19;
            label5.Text = "Address";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(280, 255);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(101, 17);
            label6.TabIndex = 20;
            label6.Text = "Phone Number";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(516, 255);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(40, 17);
            label7.TabIndex = 21;
            label7.Text = "Email";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(254, 206, 47);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(282, 378);
            button3.Name = "button3";
            button3.Size = new Size(154, 34);
            button3.TabIndex = 22;
            button3.Text = "Create an account";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(279, 318);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(69, 17);
            label8.TabIndex = 23;
            label8.Text = "Username";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(516, 318);
            label9.Margin = new Padding(0);
            label9.Name = "label9";
            label9.Size = new Size(66, 17);
            label9.TabIndex = 24;
            label9.Text = "Password";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(825, 93);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // txtProfile
            // 
            txtProfile.Enabled = false;
            txtProfile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtProfile.Location = new Point(825, 200);
            txtProfile.Name = "txtProfile";
            txtProfile.PlaceholderText = "C://Images/profile-picture.png";
            txtProfile.ReadOnly = true;
            txtProfile.Size = new Size(167, 29);
            txtProfile.TabIndex = 26;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(254, 206, 47);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(945, 126);
            button1.Name = "button1";
            button1.Size = new Size(34, 34);
            button1.TabIndex = 27;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(282, 80);
            label10.Margin = new Padding(0);
            label10.Name = "label10";
            label10.Size = new Size(102, 17);
            label10.TabIndex = 28;
            label10.Text = "School Number";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // schoolNum
            // 
            schoolNum.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            schoolNum.Location = new Point(282, 100);
            schoolNum.Name = "schoolNum";
            schoolNum.Size = new Size(516, 29);
            schoolNum.TabIndex = 29;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1021, 420);
            Controls.Add(schoolNum);
            Controls.Add(label10);
            Controls.Add(button1);
            Controls.Add(txtProfile);
            Controls.Add(pictureBox1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(button3);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(button2);
            Controls.Add(txtRegPass);
            Controls.Add(txtRegUser);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtRegUser;
        private TextBox txtRegPass;
        private Button button2;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button3;
        private Label label8;
        private Label label9;
        private PictureBox pictureBox1;
        private TextBox txtProfile;
        private Button button1;
        private Label label10;
        private TextBox schoolNum;
    }
}