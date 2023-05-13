using LibraryManagementSystemWF.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.components
{
    public partial class BookContainer : UserControl
    {
        private Book book = new();

        public BookContainer(Book book)
        {
            InitializeComponent();
            this.book = book;
            new ToolTip().SetToolTip(titleLbl, book.Title);
            titleLbl.Text = book.Title;
            authorLbl.Text = book.Author;

            if (File.Exists(book.Cover)) pictureBox1.Image = Image.FromFile(book.Cover);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            topPanel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not yet implemented!");
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            topPanel.Visible = true;
            topPanel.BringToFront();
        }
    }
}
