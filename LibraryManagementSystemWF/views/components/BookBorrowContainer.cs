using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views.Dashboard.Librarian;
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
    public partial class BookBorrowContainer : UserControl
    {
        private Book book;
        public BookBorrowContainer(Book book)
        {
            InitializeComponent();

            this.book = book;

            lblTitle.Text = book.Title;
            lblAuthor.Text = $"by {book.Author}";
            txtDescription.Text = book.Sypnosis;
            
            if (File.Exists(book.Cover)) pictureBoxCover.Image = Image.FromFile(book.Cover);
        }

        private void viewMoreBtn_Click(object sender, EventArgs e)
        {
            //new BookInformation(this.book).Show();
        }

        private async void borrowBtn_Click(object sender, EventArgs e)
        {
            ControllerModifyData<Loan> res = await LoanController.BorrowBook(this.book.ID.ToString());

            if (res.IsSuccess)
            {
                MessageBox.Show($"'{book.Title}' is borrowed succesfully. Check your repo.");
            } else
            {
                foreach (KeyValuePair<string, string> error in res.Errors)
                {
                    MessageBox.Show($"{error.Key}: {error.Value}");
                }
            }
        }
    }
}
