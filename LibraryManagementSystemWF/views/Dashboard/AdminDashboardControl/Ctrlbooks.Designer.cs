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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddForm = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnremove = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(608, 174);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAddForm
            // 
            this.btnAddForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.btnAddForm.FlatAppearance.BorderSize = 0;
            this.btnAddForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddForm.Location = new System.Drawing.Point(16, 261);
            this.btnAddForm.Name = "btnAddForm";
            this.btnAddForm.Size = new System.Drawing.Size(202, 26);
            this.btnAddForm.TabIndex = 1;
            this.btnAddForm.Text = "ADD";
            this.btnAddForm.UseVisualStyleBackColor = false;
            this.btnAddForm.Click += new System.EventHandler(this.btnAddForm_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnupdate.Location = new System.Drawing.Point(224, 261);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(183, 26);
            this.btnupdate.TabIndex = 2;
            this.btnupdate.Text = "UPDATE";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnremove
            // 
            this.btnremove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(47)))));
            this.btnremove.FlatAppearance.BorderSize = 0;
            this.btnremove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnremove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnremove.Location = new System.Drawing.Point(413, 261);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(211, 26);
            this.btnremove.TabIndex = 3;
            this.btnremove.Text = "DELETE";
            this.btnremove.UseVisualStyleBackColor = false;
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(12, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 35);
            this.button2.TabIndex = 11;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(53, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 37);
            this.label1.TabIndex = 12;
            this.label1.Text = "Books";
            // 
            // Ctrlbooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnremove);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnAddForm);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Ctrlbooks";
            this.Size = new System.Drawing.Size(710, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
