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
            cmbGenre = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            btnDelete = new Button();
            textBookID = new TextBox();
            btnDeleteBooks = new Button();
            btnBack = new Button();
            panel1 = new Panel();
            clearBtn = new Button();
            coverImg = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label1 = new Label();
            button3 = new Button();
            label2 = new Label();
            panel2 = new Panel();
            numCopies = new NumericUpDown();
            label11 = new Label();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)coverImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCopies).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.Location = new Point(155, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(831, 170);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTitle.Location = new Point(177, 280);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Harry Potter";
            txtTitle.Size = new Size(280, 29);
            txtTitle.TabIndex = 1;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAuthor.Location = new Point(177, 347);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.PlaceholderText = "J. K. Rowling";
            txtAuthor.Size = new Size(280, 29);
            txtAuthor.TabIndex = 1;
            txtAuthor.TextChanged += txtTitle_TextChanged;
            // 
            // txtSynopsis
            // 
            txtSynopsis.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSynopsis.Location = new Point(491, 372);
            txtSynopsis.Multiline = true;
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.PlaceholderText = "Write something awesome...";
            txtSynopsis.ScrollBars = ScrollBars.Vertical;
            txtSynopsis.Size = new Size(280, 212);
            txtSynopsis.TabIndex = 1;
            // 
            // txtPublisher
            // 
            txtPublisher.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPublisher.Location = new Point(177, 539);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.PlaceholderText = "Agila Inc.";
            txtPublisher.Size = new Size(280, 29);
            txtPublisher.TabIndex = 1;
            // 
            // txtISBN
            // 
            txtISBN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtISBN.Location = new Point(177, 412);
            txtISBN.Name = "txtISBN";
            txtISBN.PlaceholderText = "ISBN 10 or ISBN 13";
            txtISBN.Size = new Size(280, 29);
            txtISBN.TabIndex = 1;
            // 
            // txtCover
            // 
            txtCover.Enabled = false;
            txtCover.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCover.Location = new Point(177, 476);
            txtCover.Name = "txtCover";
            txtCover.PlaceholderText = "C://Images/cover.png";
            txtCover.ReadOnly = true;
            txtCover.Size = new Size(222, 29);
            txtCover.TabIndex = 1;
            txtCover.TextChanged += txtTitle_TextChanged;
            // 
            // dtpPublicationDate
            // 
            dtpPublicationDate.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpPublicationDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpPublicationDate.Location = new Point(493, 272);
            dtpPublicationDate.Name = "dtpPublicationDate";
            dtpPublicationDate.Size = new Size(280, 29);
            dtpPublicationDate.TabIndex = 2;
            // 
            // cmbGenre
            // 
            cmbGenre.BackColor = SystemColors.Control;
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.FlatStyle = FlatStyle.Flat;
            cmbGenre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(493, 216);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(280, 29);
            cmbGenre.TabIndex = 4;
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
            button1.Location = new Point(0, 173);
            button1.Name = "button1";
            button1.Size = new Size(155, 54);
            button1.TabIndex = 5;
            button1.Text = "      ADD BOOKS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            button2.Location = new Point(0, 229);
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
            textBookID.BackColor = SystemColors.Control;
            textBookID.Enabled = false;
            textBookID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBookID.ForeColor = SystemColors.MenuText;
            textBookID.Location = new Point(177, 216);
            textBookID.Name = "textBookID";
            textBookID.PlaceholderText = "Not required in ADD MODE";
            textBookID.ReadOnly = true;
            textBookID.Size = new Size(280, 29);
            textBookID.TabIndex = 8;
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
            btnDeleteBooks.Location = new Point(-1, 285);
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
            panel1.Controls.Add(button4);
            panel1.Controls.Add(clearBtn);
            panel1.Controls.Add(coverImg);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnDeleteBooks);
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(155, 595);
            panel1.TabIndex = 11;
            // 
            // clearBtn
            // 
            clearBtn.BackColor = Color.WhiteSmoke;
            clearBtn.FlatAppearance.BorderSize = 2;
            clearBtn.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            clearBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            clearBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            clearBtn.FlatStyle = FlatStyle.Flat;
            clearBtn.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            clearBtn.Image = (Image)resources.GetObject("clearBtn.Image");
            clearBtn.ImageAlign = ContentAlignment.MiddleLeft;
            clearBtn.Location = new Point(0, 116);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(155, 54);
            clearBtn.TabIndex = 44;
            clearBtn.Text = "      CLEAR";
            clearBtn.UseVisualStyleBackColor = false;
            clearBtn.Click += clearBtn_Click;
            // 
            // coverImg
            // 
            coverImg.Location = new Point(0, 399);
            coverImg.Name = "coverImg";
            coverImg.Size = new Size(155, 196);
            coverImg.SizeMode = PictureBoxSizeMode.StretchImage;
            coverImg.TabIndex = 11;
            coverImg.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(173, 196);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 18;
            label3.Text = "Book ID";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(174, 260);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 19;
            label4.Text = "Book Title";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(174, 327);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(51, 17);
            label5.TabIndex = 20;
            label5.Text = "Author";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(174, 392);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(37, 17);
            label6.TabIndex = 21;
            label6.Text = "ISBN";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(174, 456);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(85, 17);
            label7.TabIndex = 22;
            label7.Text = "Cover Image";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(174, 519);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(64, 17);
            label8.TabIndex = 23;
            label8.Text = "Publisher";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(491, 196);
            label9.Margin = new Padding(0);
            label9.Name = "label9";
            label9.Size = new Size(44, 17);
            label9.TabIndex = 24;
            label9.Text = "Genre";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(491, 252);
            label10.Margin = new Padding(0);
            label10.Name = "label10";
            label10.Size = new Size(107, 17);
            label10.TabIndex = 25;
            label10.Text = "Publication Date";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(490, 352);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(61, 17);
            label1.TabIndex = 26;
            label1.Text = "Sypnosis";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(254, 206, 47);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(405, 476);
            button3.Name = "button3";
            button3.Size = new Size(52, 29);
            button3.TabIndex = 27;
            button3.Text = "find";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(809, 196);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(55, 17);
            label2.TabIndex = 40;
            label2.Text = "Preview";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Location = new Point(812, 216);
            panel2.Name = "panel2";
            panel2.Size = new Size(152, 252);
            panel2.TabIndex = 39;
            // 
            // numCopies
            // 
            numCopies.Location = new Point(491, 326);
            numCopies.Name = "numCopies";
            numCopies.Size = new Size(282, 23);
            numCopies.TabIndex = 41;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(491, 306);
            label11.Margin = new Padding(0);
            label11.Name = "label11";
            label11.Size = new Size(96, 17);
            label11.TabIndex = 42;
            label11.Text = "Copy of Books";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button4
            // 
            button4.BackColor = Color.WhiteSmoke;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 255);
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(-1, 341);
            button4.Name = "button4";
            button4.Size = new Size(156, 54);
            button4.TabIndex = 45;
            button4.Text = "       COPY OF BOOKS";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // AddBooks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(986, 595);
            Controls.Add(label11);
            Controls.Add(numCopies);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBookID);
            Controls.Add(cmbGenre);
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
            ((System.ComponentModel.ISupportInitialize)coverImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCopies).EndInit();
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
        private ComboBox cmbGenre;
        private Button button1;
        private Button button2;
        private Button btnDelete;
        private TextBox textBookID;
        private Button btnDeleteBooks;
        private Button btnBack;
        private Panel panel1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label1;
        private Button button3;
        private PictureBox coverImg;
        private Button clearBtn;
        private Label label2;
        private Panel panel2;
        private Button button4;
        private NumericUpDown numCopies;
        private Label label11;
    }
}