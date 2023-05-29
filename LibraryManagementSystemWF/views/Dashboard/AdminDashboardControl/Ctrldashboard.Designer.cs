namespace LibraryManagementSystemWF.Dashboard.AdminDashboardControl
{
    partial class Ctrldashboard
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
            panel1 = new Panel();
            totalBooksLbl = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btrRatioLbl = new Label();
            label2 = new Label();
            panel3 = new Panel();
            availableCopiesLbl = new Label();
            label3 = new Label();
            subtitleLbl = new Label();
            titleLbl = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label7 = new Label();
            label8 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 206, 47);
            panel1.Controls.Add(totalBooksLbl);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(17, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(208, 100);
            panel1.TabIndex = 0;
            // 
            // totalBooksLbl
            // 
            totalBooksLbl.AutoEllipsis = true;
            totalBooksLbl.Dock = DockStyle.Bottom;
            totalBooksLbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            totalBooksLbl.Location = new Point(0, 32);
            totalBooksLbl.Name = "totalBooksLbl";
            totalBooksLbl.Size = new Size(208, 68);
            totalBooksLbl.TabIndex = 3;
            totalBooksLbl.Text = "N/A";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(5);
            label1.Size = new Size(105, 27);
            label1.TabIndex = 0;
            label1.Text = "TOTAL BOOKS";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(254, 206, 47);
            panel2.Controls.Add(btrRatioLbl);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(252, 15);
            panel2.Name = "panel2";
            panel2.Size = new Size(208, 100);
            panel2.TabIndex = 1;
            // 
            // btrRatioLbl
            // 
            btrRatioLbl.AutoEllipsis = true;
            btrRatioLbl.Dock = DockStyle.Bottom;
            btrRatioLbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btrRatioLbl.Location = new Point(0, 32);
            btrRatioLbl.Name = "btrRatioLbl";
            btrRatioLbl.Size = new Size(208, 68);
            btrRatioLbl.TabIndex = 3;
            btrRatioLbl.Text = "N/A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(5);
            label2.Size = new Size(193, 27);
            label2.TabIndex = 1;
            label2.Text = "BORROW TO RETURN RATIO";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(254, 206, 47);
            panel3.Controls.Add(availableCopiesLbl);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(483, 15);
            panel3.Name = "panel3";
            panel3.Size = new Size(208, 100);
            panel3.TabIndex = 2;
            // 
            // availableCopiesLbl
            // 
            availableCopiesLbl.AutoEllipsis = true;
            availableCopiesLbl.Dock = DockStyle.Bottom;
            availableCopiesLbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            availableCopiesLbl.Location = new Point(0, 32);
            availableCopiesLbl.Name = "availableCopiesLbl";
            availableCopiesLbl.Size = new Size(208, 68);
            availableCopiesLbl.TabIndex = 3;
            availableCopiesLbl.Text = "N/A";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(5);
            label3.Size = new Size(177, 27);
            label3.TabIndex = 2;
            label3.Text = "TOTAL AVAILABLE COPIES";
            // 
            // subtitleLbl
            // 
            subtitleLbl.AutoSize = true;
            subtitleLbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            subtitleLbl.ForeColor = Color.Gray;
            subtitleLbl.Location = new Point(15, 164);
            subtitleLbl.Name = "subtitleLbl";
            subtitleLbl.Size = new Size(182, 17);
            subtitleLbl.TabIndex = 14;
            subtitleLbl.Text = "Welcome to your dashboard";
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            titleLbl.Location = new Point(12, 134);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(114, 30);
            titleLbl.TabIndex = 13;
            titleLbl.Text = "Greetings!";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(17, 219);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(443, 281);
            flowLayoutPanel1.TabIndex = 15;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(483, 219);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(208, 281);
            flowLayoutPanel2.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(15, 199);
            label7.Name = "label7";
            label7.Size = new Size(103, 17);
            label7.TabIndex = 17;
            label7.Text = "Recently Added";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(479, 199);
            label8.Name = "label8";
            label8.Size = new Size(123, 17);
            label8.TabIndex = 18;
            label8.Text = "🎉 Annoucements";
            // 
            // Ctrldashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(subtitleLbl);
            Controls.Add(titleLbl);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "Ctrldashboard";
            Size = new Size(710, 520);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label totalBooksLbl;
        private Label label1;
        private Label btrRatioLbl;
        private Label label2;
        private Label availableCopiesLbl;
        private Label label3;
        private Label subtitleLbl;
        private Label titleLbl;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label7;
        private Label label8;
    }
}
