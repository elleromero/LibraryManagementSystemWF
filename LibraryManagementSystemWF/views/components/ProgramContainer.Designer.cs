namespace LibraryManagementSystemWF.views.components
{
    partial class ProgramContainer
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.titleLbl = new System.Windows.Forms.Label();
            this.colorStrip = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(15, 35);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(271, 69);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Text = "No Description Given";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoEllipsis = true;
            this.titleLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLbl.Location = new System.Drawing.Point(15, 9);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(271, 23);
            this.titleLbl.TabIndex = 4;
            this.titleLbl.Text = "Program Title";
            // 
            // colorStrip
            // 
            this.colorStrip.BackColor = System.Drawing.Color.Tomato;
            this.colorStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorStrip.Location = new System.Drawing.Point(0, 0);
            this.colorStrip.Name = "colorStrip";
            this.colorStrip.Size = new System.Drawing.Size(5, 121);
            this.colorStrip.TabIndex = 3;
            // 
            // ProgramContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.colorStrip);
            this.Name = "ProgramContainer";
            this.Size = new System.Drawing.Size(291, 121);
            this.Click += new System.EventHandler(this.ProgContainer_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtDescription;
        private Label titleLbl;
        private Panel colorStrip;
    }
}
