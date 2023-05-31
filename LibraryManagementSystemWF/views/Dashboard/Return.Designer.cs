namespace LibraryManagementSystemWF.views.Dashboard
{
    partial class Return
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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            label4 = new Label();
            txtBookId = new Label();
            textBookId = new TextBox();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            dtpDueDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 206, 47);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(12, 520);
            panel1.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(254, 206, 47);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(698, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(12, 520);
            panel2.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(254, 206, 47);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(12, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(686, 14);
            panel3.TabIndex = 12;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(254, 206, 47);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(12, 506);
            panel4.Name = "panel4";
            panel4.Size = new Size(686, 14);
            panel4.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(18, 28);
            label4.Name = "label4";
            label4.Size = new Size(129, 25);
            label4.TabIndex = 15;
            label4.Text = "Return Book";
            // 
            // txtBookId
            // 
            txtBookId.AutoSize = true;
            txtBookId.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txtBookId.Location = new Point(18, 334);
            txtBookId.Name = "txtBookId";
            txtBookId.Size = new Size(57, 17);
            txtBookId.TabIndex = 18;
            txtBookId.Text = "Book ID";
            // 
            // textBookId
            // 
            textBookId.BorderStyle = BorderStyle.FixedSingle;
            textBookId.Location = new Point(18, 364);
            textBookId.Name = "textBookId";
            textBookId.Size = new Size(235, 23);
            textBookId.TabIndex = 17;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(674, 254);
            dataGridView1.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(268, 334);
            label1.Name = "label1";
            label1.Size = new Size(79, 17);
            label1.TabIndex = 20;
            label1.Text = "Book Name";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(268, 364);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(270, 23);
            textBox1.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(18, 413);
            label2.Name = "label2";
            label2.Size = new Size(107, 17);
            label2.TabIndex = 22;
            label2.Text = "Book Issue Date";
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(18, 443);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(235, 23);
            textBox2.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(268, 413);
            label3.Name = "label3";
            label3.Size = new Size(117, 17);
            label3.TabIndex = 25;
            label3.Text = "Book Return Date";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(254, 206, 47);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(558, 354);
            button1.Name = "button1";
            button1.Size = new Size(123, 34);
            button1.TabIndex = 26;
            button1.Text = "Return";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(254, 206, 47);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(558, 438);
            button2.Name = "button2";
            button2.Size = new Size(123, 34);
            button2.TabIndex = 27;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = false;
            // 
            // dtpDueDate
            // 
            dtpDueDate.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDueDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDueDate.Location = new Point(268, 439);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(270, 29);
            dtpDueDate.TabIndex = 28;
            // 
            // Return
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 520);
            Controls.Add(dtpDueDate);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(txtBookId);
            Controls.Add(textBookId);
            Controls.Add(label4);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Return";
            Text = "Return";
            Load += Return_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label4;
        private Label txtBookId;
        private TextBox textBookId;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Button button1;
        private Button button2;
        private DateTimePicker dtpDueDate;
    }
}