namespace LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl.FrmBooks
{
    partial class AddBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBooks));
            dataGridView1 = new DataGridView();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtSynopsis = new TextBox();
            txtPublisher = new TextBox();
            txtISBN = new TextBox();
            txtCover = new TextBox();
            dtpPublicationDate = new DateTimePicker();
            label1 = new Label();
            cmbGenre = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            btnDelete = new Button();
            textBookID = new TextBox();
            btnDeleteBooks = new Button();
            btnBack = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(154, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(647, 170);
            dataGridView1.TabIndex = 0;
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitle.Location = new Point(177, 266);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(280, 29);
            txtTitle.TabIndex = 1;
            txtTitle.Text = "TITLE*";
            txtTitle.TextAlign = HorizontalAlignment.Center;
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAuthor.Location = new Point(177, 313);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(280, 29);
            txtAuthor.TabIndex = 1;
            txtAuthor.Text = "AUTHOR*";
            txtAuthor.TextAlign = HorizontalAlignment.Center;
            // 
            // txtSynopsis
            // 
            txtSynopsis.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSynopsis.Location = new Point(177, 359);
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.Size = new Size(280, 29);
            txtSynopsis.TabIndex = 1;
            txtSynopsis.Text = "SYPNOSIS*";
            txtSynopsis.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPublisher
            // 
            txtPublisher.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPublisher.Location = new Point(177, 406);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(280, 29);
            txtPublisher.TabIndex = 1;
            txtPublisher.Text = "PUBLISHER*";
            txtPublisher.TextAlign = HorizontalAlignment.Center;
            // 
            // txtISBN
            // 
            txtISBN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtISBN.Location = new Point(493, 222);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(280, 29);
            txtISBN.TabIndex = 1;
            txtISBN.Text = "ISBN*";
            txtISBN.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCover
            // 
            txtCover.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCover.Location = new Point(493, 266);
            txtCover.Name = "txtCover";
            txtCover.Size = new Size(280, 29);
            txtCover.TabIndex = 1;
            txtCover.Text = "COVER*";
            txtCover.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpPublicationDate
            // 
            dtpPublicationDate.Location = new Point(493, 397);
            dtpPublicationDate.Name = "dtpPublicationDate";
            dtpPublicationDate.Size = new Size(280, 23);
            dtpPublicationDate.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(493, 362);
            label1.Name = "label1";
            label1.Size = new Size(169, 21);
            label1.TabIndex = 3;
            label1.Text = "DATE OF PUBLISHING :";
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(574, 319);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(199, 23);
            cmbGenre.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(493, 321);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 3;
            label2.Text = "GENRE :";
            // 
            // button1
            // 
            button1.BackColor = Color.WhiteSmoke;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 184);
            button1.Name = "button1";
            button1.Size = new Size(155, 54);
            button1.TabIndex = 5;
            button1.Text = "      ADD BOOKS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.WhiteSmoke;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 240);
            button2.Name = "button2";
            button2.Size = new Size(155, 54);
            button2.TabIndex = 6;
            button2.Text = "       UPDATE BOOKS";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(0, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 0;
            // 
            // textBookID
            // 
            textBookID.BackColor = Color.White;
            textBookID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBookID.ForeColor = SystemColors.MenuText;
            textBookID.Location = new Point(177, 222);
            textBookID.Name = "textBookID";
            textBookID.Size = new Size(280, 29);
            textBookID.TabIndex = 8;
            textBookID.Text = "BOOK ID*";
            textBookID.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDeleteBooks
            // 
            btnDeleteBooks.BackColor = Color.WhiteSmoke;
            btnDeleteBooks.FlatAppearance.BorderSize = 2;
            btnDeleteBooks.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            btnDeleteBooks.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            btnDeleteBooks.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            btnDeleteBooks.FlatStyle = FlatStyle.Flat;
            btnDeleteBooks.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteBooks.Image = (Image)resources.GetObject("btnDeleteBooks.Image");
            btnDeleteBooks.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteBooks.Location = new Point(-1, 296);
            btnDeleteBooks.Name = "btnDeleteBooks";
            btnDeleteBooks.Size = new Size(156, 54);
            btnDeleteBooks.TabIndex = 9;
            btnDeleteBooks.Text = "     DELETE BOOKS";
            btnDeleteBooks.UseVisualStyleBackColor = false;
            btnDeleteBooks.Click += btnDeleteBooks_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(254, 206, 47);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            btnBack.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.ImageAlign = ContentAlignment.MiddleLeft;
            btnBack.Location = new Point(0, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(155, 53);
            btnBack.TabIndex = 10;
            btnBack.Text = "BACK";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 206, 47);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnDeleteBooks);
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(155, 514);
            panel1.TabIndex = 11;
            // 
            // AddBooks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 514);
            Controls.Add(textBookID);
            Controls.Add(cmbGenre);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpPublicationDate);
            Controls.Add(txtPublisher);
            Controls.Add(txtSynopsis);
            Controls.Add(txtAuthor);
            Controls.Add(txtCover);
            Controls.Add(txtISBN);
            Controls.Add(txtTitle);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddBooks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddBooks";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtSynopsis;
        private TextBox txtPublisher;
        private TextBox txtISBN;
        private TextBox txtCover;
        private DateTimePicker dtpPublicationDate;
        private Label label1;
        private ComboBox cmbGenre;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button btnDelete;
        private TextBox textBookID;
        private Button btnDeleteBooks;
        private Button btnBack;
        private Panel panel1;
    }
}