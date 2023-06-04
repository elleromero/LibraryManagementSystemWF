namespace LibraryManagementSystemWF.views.components
{
    partial class BookBorrowContainer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookBorrowContainer));
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.borrowBtn = new System.Windows.Forms.Button();
            this.viewMoreBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCover.Image")));
            this.pictureBoxCover.Location = new System.Drawing.Point(3, 4);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(100, 174);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 0;
            this.pictureBoxCover.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(109, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(195, 23);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Book Title";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoEllipsis = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAuthor.ForeColor = System.Drawing.Color.Gray;
            this.lblAuthor.Location = new System.Drawing.Point(109, 35);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(195, 23);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author Name";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(109, 61);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(195, 90);
            this.txtDescription.TabIndex = 3;
            // 
            // borrowBtn
            // 
            this.borrowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.borrowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borrowBtn.Location = new System.Drawing.Point(229, 155);
            this.borrowBtn.Name = "borrowBtn";
            this.borrowBtn.Size = new System.Drawing.Size(75, 23);
            this.borrowBtn.TabIndex = 4;
            this.borrowBtn.Text = "Borrow";
            this.borrowBtn.UseVisualStyleBackColor = false;
            this.borrowBtn.Click += new System.EventHandler(this.borrowBtn_Click);
            // 
            // viewMoreBtn
            // 
            this.viewMoreBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.viewMoreBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewMoreBtn.Location = new System.Drawing.Point(143, 155);
            this.viewMoreBtn.Name = "viewMoreBtn";
            this.viewMoreBtn.Size = new System.Drawing.Size(80, 23);
            this.viewMoreBtn.TabIndex = 5;
            this.viewMoreBtn.Text = "View More";
            this.viewMoreBtn.UseVisualStyleBackColor = false;
            this.viewMoreBtn.Click += new System.EventHandler(this.viewMoreBtn_Click);
            // 
            // BookBorrowContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewMoreBtn);
            this.Controls.Add(this.borrowBtn);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBoxCover);
            this.Name = "BookBorrowContainer";
            this.Size = new System.Drawing.Size(312, 183);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxCover;
        private Label lblTitle;
        private Label lblAuthor;
        private TextBox txtDescription;
        private Button borrowBtn;
        private Button viewMoreBtn;
    }
}
