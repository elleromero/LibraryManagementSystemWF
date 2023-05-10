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
            dataGridView1 = new DataGridView();
            btnAddForm = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(42, 32);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(551, 150);
            dataGridView1.TabIndex = 0;
            // 
            // btnAddForm
            // 
            btnAddForm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddForm.Location = new Point(42, 206);
            btnAddForm.Name = "btnAddForm";
            btnAddForm.Size = new Size(106, 43);
            btnAddForm.TabIndex = 1;
            btnAddForm.Text = "ADD";
            btnAddForm.UseVisualStyleBackColor = true;
            btnAddForm.Click += btnAddForm_Click;
            // 
            // Ctrlbooks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            Controls.Add(btnAddForm);
            Controls.Add(dataGridView1);
            Name = "Ctrlbooks";
            Size = new Size(643, 388);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAddForm;
    }
}
