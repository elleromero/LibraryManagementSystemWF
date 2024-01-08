using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    public partial class ConfirmPayment : Form
    {
        public ConfirmPayment(string txt)
        {
            InitializeComponent();

            richTextBox1.Text = txt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 20, 20);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            PrintDialog dialog = new PrintDialog();
            dialog.Document = document;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }
    }
}
