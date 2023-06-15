using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.Dashboard.GeneralUser;
using LibraryManagementSystemWF.views.Dashboard.Librarian;
using LibraryManagementSystemWF.views.loader;
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
        private CtrlDiscover ctrlDiscover;
        private Form form;
        private Book book;
        private Loader loader;

        public BookBorrowContainer(Book book, CtrlDiscover ctrlDiscover, Form form)
        {
            InitializeComponent();

            this.ctrlDiscover = ctrlDiscover;
            this.form = form;
            this.book = book;
            this.loader = new(this.form);

            lblTitle.Text = book.Title;
            lblAuthor.Text = $"by {book.Author}";
            txtDescription.Text = book.Sypnosis;
            
            if (File.Exists(book.Cover)) pictureBoxCover.Image = Image.FromFile(book.Cover);

            switch (book.AvailableCopies)
            {
                case 0:
                    availableCopiesLbl.Text = "No copies available";
                    availableCopiesLbl.ForeColor = ColorTranslator.FromHtml("#ef4444");
                    borrowBtn.Enabled = false;
                    break;
                case 1:
                    availableCopiesLbl.Text = "Last copy available";
                    availableCopiesLbl.ForeColor = ColorTranslator.FromHtml("#fcd34d");
                    break;
                default:
                    availableCopiesLbl.Text = $"{book.AvailableCopies} copies available";
                    availableCopiesLbl.ForeColor = ColorTranslator.FromHtml("#4ade80");
                    break;
            }
        }

        private void viewMoreBtn_Click(object sender, EventArgs e)
        {
            new BookInformation(this.book).ShowDialog();
        }

        private async void borrowBtn_Click(object sender, EventArgs e)
        {
            this.loader = new(this.form);
            this.loader.StartLoading();

            ControllerModifyData<Loan> res = await LoanController.BorrowBook(this.book.ID.ToString());

            if (res.IsSuccess)
            {
                this.loader.StopLoading();
                this.ctrlDiscover.LoadBooks();
                DialogBuilder.Show($"'{book.Title}' is borrowed succesfully. Check your repo.", "Borrow Book", MessageBoxIcon.Information);
            } else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Borrow Book Failed", MessageBoxIcon.Hand);
            }
        }
    }
}
