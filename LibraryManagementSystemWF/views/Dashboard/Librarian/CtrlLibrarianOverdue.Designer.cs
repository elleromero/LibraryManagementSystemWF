namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    partial class CtrlLibrarianOverdue
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
            this.subtitleLbl = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridDueBooks = new System.Windows.Forms.DataGridView();
            this.pageLbl = new System.Windows.Forms.Label();
            this.nextLastBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.prevLastBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalAmountDue = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProceedPayment = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChange = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDueBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // subtitleLbl
            // 
            this.subtitleLbl.AutoSize = true;
            this.subtitleLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.subtitleLbl.ForeColor = System.Drawing.Color.Gray;
            this.subtitleLbl.Location = new System.Drawing.Point(6, 42);
            this.subtitleLbl.Name = "subtitleLbl";
            this.subtitleLbl.Size = new System.Drawing.Size(223, 17);
            this.subtitleLbl.TabIndex = 30;
            this.subtitleLbl.Text = "Process payment of overdue books";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLbl.Location = new System.Drawing.Point(3, 12);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(162, 30);
            this.titleLbl.TabIndex = 29;
            this.titleLbl.Text = "Overdue Books";
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.AllowUserToAddRows = false;
            this.dataGridUsers.AllowUserToDeleteRows = false;
            this.dataGridUsers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsers.Location = new System.Drawing.Point(6, 110);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.RowTemplate.Height = 25;
            this.dataGridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUsers.Size = new System.Drawing.Size(370, 364);
            this.dataGridUsers.TabIndex = 31;
            this.dataGridUsers.SelectionChanged += new System.EventHandler(this.dataGridUsers_SelectionChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(6, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Search Username";
            this.textBox1.Size = new System.Drawing.Size(307, 27);
            this.textBox1.TabIndex = 32;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(319, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 27);
            this.button2.TabIndex = 33;
            this.button2.Text = "🔍";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // dataGridDueBooks
            // 
            this.dataGridDueBooks.BackgroundColor = System.Drawing.Color.White;
            this.dataGridDueBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDueBooks.Location = new System.Drawing.Point(382, 164);
            this.dataGridDueBooks.Name = "dataGridDueBooks";
            this.dataGridDueBooks.RowTemplate.Height = 25;
            this.dataGridDueBooks.Size = new System.Drawing.Size(325, 153);
            this.dataGridDueBooks.TabIndex = 35;
            this.dataGridDueBooks.SelectionChanged += new System.EventHandler(this.dataGridDueBooks_SelectionChanged);
            // 
            // pageLbl
            // 
            this.pageLbl.AutoSize = true;
            this.pageLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageLbl.Location = new System.Drawing.Point(89, 484);
            this.pageLbl.Name = "pageLbl";
            this.pageLbl.Size = new System.Drawing.Size(30, 17);
            this.pageLbl.TabIndex = 42;
            this.pageLbl.Text = "1 | 1";
            this.pageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextLastBtn
            // 
            this.nextLastBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.nextLastBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextLastBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextLastBtn.Location = new System.Drawing.Point(158, 480);
            this.nextLastBtn.Name = "nextLastBtn";
            this.nextLastBtn.Size = new System.Drawing.Size(42, 27);
            this.nextLastBtn.TabIndex = 41;
            this.nextLastBtn.Text = ">>";
            this.nextLastBtn.UseVisualStyleBackColor = false;
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextBtn.Location = new System.Drawing.Point(125, 480);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(27, 27);
            this.nextBtn.TabIndex = 40;
            this.nextBtn.Text = ">";
            this.nextBtn.UseVisualStyleBackColor = false;
            // 
            // prevBtn
            // 
            this.prevBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.prevBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.prevBtn.Location = new System.Drawing.Point(56, 480);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(27, 27);
            this.prevBtn.TabIndex = 39;
            this.prevBtn.Text = "<";
            this.prevBtn.UseVisualStyleBackColor = false;
            // 
            // prevLastBtn
            // 
            this.prevLastBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.prevLastBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevLastBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.prevLastBtn.Location = new System.Drawing.Point(6, 480);
            this.prevLastBtn.Name = "prevLastBtn";
            this.prevLastBtn.Size = new System.Drawing.Size(42, 27);
            this.prevLastBtn.TabIndex = 38;
            this.prevLastBtn.Text = "<<";
            this.prevLastBtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(382, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "Total Amount Due:";
            // 
            // lblTotalAmountDue
            // 
            this.lblTotalAmountDue.AutoSize = true;
            this.lblTotalAmountDue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalAmountDue.Location = new System.Drawing.Point(536, 334);
            this.lblTotalAmountDue.Name = "lblTotalAmountDue";
            this.lblTotalAmountDue.Size = new System.Drawing.Size(31, 20);
            this.lblTotalAmountDue.TabIndex = 44;
            this.lblTotalAmountDue.Text = "0.0";
            // 
            // txtCash
            // 
            this.txtCash.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCash.Location = new System.Drawing.Point(536, 411);
            this.txtCash.Name = "txtCash";
            this.txtCash.PlaceholderText = "0.0";
            this.txtCash.Size = new System.Drawing.Size(171, 27);
            this.txtCash.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(382, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Cash:";
            // 
            // btnProceedPayment
            // 
            this.btnProceedPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.btnProceedPayment.FlatAppearance.BorderSize = 0;
            this.btnProceedPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnProceedPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnProceedPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceedPayment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProceedPayment.ForeColor = System.Drawing.Color.Black;
            this.btnProceedPayment.Location = new System.Drawing.Point(382, 447);
            this.btnProceedPayment.Name = "btnProceedPayment";
            this.btnProceedPayment.Size = new System.Drawing.Size(325, 27);
            this.btnProceedPayment.TabIndex = 47;
            this.btnProceedPayment.Text = "Proceed Payment";
            this.btnProceedPayment.UseVisualStyleBackColor = false;
            this.btnProceedPayment.Click += new System.EventHandler(this.btnProceedPayment_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(382, 480);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(325, 27);
            this.button3.TabIndex = 48;
            this.button3.Text = "Scan QR";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(415, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 126);
            this.panel1.TabIndex = 49;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblChange.Location = new System.Drawing.Point(536, 372);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(31, 20);
            this.lblChange.TabIndex = 51;
            this.lblChange.Text = "0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(382, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Change:";
            // 
            // CtrlLibrarianOverdue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnProceedPayment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.lblTotalAmountDue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pageLbl);
            this.Controls.Add(this.nextLastBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.prevLastBtn);
            this.Controls.Add(this.dataGridDueBooks);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridUsers);
            this.Controls.Add(this.subtitleLbl);
            this.Controls.Add(this.titleLbl);
            this.Name = "CtrlLibrarianOverdue";
            this.Size = new System.Drawing.Size(710, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDueBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label subtitleLbl;
        private Label titleLbl;
        private DataGridView dataGridUsers;
        private TextBox textBox1;
        private Button button2;
        private DataGridView dataGridDueBooks;
        private Label pageLbl;
        private Button nextLastBtn;
        private Button nextBtn;
        private Button prevBtn;
        private Button prevLastBtn;
        private Label label1;
        private Label lblTotalAmountDue;
        private TextBox txtCash;
        private Label label3;
        private Button btnProceedPayment;
        private Button button3;
        private Panel panel1;
        private Label lblChange;
        private Label label4;
    }
}
