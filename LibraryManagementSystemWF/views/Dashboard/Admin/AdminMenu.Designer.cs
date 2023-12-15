namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    partial class AdminMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMenu));
            panel1 = new Panel();
            clearBtn = new Button();
            pictureBox1 = new PictureBox();
            btnBack = new Button();
            button1 = new Button();
            btnDeleteBooks = new Button();
            button2 = new Button();
            usersGridList = new DataGridView();
            label3 = new Label();
            textUserID = new TextBox();
            textFirstName = new TextBox();
            label1 = new Label();
            textLastName = new TextBox();
            label2 = new Label();
            textAddress = new TextBox();
            label4 = new Label();
            textEmail = new TextBox();
            label5 = new Label();
            textPhone = new TextBox();
            label6 = new Label();
            textUsername = new TextBox();
            label7 = new Label();
            textPassword = new TextBox();
            label8 = new Label();
            label9 = new Label();
            cmbRole = new ComboBox();
            panel2 = new Panel();
            label10 = new Label();
            button3 = new Button();
            label11 = new Label();
            txtProfile = new TextBox();
            pageLbl = new Label();
            prevBtn = new Button();
            nextBtn = new Button();
            SchoolNum = new TextBox();
            label12 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usersGridList).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 206, 47);
            panel1.Controls.Add(clearBtn);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnDeleteBooks);
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(155, 541);
            panel1.TabIndex = 12;
            // 
            // clearBtn
            // 
            clearBtn.BackColor = Color.WhiteSmoke;
            clearBtn.Cursor = Cursors.Hand;
            clearBtn.FlatAppearance.BorderSize = 2;
            clearBtn.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            clearBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            clearBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            clearBtn.FlatStyle = FlatStyle.Flat;
            clearBtn.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            clearBtn.Image = (Image)resources.GetObject("clearBtn.Image");
            clearBtn.ImageAlign = ContentAlignment.MiddleLeft;
            clearBtn.Location = new Point(0, 127);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(155, 54);
            clearBtn.TabIndex = 43;
            clearBtn.Text = "      CLEAR";
            clearBtn.UseVisualStyleBackColor = false;
            clearBtn.Click += clearBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 372);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 169);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 42;
            pictureBox1.TabStop = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(254, 206, 47);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            btnBack.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.ImageAlign = ContentAlignment.MiddleLeft;
            btnBack.Location = new Point(0, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(155, 53);
            btnBack.TabIndex = 10;
            btnBack.Text = "BACK";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.WhiteSmoke;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 184);
            button1.Name = "button1";
            button1.Size = new Size(155, 54);
            button1.TabIndex = 5;
            button1.Text = "      ADD USER";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnDeleteBooks
            // 
            btnDeleteBooks.BackColor = Color.WhiteSmoke;
            btnDeleteBooks.Cursor = Cursors.Hand;
            btnDeleteBooks.FlatAppearance.BorderSize = 2;
            btnDeleteBooks.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            btnDeleteBooks.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            btnDeleteBooks.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            btnDeleteBooks.FlatStyle = FlatStyle.Flat;
            btnDeleteBooks.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteBooks.Image = (Image)resources.GetObject("btnDeleteBooks.Image");
            btnDeleteBooks.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteBooks.Location = new Point(-1, 296);
            btnDeleteBooks.Name = "btnDeleteBooks";
            btnDeleteBooks.Size = new Size(156, 54);
            btnDeleteBooks.TabIndex = 9;
            btnDeleteBooks.Text = "      DELETE USER";
            btnDeleteBooks.UseVisualStyleBackColor = false;
            btnDeleteBooks.Click += btnDeleteBooks_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.WhiteSmoke;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 240);
            button2.Name = "button2";
            button2.Size = new Size(155, 54);
            button2.TabIndex = 6;
            button2.Text = "       UPDATE USER";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // usersGridList
            // 
            usersGridList.AllowUserToAddRows = false;
            usersGridList.AllowUserToDeleteRows = false;
            usersGridList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersGridList.BackgroundColor = Color.WhiteSmoke;
            usersGridList.BorderStyle = BorderStyle.None;
            usersGridList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            usersGridList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersGridList.Dock = DockStyle.Top;
            usersGridList.GridColor = Color.Black;
            usersGridList.Location = new Point(155, 0);
            usersGridList.MultiSelect = false;
            usersGridList.Name = "usersGridList";
            usersGridList.ReadOnly = true;
            usersGridList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            usersGridList.RowTemplate.Height = 25;
            usersGridList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usersGridList.Size = new Size(946, 170);
            usersGridList.TabIndex = 13;
            usersGridList.CellClick += usersList_CellClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(174, 193);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(52, 17);
            label3.TabIndex = 19;
            label3.Text = "User ID";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textUserID
            // 
            textUserID.BackColor = SystemColors.Control;
            textUserID.Enabled = false;
            textUserID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textUserID.ForeColor = SystemColors.MenuText;
            textUserID.Location = new Point(176, 213);
            textUserID.Name = "textUserID";
            textUserID.PlaceholderText = "Not required in ADD MODE";
            textUserID.ReadOnly = true;
            textUserID.Size = new Size(280, 29);
            textUserID.TabIndex = 20;
            // 
            // textFirstName
            // 
            textFirstName.BackColor = Color.White;
            textFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textFirstName.ForeColor = SystemColors.MenuText;
            textFirstName.Location = new Point(178, 326);
            textFirstName.Name = "textFirstName";
            textFirstName.PlaceholderText = "Juan";
            textFirstName.Size = new Size(280, 29);
            textFirstName.TabIndex = 22;
            textFirstName.TextChanged += text_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(176, 306);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(74, 17);
            label1.TabIndex = 21;
            label1.Text = "First Name";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textLastName
            // 
            textLastName.BackColor = Color.White;
            textLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textLastName.ForeColor = SystemColors.MenuText;
            textLastName.Location = new Point(493, 326);
            textLastName.Name = "textLastName";
            textLastName.PlaceholderText = "Dela Cruz";
            textLastName.Size = new Size(280, 29);
            textLastName.TabIndex = 24;
            textLastName.TextChanged += text_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(493, 306);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(72, 17);
            label2.TabIndex = 23;
            label2.Text = "Last Name";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textAddress
            // 
            textAddress.BackColor = Color.White;
            textAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textAddress.ForeColor = SystemColors.MenuText;
            textAddress.Location = new Point(178, 380);
            textAddress.Name = "textAddress";
            textAddress.PlaceholderText = "112 Baker Street";
            textAddress.Size = new Size(595, 29);
            textAddress.TabIndex = 26;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(176, 360);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(57, 17);
            label4.TabIndex = 25;
            label4.Text = "Address";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textEmail
            // 
            textEmail.BackColor = Color.White;
            textEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textEmail.ForeColor = SystemColors.MenuText;
            textEmail.Location = new Point(178, 437);
            textEmail.Name = "textEmail";
            textEmail.PlaceholderText = "juan@yahoo.com";
            textEmail.Size = new Size(280, 29);
            textEmail.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(176, 417);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(40, 17);
            label5.TabIndex = 27;
            label5.Text = "Email";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textPhone
            // 
            textPhone.BackColor = Color.White;
            textPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textPhone.ForeColor = SystemColors.MenuText;
            textPhone.Location = new Point(493, 437);
            textPhone.MaxLength = 11;
            textPhone.Name = "textPhone";
            textPhone.PlaceholderText = "09100813695";
            textPhone.Size = new Size(280, 29);
            textPhone.TabIndex = 30;
            textPhone.KeyPress += textPhone_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(493, 417);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(47, 17);
            label6.TabIndex = 29;
            label6.Text = "Phone";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textUsername
            // 
            textUsername.BackColor = Color.White;
            textUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textUsername.ForeColor = SystemColors.MenuText;
            textUsername.Location = new Point(178, 495);
            textUsername.Name = "textUsername";
            textUsername.PlaceholderText = "johndoe";
            textUsername.Size = new Size(280, 29);
            textUsername.TabIndex = 32;
            textUsername.TextChanged += text_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(176, 475);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(69, 17);
            label7.TabIndex = 31;
            label7.Text = "Username";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textPassword
            // 
            textPassword.BackColor = Color.White;
            textPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textPassword.ForeColor = SystemColors.MenuText;
            textPassword.Location = new Point(493, 495);
            textPassword.Name = "textPassword";
            textPassword.PlaceholderText = "******";
            textPassword.Size = new Size(280, 29);
            textPassword.TabIndex = 34;
            textPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(493, 475);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(66, 17);
            label8.TabIndex = 33;
            label8.Text = "Password";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(484, 193);
            label9.Margin = new Padding(0);
            label9.Name = "label9";
            label9.Size = new Size(34, 17);
            label9.TabIndex = 36;
            label9.Text = "Role";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbRole
            // 
            cmbRole.BackColor = SystemColors.Control;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(486, 213);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(280, 29);
            cmbRole.TabIndex = 35;
            cmbRole.TextChanged += text_TextChanged;
            // 
            // panel2
            // 
            panel2.Location = new Point(807, 213);
            panel2.Name = "panel2";
            panel2.Size = new Size(271, 126);
            panel2.TabIndex = 37;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(804, 193);
            label10.Margin = new Padding(0);
            label10.Name = "label10";
            label10.Size = new Size(55, 17);
            label10.TabIndex = 38;
            label10.Text = "Preview";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(254, 206, 47);
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(1032, 380);
            button3.Name = "button3";
            button3.Size = new Size(52, 29);
            button3.TabIndex = 41;
            button3.Text = "find";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(801, 360);
            label11.Margin = new Padding(0);
            label11.Name = "label11";
            label11.Size = new Size(92, 17);
            label11.TabIndex = 40;
            label11.Text = "Profile Picture";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtProfile
            // 
            txtProfile.Enabled = false;
            txtProfile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtProfile.Location = new Point(804, 380);
            txtProfile.Name = "txtProfile";
            txtProfile.PlaceholderText = "C://Images/profile.png";
            txtProfile.ReadOnly = true;
            txtProfile.Size = new Size(222, 29);
            txtProfile.TabIndex = 39;
            txtProfile.TextChanged += text_TextChanged;
            // 
            // pageLbl
            // 
            pageLbl.AutoSize = true;
            pageLbl.Location = new Point(1036, 178);
            pageLbl.Name = "pageLbl";
            pageLbl.Size = new Size(28, 15);
            pageLbl.TabIndex = 42;
            pageLbl.Text = "1 | 1";
            // 
            // prevBtn
            // 
            prevBtn.BackColor = Color.FromArgb(254, 206, 47);
            prevBtn.Cursor = Cursors.Hand;
            prevBtn.FlatStyle = FlatStyle.Flat;
            prevBtn.Location = new Point(1006, 173);
            prevBtn.Name = "prevBtn";
            prevBtn.Size = new Size(24, 24);
            prevBtn.TabIndex = 43;
            prevBtn.Text = "<";
            prevBtn.UseVisualStyleBackColor = false;
            prevBtn.Click += prevBtn_Click;
            // 
            // nextBtn
            // 
            nextBtn.BackColor = Color.FromArgb(254, 206, 47);
            nextBtn.Cursor = Cursors.Hand;
            nextBtn.FlatStyle = FlatStyle.Flat;
            nextBtn.Location = new Point(1070, 173);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(24, 24);
            nextBtn.TabIndex = 44;
            nextBtn.Text = ">";
            nextBtn.UseVisualStyleBackColor = false;
            nextBtn.Click += nextBtn_Click;
            // 
            // SchoolNum
            // 
            SchoolNum.BackColor = Color.White;
            SchoolNum.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SchoolNum.ForeColor = SystemColors.MenuText;
            SchoolNum.Location = new Point(178, 274);
            SchoolNum.Name = "SchoolNum";
            SchoolNum.PlaceholderText = "01234";
            SchoolNum.Size = new Size(595, 29);
            SchoolNum.TabIndex = 45;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(178, 254);
            label12.Margin = new Padding(0);
            label12.Name = "label12";
            label12.Size = new Size(102, 17);
            label12.TabIndex = 46;
            label12.Text = "School Number";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1101, 541);
            Controls.Add(label12);
            Controls.Add(SchoolNum);
            Controls.Add(nextBtn);
            Controls.Add(prevBtn);
            Controls.Add(pageLbl);
            Controls.Add(button3);
            Controls.Add(label11);
            Controls.Add(txtProfile);
            Controls.Add(label10);
            Controls.Add(panel2);
            Controls.Add(label9);
            Controls.Add(cmbRole);
            Controls.Add(textPassword);
            Controls.Add(label8);
            Controls.Add(textUsername);
            Controls.Add(label7);
            Controls.Add(textPhone);
            Controls.Add(label6);
            Controls.Add(textEmail);
            Controls.Add(label5);
            Controls.Add(textAddress);
            Controls.Add(label4);
            Controls.Add(textLastName);
            Controls.Add(label2);
            Controls.Add(textFirstName);
            Controls.Add(label1);
            Controls.Add(textUserID);
            Controls.Add(label3);
            Controls.Add(usersGridList);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminMenu";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)usersGridList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnBack;
        private Button button1;
        private Button btnDeleteBooks;
        private Button button2;
        private DataGridView usersGridList;
        private Label label3;
        private TextBox textUserID;
        private TextBox textFirstName;
        private Label label1;
        private TextBox textLastName;
        private Label label2;
        private TextBox textAddress;
        private Label label4;
        private TextBox textEmail;
        private Label label5;
        private TextBox textPhone;
        private Label label6;
        private TextBox textUsername;
        private Label label7;
        private TextBox textPassword;
        private Label label8;
        private Label label9;
        private ComboBox cmbRole;
        private Panel panel2;
        private Label label10;
        private Button button3;
        private Label label11;
        private TextBox txtProfile;
        private PictureBox pictureBox1;
        private Button clearBtn;
        private Label pageLbl;
        private Button prevBtn;
        private Button nextBtn;
        private TextBox SchoolNum;
        private Label label12;
    }
}