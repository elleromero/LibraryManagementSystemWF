namespace LibraryManagementSystemWF.views.Dashboard
{
    partial class AnnouncementPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnouncementPreview));
            this.rtbBody = new System.Windows.Forms.RichTextBox();
            this.headerLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.coverPictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.announcedByLbl = new System.Windows.Forms.Label();
            this.announcedOnLbl = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbBody
            // 
            this.rtbBody.BackColor = System.Drawing.Color.White;
            this.rtbBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbBody.Location = new System.Drawing.Point(12, 170);
            this.rtbBody.Name = "rtbBody";
            this.rtbBody.ReadOnly = true;
            this.rtbBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbBody.ShortcutsEnabled = false;
            this.rtbBody.Size = new System.Drawing.Size(864, 289);
            this.rtbBody.TabIndex = 0;
            this.rtbBody.Text = "Empty announcement";
            // 
            // headerLbl
            // 
            this.headerLbl.AutoEllipsis = true;
            this.headerLbl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLbl.Location = new System.Drawing.Point(12, 135);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(864, 32);
            this.headerLbl.TabIndex = 1;
            this.headerLbl.Text = "Header";
            this.headerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Announced By: ";
            // 
            // coverPictureBox
            // 
            this.coverPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("coverPictureBox.Image")));
            this.coverPictureBox.Location = new System.Drawing.Point(12, 12);
            this.coverPictureBox.Name = "coverPictureBox";
            this.coverPictureBox.Size = new System.Drawing.Size(864, 120);
            this.coverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.coverPictureBox.TabIndex = 3;
            this.coverPictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 498);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Announced On";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // announcedByLbl
            // 
            this.announcedByLbl.AutoSize = true;
            this.announcedByLbl.Location = new System.Drawing.Point(109, 471);
            this.announcedByLbl.Name = "announcedByLbl";
            this.announcedByLbl.Size = new System.Drawing.Size(201, 15);
            this.announcedByLbl.TabIndex = 5;
            this.announcedByLbl.Text = "John Doe (admin) - ADMINISTRATOR";
            // 
            // announcedOnLbl
            // 
            this.announcedOnLbl.AutoSize = true;
            this.announcedOnLbl.Location = new System.Drawing.Point(109, 498);
            this.announcedOnLbl.Name = "announcedOnLbl";
            this.announcedOnLbl.Size = new System.Drawing.Size(128, 15);
            this.announcedOnLbl.TabIndex = 6;
            this.announcedOnLbl.Text = "Monday. Sept. 12, 2023";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(826, 498);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(50, 15);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Go Back";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // AnnouncementPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(888, 522);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.announcedOnLbl);
            this.Controls.Add(this.announcedByLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.coverPictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.headerLbl);
            this.Controls.Add(this.rtbBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnnouncementPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnnouncementPreview";
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox rtbBody;
        private Label headerLbl;
        private Label label2;
        private PictureBox coverPictureBox;
        private Label label3;
        private Label announcedByLbl;
        private Label announcedOnLbl;
        private LinkLabel linkLabel2;
    }
}