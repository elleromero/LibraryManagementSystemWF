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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtSynopsis = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtCover = new System.Windows.Forms.TextBox();
            this.dtpPublicationDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(43, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(722, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTitle.Location = new System.Drawing.Point(90, 205);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(280, 29);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "TITLE*";
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAuthor.Location = new System.Drawing.Point(90, 259);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(280, 29);
            this.txtAuthor.TabIndex = 1;
            this.txtAuthor.Text = "AUTHOR*";
            this.txtAuthor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSynopsis
            // 
            this.txtSynopsis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSynopsis.Location = new System.Drawing.Point(90, 310);
            this.txtSynopsis.Name = "txtSynopsis";
            this.txtSynopsis.Size = new System.Drawing.Size(280, 29);
            this.txtSynopsis.TabIndex = 1;
            this.txtSynopsis.Text = "SYPNOSIS*";
            this.txtSynopsis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPublisher.Location = new System.Drawing.Point(90, 358);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(280, 29);
            this.txtPublisher.TabIndex = 1;
            this.txtPublisher.Text = "PUBLISHER*";
            this.txtPublisher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtISBN
            // 
            this.txtISBN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtISBN.Location = new System.Drawing.Point(413, 205);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(280, 29);
            this.txtISBN.TabIndex = 1;
            this.txtISBN.Text = "ISBN*";
            this.txtISBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCover
            // 
            this.txtCover.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCover.Location = new System.Drawing.Point(413, 250);
            this.txtCover.Name = "txtCover";
            this.txtCover.Size = new System.Drawing.Size(280, 29);
            this.txtCover.TabIndex = 1;
            this.txtCover.Text = "COVER*";
            this.txtCover.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpPublicationDate
            // 
            this.dtpPublicationDate.Location = new System.Drawing.Point(413, 364);
            this.dtpPublicationDate.Name = "dtpPublicationDate";
            this.dtpPublicationDate.Size = new System.Drawing.Size(280, 23);
            this.dtpPublicationDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(471, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "DATE OF PUBLISHING :";
            // 
            // cmbGenre
            // 
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Location = new System.Drawing.Point(533, 297);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(150, 23);
            this.cmbGenre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(449, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "GENRE :";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(143, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "ADD BOOKS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpPublicationDate);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.txtSynopsis);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtCover);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AddBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddBooks";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}