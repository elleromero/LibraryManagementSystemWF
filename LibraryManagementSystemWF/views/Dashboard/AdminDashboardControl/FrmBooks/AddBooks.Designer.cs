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
            button3 = new Button();
            textBookID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(722, 148);
            dataGridView1.TabIndex = 0;
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitle.Location = new Point(90, 224);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(280, 29);
            txtTitle.TabIndex = 1;
            txtTitle.Text = "TITLE*";
            txtTitle.TextAlign = HorizontalAlignment.Center;
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAuthor.Location = new Point(90, 259);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(280, 29);
            txtAuthor.TabIndex = 1;
            txtAuthor.Text = "AUTHOR*";
            txtAuthor.TextAlign = HorizontalAlignment.Center;
            // 
            // txtSynopsis
            // 
            txtSynopsis.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSynopsis.Location = new Point(90, 310);
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.Size = new Size(280, 29);
            txtSynopsis.TabIndex = 1;
            txtSynopsis.Text = "SYPNOSIS*";
            txtSynopsis.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPublisher
            // 
            txtPublisher.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPublisher.Location = new Point(90, 358);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(280, 29);
            txtPublisher.TabIndex = 1;
            txtPublisher.Text = "PUBLISHER*";
            txtPublisher.TextAlign = HorizontalAlignment.Center;
            // 
            // txtISBN
            // 
            txtISBN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtISBN.Location = new Point(413, 205);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(280, 29);
            txtISBN.TabIndex = 1;
            txtISBN.Text = "ISBN*";
            txtISBN.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCover
            // 
            txtCover.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCover.Location = new Point(413, 250);
            txtCover.Name = "txtCover";
            txtCover.Size = new Size(280, 29);
            txtCover.TabIndex = 1;
            txtCover.Text = "COVER*";
            txtCover.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpPublicationDate
            // 
            dtpPublicationDate.Location = new Point(413, 364);
            dtpPublicationDate.Name = "dtpPublicationDate";
            dtpPublicationDate.Size = new Size(280, 23);
            dtpPublicationDate.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(471, 340);
            label1.Name = "label1";
            label1.Size = new Size(169, 21);
            label1.TabIndex = 3;
            label1.Text = "DATE OF PUBLISHING :";
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(533, 297);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(150, 23);
            cmbGenre.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(449, 299);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 3;
            label2.Text = "GENRE :";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(90, 420);
            button1.Name = "button1";
            button1.Size = new Size(141, 39);
            button1.TabIndex = 5;
            button1.Text = "ADD BOOKS";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(249, 420);
            button2.Name = "button2";
            button2.Size = new Size(141, 39);
            button2.TabIndex = 6;
            button2.Text = "UPDATE BOOKS";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(413, 420);
            button3.Name = "button3";
            button3.Size = new Size(141, 39);
            button3.TabIndex = 7;
            button3.Text = "DELETE BOOKS";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBookID
            // 
            textBookID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBookID.Location = new Point(90, 189);
            textBookID.Name = "textBookID";
            textBookID.Size = new Size(280, 29);
            textBookID.TabIndex = 8;
            textBookID.Text = "BOOK ID*";
            textBookID.TextAlign = HorizontalAlignment.Center;
            // 
            // AddBooks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 471);
            Controls.Add(textBookID);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
            Name = "AddBooks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddBooks";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
    }
}