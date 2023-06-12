using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.Dashboard.AdminDashboardControl;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    public partial class BookInformation : Form
    {
        private Book book = new();
        private Form? form;
        private Ctrldashboard? db;

        public BookInformation(Book book, Form? form = null, Ctrldashboard? db = null)
        {
            InitializeComponent();

            this.book = book;
            this.form = form;
            this.db = db;

            // check user role
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                if (user.Role.Name == "USER")
                {
                    linkLabel1.Visible = false;
                    linkLabel1.Enabled = false;
                }
            }

            // initialize information
            LoadBook(this.book);
        }

        private void LoadBook(Book book)
        {
            if (File.Exists(book.Cover))
            {
                coverPictureBox.Image = Image.FromFile(book.Cover);
                bookCoverPictureBox.Image = Image.FromFile(book.Cover);
            }

            if (string.IsNullOrWhiteSpace(book.Genre.Name))
            {
                genreLbl.Text = "NO GENRE";
            }
            else
            {
                genreLbl.Text = book.Genre.Name;
                genreLbl.BackColor = ColorTranslator.FromHtml(PastelColorGenerator.GeneratePastelColor(book.Genre.Name));
            }

            switch (book.AvailableCopies)
            {
                case 0:
                    availableCopiesLbl.Text = "No copies available";
                    availableCopiesLbl.ForeColor = ColorTranslator.FromHtml("#ef4444");
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

            addedOnLbl.Text = book.AddedOn.ToString("MMMM d, yyyy, 'at' hh:mm tt");
            titleLbl.Text = book.Title;
            authorLbl.Text = $"by {book.Author}";
            datePublishedLbl.Text = $"Published on {book.PublicationDate.ToString("MMMM d, yyyy")}";
            txtSypnosis.Text = string.IsNullOrWhiteSpace(book.Sypnosis) ? "No sypnosis available" : book.Sypnosis;
            publisherLbl.Text = book.Publisher;
            isbnLbl.Text = book.ISBN;
        }

        public async void RefreshBook()
        {
            ControllerModifyData<Book> res = await BookController.GetBookById(this.book.ID.ToString());

            if (res.IsSuccess && res.Result != null)
            {
                this.book = res.Result;
                LoadBook(this.book);                
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (this.form != null) this.form.Enabled = true;
            if (this.db != null) this.db.LoadRecentBooks();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Enabled = false;
            new BookCopies(this.book.ID.ToString(), this).Show();
        }
    }
}
