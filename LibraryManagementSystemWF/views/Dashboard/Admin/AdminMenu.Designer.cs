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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeleteBooks = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.usersGridList = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textUserID = new System.Windows.Forms.TextBox();
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnDeleteBooks);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 556);
            this.panel1.TabIndex = 12;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(155, 53);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "      ADD USER";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeleteBooks
            // 
            this.btnDeleteBooks.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeleteBooks.FlatAppearance.BorderSize = 2;
            this.btnDeleteBooks.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteBooks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteBooks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBooks.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteBooks.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteBooks.Image")));
            this.btnDeleteBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteBooks.Location = new System.Drawing.Point(-1, 296);
            this.btnDeleteBooks.Name = "btnDeleteBooks";
            this.btnDeleteBooks.Size = new System.Drawing.Size(156, 54);
            this.btnDeleteBooks.TabIndex = 9;
            this.btnDeleteBooks.Text = "      DELETE USER";
            this.btnDeleteBooks.UseVisualStyleBackColor = false;
            this.btnDeleteBooks.Click += new System.EventHandler(this.btnDeleteBooks_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 54);
            this.button2.TabIndex = 6;
            this.button2.Text = "       UPDATE USER";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // usersGridList
            // 
            this.usersGridList.BackgroundColor = System.Drawing.Color.White;
            this.usersGridList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usersGridList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.usersGridList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridList.Dock = System.Windows.Forms.DockStyle.Top;
            this.usersGridList.GridColor = System.Drawing.Color.Black;
            this.usersGridList.Location = new System.Drawing.Point(155, 0);
            this.usersGridList.Name = "usersGridList";
            this.usersGridList.RowTemplate.Height = 25;
            this.usersGridList.Size = new System.Drawing.Size(628, 170);
            this.usersGridList.TabIndex = 13;
            this.usersGridList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.usersList_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(174, 193);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "User ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textUserID
            // 
            this.textUserID.BackColor = System.Drawing.Color.White;
            this.textUserID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textUserID.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textUserID.Location = new System.Drawing.Point(176, 213);
            this.textUserID.Name = "textUserID";
            this.textUserID.PlaceholderText = "Not required in ADD MODE";
            this.textUserID.Size = new System.Drawing.Size(280, 29);
            this.textUserID.TabIndex = 20;
            // 
            // textFirstName
            // 
            this.textFirstName.BackColor = System.Drawing.Color.White;
            this.textFirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textFirstName.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textFirstName.Location = new System.Drawing.Point(176, 278);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.PlaceholderText = "Juan";
            this.textFirstName.Size = new System.Drawing.Size(280, 29);
            this.textFirstName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(174, 258);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "First Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textLastName
            // 
            this.textLastName.BackColor = System.Drawing.Color.White;
            this.textLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textLastName.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textLastName.Location = new System.Drawing.Point(486, 278);
            this.textLastName.Name = "textLastName";
            this.textLastName.PlaceholderText = "Dela Cruz";
            this.textLastName.Size = new System.Drawing.Size(280, 29);
            this.textLastName.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(484, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Last Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textAddress
            // 
            this.textAddress.BackColor = System.Drawing.Color.White;
            this.textAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textAddress.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textAddress.Location = new System.Drawing.Point(176, 348);
            this.textAddress.Name = "textAddress";
            this.textAddress.PlaceholderText = "112 Baker Street";
            this.textAddress.Size = new System.Drawing.Size(595, 29);
            this.textAddress.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(174, 328);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Address";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textEmail
            // 
            this.textEmail.BackColor = System.Drawing.Color.White;
            this.textEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textEmail.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textEmail.Location = new System.Drawing.Point(176, 412);
            this.textEmail.Name = "textEmail";
            this.textEmail.PlaceholderText = "juan@yahoo.com";
            this.textEmail.Size = new System.Drawing.Size(280, 29);
            this.textEmail.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(174, 392);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Email";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textPhone
            // 
            this.textPhone.BackColor = System.Drawing.Color.White;
            this.textPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPhone.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textPhone.Location = new System.Drawing.Point(486, 412);
            this.textPhone.Name = "textPhone";
            this.textPhone.PlaceholderText = "09100813695";
            this.textPhone.Size = new System.Drawing.Size(280, 29);
            this.textPhone.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(484, 392);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Phone";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textUsername
            // 
            this.textUsername.BackColor = System.Drawing.Color.White;
            this.textUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textUsername.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textUsername.Location = new System.Drawing.Point(176, 480);
            this.textUsername.Name = "textUsername";
            this.textUsername.PlaceholderText = "johndoe";
            this.textUsername.Size = new System.Drawing.Size(280, 29);
            this.textUsername.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(174, 460);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 31;
            this.label7.Text = "Username";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textPassword
            // 
            this.textPassword.BackColor = System.Drawing.Color.White;
            this.textPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPassword.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textPassword.Location = new System.Drawing.Point(486, 480);
            this.textPassword.Name = "textPassword";
            this.textPassword.PlaceholderText = "******";
            this.textPassword.Size = new System.Drawing.Size(280, 29);
            this.textPassword.TabIndex = 34;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(484, 460);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Password";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(484, 193);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "Role";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbRole
            // 
            this.cmbRole.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(486, 213);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(280, 29);
            this.cmbRole.TabIndex = 35;
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(783, 556);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textUserID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usersGridList);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMenu";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersGridList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}