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
            // coverColor
            // 
            this.coverColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.coverColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.coverColor.Location = new System.Drawing.Point(0, 0);
            this.coverColor.Name = "coverColor";
            this.coverColor.Size = new System.Drawing.Size(321, 53);
            this.coverColor.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(26, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max Borrowed Books:";
            // 
            // numericMaxBorrowedBooks
            // 
            this.numericMaxBorrowedBooks.Location = new System.Drawing.Point(170, 70);
            this.numericMaxBorrowedBooks.Name = "numericMaxBorrowedBooks";
            this.numericMaxBorrowedBooks.Size = new System.Drawing.Size(120, 23);
            this.numericMaxBorrowedBooks.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max Copies:";
            // 
            // numericMaxCopies
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
            this.Name = "AdminConfig";
            this.Text = "AdminConfig";
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxBorrowedBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxPrice)).EndInit();
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
    }
}