using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public BookInformation(Book book)
        {
            InitializeComponent();

            this.book = book;

            // initialize information
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
            titleLbl.Text = book.Title;
            authorLbl.Text = $"by {book.Author}";
            datePublishedLbl.Text = $"Published on {book.PublicationDate.ToString("MMMM d, yyyy")}";
            txtSypnosis.Text = string.IsNullOrWhiteSpace(book.Sypnosis) ? "No sypnosis available" : book.Sypnosis;
            publisherLbl.Text = book.Publisher;
            isbnLbl.Text = book.ISBN;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
