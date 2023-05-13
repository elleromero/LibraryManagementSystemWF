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
            titleLbl.Text = book.Title;
            authorLbl.Text = book.Author;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            topPanel.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            topPanel.Visible = false;
        }
    }
}
