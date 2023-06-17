namespace LibraryManagementSystemWF.views.components
{
    partial class AnnouncementFullContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnouncementFullContainer));
            titleLbl = new Label();
            subtitleLbl = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoEllipsis = true;
            titleLbl.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            titleLbl.Location = new Point(3, 72);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(200, 20);
            titleLbl.TabIndex = 2;
            titleLbl.Text = "Important Announcement";
            titleLbl.TextAlign = ContentAlignment.MiddleLeft;
            titleLbl.Click += titleLbl_Click;
            titleLbl.MouseEnter += titleLbl_MouseEnter;
            titleLbl.MouseLeave += titleLbl_MouseLeave;
            // 
            // subtitleLbl
            // 
            subtitleLbl.AutoEllipsis = true;
            subtitleLbl.AutoSize = true;
            subtitleLbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            subtitleLbl.ForeColor = Color.Gray;
            subtitleLbl.Location = new Point(4, 92);
            subtitleLbl.Margin = new Padding(0);
            subtitleLbl.Name = "subtitleLbl";
            subtitleLbl.Size = new Size(225, 17);
            subtitleLbl.TabIndex = 15;
            subtitleLbl.Text = "This is an important announcement";
            subtitleLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(254, 206, 47);
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(271, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // AnnouncementFullContainer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pictureBox1);
            Controls.Add(subtitleLbl);
            Controls.Add(titleLbl);
            Name = "AnnouncementFullContainer";
            Size = new Size(271, 121);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label titleLbl;
        private Label subtitleLbl;
        private PictureBox pictureBox1;
    }
}
