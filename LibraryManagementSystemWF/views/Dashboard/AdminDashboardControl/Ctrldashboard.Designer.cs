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
            this.panel1 = new System.Windows.Forms.Panel();
            this.totalBooksLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btrRatioLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.availableCopiesLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.subtitleLbl = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAnnouncements = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.prevBtn = new System.Windows.Forms.Button();
            this.pageLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 219);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(417, 289);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // flpAnnouncements
            // 
            this.flpAnnouncements.AutoScroll = true;
            this.flpAnnouncements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpAnnouncements.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAnnouncements.Location = new System.Drawing.Point(440, 219);
            this.flpAnnouncements.Name = "flpAnnouncements";
            this.flpAnnouncements.Size = new System.Drawing.Size(251, 259);
            this.flpAnnouncements.TabIndex = 16;
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
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(440, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "🎉 Annoucements";
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextBtn.Location = new System.Drawing.Point(472, 484);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(24, 24);
            this.nextBtn.TabIndex = 19;
            this.nextBtn.Text = ">";
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(618, 201);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(73, 15);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Publish New";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // prevBtn
            // 
            this.prevBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.prevBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.prevBtn.Location = new System.Drawing.Point(440, 484);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(24, 24);
            this.prevBtn.TabIndex = 22;
            this.prevBtn.Text = "<";
            this.prevBtn.UseVisualStyleBackColor = false;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // pageLbl
            // 
            this.pageLbl.AutoSize = true;
            this.pageLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageLbl.Location = new System.Drawing.Point(661, 484);
            this.pageLbl.Name = "pageLbl";
            this.pageLbl.Size = new System.Drawing.Size(30, 17);
            this.pageLbl.TabIndex = 23;
            this.pageLbl.Text = "1 | 1";
            // 
            // Ctrldashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pageLbl);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.flpAnnouncements);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.subtitleLbl);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Ctrldashboard";
            this.Size = new System.Drawing.Size(710, 520);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private FlowLayoutPanel flpAnnouncements;
        private Label label7;
        private Label label8;
        private Button nextBtn;
        private LinkLabel linkLabel2;
        private Button prevBtn;
        private Label pageLbl;
    }
}
