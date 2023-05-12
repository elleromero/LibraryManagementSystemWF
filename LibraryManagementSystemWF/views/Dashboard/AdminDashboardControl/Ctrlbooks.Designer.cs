namespace LibraryManagementSystemWF.Dashboard.AdminDashboardControl
{
    partial class Ctrlbooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ctrlbooks));
            dataGridView1 = new DataGridView();
            btnAddForm = new Button();
            btnupdate = new Button();
            btnremove = new Button();
            button2 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(608, 174);
            dataGridView1.TabIndex = 0;
            // 
            // btnAddForm
            // 
            btnAddForm.BackColor = Color.FromArgb(254, 206, 47);
            btnAddForm.FlatAppearance.BorderSize = 0;
            btnAddForm.FlatStyle = FlatStyle.Flat;
            btnAddForm.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddForm.Location = new Point(16, 261);
            btnAddForm.Name = "btnAddForm";
            btnAddForm.Size = new Size(202, 26);
            btnAddForm.TabIndex = 1;
            btnAddForm.Text = "ADD";
            btnAddForm.UseVisualStyleBackColor = false;
            btnAddForm.Click += btnAddForm_Click;
            // 
            // btnupdate
            // 
            btnupdate.BackColor = Color.FromArgb(254, 206, 47);
            btnupdate.FlatAppearance.BorderSize = 0;
            btnupdate.FlatStyle = FlatStyle.Flat;
            btnupdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnupdate.Location = new Point(224, 261);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(183, 26);
            btnupdate.TabIndex = 2;
            btnupdate.Text = "UPDATE";
            btnupdate.UseVisualStyleBackColor = false;
            btnupdate.Click += btnupdate_Click;
            // 
            // btnremove
            // 
            btnremove.BackColor = Color.FromArgb(254, 206, 47);
            btnremove.FlatAppearance.BorderSize = 0;
            btnremove.FlatStyle = FlatStyle.Flat;
            btnremove.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnremove.Location = new Point(413, 261);
            btnremove.Name = "btnremove";
            btnremove.Size = new Size(211, 26);
            btnremove.TabIndex = 3;
            btnremove.Text = "DELETE";
            btnremove.UseVisualStyleBackColor = false;
            btnremove.Click += btnremove_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(12, 20);
            button2.Name = "button2";
            button2.Size = new Size(37, 35);
            button2.TabIndex = 11;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(53, 20);
            label1.Name = "label1";
            label1.Size = new Size(99, 37);
            label1.TabIndex = 12;
            label1.Text = "Books";
            // 
            // Ctrlbooks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(btnremove);
            Controls.Add(btnupdate);
            Controls.Add(btnAddForm);
            Controls.Add(dataGridView1);
            Name = "Ctrlbooks";
            Size = new Size(643, 388);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAddForm;
        private Button btnupdate;
        private Button btnremove;
        private Button button2;
        private Label label1;
    }
}
