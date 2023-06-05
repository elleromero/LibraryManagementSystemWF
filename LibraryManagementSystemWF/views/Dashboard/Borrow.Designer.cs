namespace LibraryManagementSystemWF.views.Dashboard
{
    partial class Borrow
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
            dtpDueDate = new DateTimePicker();
            textBookId = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label4 = new Label();
            button1 = new Button();
            txtBookId = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dtpDueDate
            // 
            dtpDueDate.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDueDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDueDate.Location = new Point(57, 439);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(284, 29);
            dtpDueDate.TabIndex = 3;
            // 
            // textBookId
            // 
            textBookId.BorderStyle = BorderStyle.FixedSingle;
            textBookId.Location = new Point(57, 375);
            textBookId.Name = "textBookId";
            textBookId.Size = new Size(284, 23);
            textBookId.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(57, 415);
            label3.Name = "label3";
            label3.Size = new Size(85, 17);
            label3.TabIndex = 8;
            label3.Text = "Borrow Date";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 206, 47);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(12, 520);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(254, 206, 47);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(695, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(15, 520);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(254, 206, 47);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(12, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(683, 14);
            panel3.TabIndex = 11;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(254, 206, 47);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(12, 506);
            panel4.Name = "panel4";
            panel4.Size = new Size(683, 14);
            panel4.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(18, 57);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(323, 254);
            flowLayoutPanel1.TabIndex = 13;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(18, 29);
            label4.Name = "label4";
            label4.Size = new Size(134, 25);
            label4.TabIndex = 14;
            label4.Text = "Borrow Book";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(254, 206, 47);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(378, 405);
            button1.Name = "button1";
            button1.Size = new Size(284, 34);
            button1.TabIndex = 15;
            button1.Text = "Borrowed";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtBookId
            // 
            txtBookId.AutoSize = true;
            txtBookId.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txtBookId.Location = new Point(57, 345);
            txtBookId.Name = "txtBookId";
            txtBookId.Size = new Size(57, 17);
            txtBookId.TabIndex = 16;
            txtBookId.Text = "Book ID";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(347, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(342, 254);
            dataGridView1.TabIndex = 17;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // Borrow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 520);
            Controls.Add(dataGridView1);
            Controls.Add(txtBookId);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(textBookId);
            Controls.Add(dtpDueDate);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Borrow";
            Text = "Borrow";
            Load += Borrow_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private DateTimePicker dtpDueDate;
        private TextBox textBookId;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label4;
        private Button button1;
        private Label txtBookId;
        private DataGridView dataGridView1;
    }
}