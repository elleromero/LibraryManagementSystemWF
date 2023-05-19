namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    partial class BookInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookInformation));
            this.coverPictureBox = new System.Windows.Forms.PictureBox();
            this.bookCoverPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLbl = new System.Windows.Forms.Label();
            this.authorLbl = new System.Windows.Forms.Label();
            this.datePublishedLbl = new System.Windows.Forms.Label();
            this.txtSypnosis = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.publisherLbl = new System.Windows.Forms.Label();
            this.isbnLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.genreLbl = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookCoverPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // coverPictureBox
            // 
            this.coverPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.coverPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("coverPictureBox.Image")));
            this.coverPictureBox.Location = new System.Drawing.Point(0, 0);
            this.coverPictureBox.Name = "coverPictureBox";
            this.coverPictureBox.Size = new System.Drawing.Size(633, 116);
            this.coverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.coverPictureBox.TabIndex = 0;
            this.coverPictureBox.TabStop = false;
            // 
            // bookCoverPictureBox
            // 
            this.bookCoverPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("bookCoverPictureBox.Image")));
            this.bookCoverPictureBox.Location = new System.Drawing.Point(4, 4);
            this.bookCoverPictureBox.Name = "bookCoverPictureBox";
            this.bookCoverPictureBox.Size = new System.Drawing.Size(100, 161);
            this.bookCoverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bookCoverPictureBox.TabIndex = 1;
            this.bookCoverPictureBox.TabStop = false;
            // 
            // titleLbl
            // 
            this.titleLbl.AutoEllipsis = true;
            this.titleLbl.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLbl.Location = new System.Drawing.Point(139, 130);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(472, 38);
            this.titleLbl.TabIndex = 2;
            this.titleLbl.Text = "Book Title";
            this.titleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // authorLbl
            // 
            this.authorLbl.AutoSize = true;
            this.authorLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.authorLbl.Location = new System.Drawing.Point(142, 169);
            this.authorLbl.Name = "authorLbl";
            this.authorLbl.Size = new System.Drawing.Size(91, 17);
            this.authorLbl.TabIndex = 3;
            this.authorLbl.Text = "Author Name";
            this.authorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datePublishedLbl
            // 
            this.datePublishedLbl.AutoSize = true;
            this.datePublishedLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.datePublishedLbl.ForeColor = System.Drawing.Color.Gray;
            this.datePublishedLbl.Location = new System.Drawing.Point(142, 196);
            this.datePublishedLbl.Name = "datePublishedLbl";
            this.datePublishedLbl.Size = new System.Drawing.Size(89, 17);
            this.datePublishedLbl.TabIndex = 4;
            this.datePublishedLbl.Text = "Published On";
            this.datePublishedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSypnosis
            // 
            this.txtSypnosis.BackColor = System.Drawing.Color.White;
            this.txtSypnosis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSypnosis.Enabled = false;
            this.txtSypnosis.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSypnosis.ForeColor = System.Drawing.Color.Black;
            this.txtSypnosis.Location = new System.Drawing.Point(23, 251);
            this.txtSypnosis.Multiline = true;
            this.txtSypnosis.Name = "txtSypnosis";
            this.txtSypnosis.ReadOnly = true;
            this.txtSypnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSypnosis.Size = new System.Drawing.Size(588, 205);
            this.txtSypnosis.TabIndex = 5;
            this.txtSypnosis.Text = "No sypnosis available";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(23, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Publisher";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // publisherLbl
            // 
            this.publisherLbl.AutoSize = true;
            this.publisherLbl.Location = new System.Drawing.Point(23, 496);
            this.publisherLbl.Name = "publisherLbl";
            this.publisherLbl.Size = new System.Drawing.Size(56, 15);
            this.publisherLbl.TabIndex = 7;
            this.publisherLbl.Text = "Agila Inc.";
            this.publisherLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // isbnLbl
            // 
            this.isbnLbl.AutoSize = true;
            this.isbnLbl.Location = new System.Drawing.Point(23, 551);
            this.isbnLbl.Name = "isbnLbl";
            this.isbnLbl.Size = new System.Drawing.Size(76, 15);
            this.isbnLbl.TabIndex = 9;
            this.isbnLbl.Text = "0-0000-000-0";
            this.isbnLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(23, 526);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "ISBN";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bookCoverPictureBox);
            this.panel1.Location = new System.Drawing.Point(26, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 170);
            this.panel1.TabIndex = 10;
            // 
            // genreLbl
            // 
            this.genreLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.genreLbl.AutoEllipsis = true;
            this.genreLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.genreLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.genreLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.genreLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.genreLbl.ForeColor = System.Drawing.Color.Black;
            this.genreLbl.Location = new System.Drawing.Point(485, 12);
            this.genreLbl.Name = "genreLbl";
            this.genreLbl.Size = new System.Drawing.Size(126, 27);
            this.genreLbl.TabIndex = 12;
            this.genreLbl.Text = "Fantasy";
            this.genreLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button11.Location = new System.Drawing.Point(26, 12);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(63, 27);
            this.button11.TabIndex = 14;
            this.button11.Text = "Back";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // BookInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 585);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.genreLbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.isbnLbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.publisherLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSypnosis);
            this.Controls.Add(this.datePublishedLbl);
            this.Controls.Add(this.authorLbl);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.coverPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookInformation";
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookCoverPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox coverPictureBox;
        private PictureBox bookCoverPictureBox;
        private Label titleLbl;
        private Label authorLbl;
        private Label datePublishedLbl;
        private TextBox txtSypnosis;
        private Label label4;
        private Label publisherLbl;
        private Label isbnLbl;
        private Label label7;
        private Panel panel1;
        private Label genreLbl;
        private Button button11;
    }
}