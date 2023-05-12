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
            pictureBox1 = new PictureBox();
            btnBorrow = new Button();
            btnDash = new Button();
            btnRes = new Button();
            btnBooks = new Button();
            panelheader = new Panel();
            mainpanel = new Panel();
            panelside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelside
            // 
            panelside.BackColor = Color.DimGray;
            panelside.Controls.Add(pictureBox1);
            panelside.Controls.Add(btnBorrow);
            panelside.Controls.Add(btnDash);
            panelside.Controls.Add(btnRes);
            panelside.Controls.Add(btnBooks);
            panelside.Dock = DockStyle.Left;
            panelside.Location = new Point(0, 30);
            panelside.Name = "panelside";
            panelside.Size = new Size(200, 420);
            panelside.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(39, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(118, 111);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnBorrow
            // 
            btnBorrow.BackColor = Color.DimGray;
            btnBorrow.BackgroundImageLayout = ImageLayout.Zoom;
            btnBorrow.FlatAppearance.BorderSize = 0;
            btnBorrow.FlatStyle = FlatStyle.Flat;
            btnBorrow.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBorrow.ForeColor = Color.White;
            btnBorrow.Image = (Image)resources.GetObject("btnBorrow.Image");
            btnBorrow.ImageAlign = ContentAlignment.MiddleLeft;
            btnBorrow.Location = new Point(0, 265);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(200, 30);
            btnBorrow.TabIndex = 3;
            btnBorrow.Text = "BORROWED";
            btnBorrow.UseVisualStyleBackColor = false;
            btnBorrow.Click += btnBorrow_Click;
            // 
            // btnDash
            // 
            btnDash.BackColor = Color.DimGray;
            btnDash.BackgroundImageLayout = ImageLayout.Zoom;
            btnDash.FlatAppearance.BorderSize = 0;
            btnDash.FlatStyle = FlatStyle.Flat;
            btnDash.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDash.ForeColor = Color.White;
            btnDash.Image = (Image)resources.GetObject("btnDash.Image");
            btnDash.ImageAlign = ContentAlignment.MiddleLeft;
            btnDash.Location = new Point(0, 157);
            btnDash.Name = "btnDash";
            btnDash.Size = new Size(200, 30);
            btnDash.TabIndex = 0;
            btnDash.Text = "DASHBOARD";
            btnDash.UseVisualStyleBackColor = false;
            btnDash.Click += btnDash_Click;
            // 
            // btnRes
            // 
            btnRes.BackColor = Color.DimGray;
            btnRes.BackgroundImageLayout = ImageLayout.Zoom;
            btnRes.FlatAppearance.BorderSize = 0;
            btnRes.FlatStyle = FlatStyle.Flat;
            btnRes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRes.ForeColor = Color.White;
            btnRes.Image = (Image)resources.GetObject("btnRes.Image");
            btnRes.ImageAlign = ContentAlignment.MiddleLeft;
            btnRes.Location = new Point(0, 229);
            btnRes.Name = "btnRes";
            btnRes.Size = new Size(200, 30);
            btnRes.TabIndex = 2;
            btnRes.Text = "RESERVE";
            btnRes.UseVisualStyleBackColor = false;
            btnRes.Click += btnRes_Click;
            // 
            // btnBooks
            // 
            btnBooks.BackColor = Color.DimGray;
            btnBooks.BackgroundImageLayout = ImageLayout.Zoom;
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBooks.ForeColor = Color.White;
            btnBooks.Image = (Image)resources.GetObject("btnBooks.Image");
            btnBooks.ImageAlign = ContentAlignment.MiddleLeft;
            btnBooks.Location = new Point(0, 193);
            btnBooks.Name = "btnBooks";
            btnBooks.Size = new Size(200, 30);
            btnBooks.TabIndex = 1;
            btnBooks.Text = "BOOKS";
            btnBooks.UseVisualStyleBackColor = false;
            btnBooks.Click += btnBooks_Click;
            // 
            // panelheader
            // 
            panelheader.BackColor = Color.Gray;
            panelheader.Dock = DockStyle.Top;
            panelheader.Location = new Point(0, 0);
            panelheader.Name = "panelheader";
            panelheader.Size = new Size(800, 30);
            panelheader.TabIndex = 1;
            // 
            // mainpanel
            // 
            mainpanel.Dock = DockStyle.Fill;
            mainpanel.Location = new Point(200, 30);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(600, 420);
            mainpanel.TabIndex = 2;
            // 
            // UserDb
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(mainpanel);
            Controls.Add(panelside);
            Controls.Add(panelheader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserDb";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserDb";
            panelside.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelside;
        private Panel panelheader;
        private PictureBox pictureBox1;
        private Button btnBorrow;
        private Button btnDash;
        private Button btnRes;
        private Button btnBooks;
        private Panel mainpanel;
    }
}