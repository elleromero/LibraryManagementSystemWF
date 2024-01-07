namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    partial class AdminConfig
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
            this.subtitleLbl = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.navLbl = new System.Windows.Forms.Label();
            this.topbar = new System.Windows.Forms.Panel();
            this.timeLbl = new System.Windows.Forms.Label();
            this.timerLbl = new System.Windows.Forms.Label();
            this.topbar.SuspendLayout();
            this.coverColor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numericMaxBorrowedBooks = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericMaxCopies = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericMaxPrice = new System.Windows.Forms.NumericUpDown();
            this.cbAllowBorrowAfterDue = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxBorrowedBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // subtitleLbl
            // coverColor
            // 
            this.subtitleLbl.AutoSize = true;
            this.subtitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.subtitleLbl.ForeColor = System.Drawing.Color.Gray;
            this.subtitleLbl.Location = new System.Drawing.Point(15, 71);
            this.subtitleLbl.Name = "subtitleLbl";
            this.subtitleLbl.Size = new System.Drawing.Size(242, 17);
            this.subtitleLbl.TabIndex = 14;
            this.subtitleLbl.Text = "You currently have 5 user(s) registered";
            this.coverColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.coverColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.coverColor.Location = new System.Drawing.Point(0, 0);
            this.coverColor.Name = "coverColor";
            this.coverColor.Size = new System.Drawing.Size(321, 53);
            this.coverColor.TabIndex = 1;
            // 
            // titleLbl
            // label3
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLbl.Location = new System.Drawing.Point(12, 41);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(114, 30);
            this.titleLbl.TabIndex = 13;
            this.titleLbl.Text = "Greetings!";
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(26, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max Borrowed Books:";
            // 
            // numericMaxBorrowedBooks
            // navLbl
            // 
            this.numericMaxBorrowedBooks.Location = new System.Drawing.Point(170, 70);
            this.numericMaxBorrowedBooks.Name = "numericMaxBorrowedBooks";
            this.numericMaxBorrowedBooks.Size = new System.Drawing.Size(120, 23);
            this.numericMaxBorrowedBooks.TabIndex = 4;
            this.navLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.navLbl.AutoSize = true;
            this.navLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.navLbl.Location = new System.Drawing.Point(12, 9);
            this.navLbl.Name = "navLbl";
            this.navLbl.Size = new System.Drawing.Size(117, 21);
            this.navLbl.TabIndex = 0;
            this.navLbl.Text = "Configuration";
            this.navLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // topbar
            // label1
            // 
            this.topbar.BackColor = System.Drawing.Color.White;
            this.topbar.Controls.Add(this.timeLbl);
            this.topbar.Controls.Add(this.timerLbl);
            this.topbar.Controls.Add(this.navLbl);
            this.topbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topbar.Location = new System.Drawing.Point(0, 0);
            this.topbar.Name = "topbar";
            this.topbar.Size = new System.Drawing.Size(800, 38);
            this.topbar.TabIndex = 15;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max Copies:";
            // 
            // numericMaxCopies
            // timeLbl
            // 
            this.numericMaxCopies.Location = new System.Drawing.Point(170, 113);
            this.numericMaxCopies.Name = "numericMaxCopies";
            this.numericMaxCopies.Size = new System.Drawing.Size(120, 23);
            this.numericMaxCopies.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(26, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max Price:";
            // 
            // numericMaxPrice
            // 
            this.numericMaxPrice.Location = new System.Drawing.Point(170, 156);
            this.numericMaxPrice.Name = "numericMaxPrice";
            this.numericMaxPrice.Size = new System.Drawing.Size(120, 23);
            this.numericMaxPrice.TabIndex = 4;
            // 
            // cbAllowBorrowAfterDue
            // 
            this.cbAllowBorrowAfterDue.AutoSize = true;
            this.cbAllowBorrowAfterDue.Location = new System.Drawing.Point(86, 206);
            this.cbAllowBorrowAfterDue.Name = "cbAllowBorrowAfterDue";
            this.cbAllowBorrowAfterDue.Size = new System.Drawing.Size(150, 19);
            this.cbAllowBorrowAfterDue.TabIndex = 5;
            this.cbAllowBorrowAfterDue.Text = "Allow Borrow After Due";
            this.cbAllowBorrowAfterDue.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaveBtn.Location = new System.Drawing.Point(39, 268);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(109, 45);
            this.SaveBtn.TabIndex = 16;
            this.SaveBtn.Text = "SAVE";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // timerLbl
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelBtn.Location = new System.Drawing.Point(172, 268);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(109, 45);
            this.CancelBtn.TabIndex = 16;
            this.CancelBtn.Text = "CANCEL";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.timerLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerLbl.AutoSize = true;
            this.timerLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timerLbl.Location = new System.Drawing.Point(2071, 12);
            this.timerLbl.Name = "timerLbl";
            this.timerLbl.Size = new System.Drawing.Size(209, 15);
            this.timerLbl.TabIndex = 1;
            this.timerLbl.Text = "Sept. 14 2023. Monday. 11:00:34 AM";
            this.timerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AdminConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 351);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.cbAllowBorrowAfterDue);
            this.Controls.Add(this.numericMaxPrice);
            this.Controls.Add(this.numericMaxCopies);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericMaxBorrowedBooks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.coverColor);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.topbar);
            this.Controls.Add(this.subtitleLbl);
            this.Controls.Add(this.titleLbl);
            this.Name = "AdminConfig";
            this.Text = "AdminConfig";
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxBorrowedBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxPrice)).EndInit();
            this.topbar.ResumeLayout(false);
            this.topbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel coverColor;
        private Label label3;
        private NumericUpDown numericMaxBorrowedBooks;
        private Label label1;
        private NumericUpDown numericMaxCopies;
        private Label label2;
        private NumericUpDown numericMaxPrice;
        private CheckBox cbAllowBorrowAfterDue;
        private Button SaveBtn;
        private Button CancelBtn;
        private Label subtitleLbl;
        private Label titleLbl;
        private Label navLbl;
        private Panel topbar;
        private Label timeLbl;
        private Label timerLbl;
    }
}