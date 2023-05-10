using LibraryManagementSystemWF.controllers;
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

namespace LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl.FrmBooks
{
    public partial class AddBooks : Form
    {

        public async void LoadBooks()
        {

            // Create an Instance of the BookController class
            ControllerAccessData<Book> books = await BookController.GetAllBooks();

            // Display the Book List in the DataGridView
            if (books.IsSuccess)
            {

                dataGridView1.DataSource = books.Results;

            }
            else
            {
                MessageBox.Show("Error!!");
            }

        }

        public async void LoadGenres()
        {
            // Creating an Instance of the GenreController class
            ControllerAccessData<Genre> genres = await GenreController.GetAllGenres();

            // Adding the result of Genre in the ComboBox
            if (genres.IsSuccess)
            {
                foreach (Genre genre in genres.Results)
                {
                    cmbGenre.Items.Add(genre);
                }
            }
            else
            {
                MessageBox.Show("Error retrieving genres!");
            }
        }

        public AddBooks()
        {
            InitializeComponent();

            LoadBooks();
            LoadGenres();
        }

    

        private async void button1_Click(object sender, EventArgs e)
        {

            // Temporary Genre
            Genre Genre = (Genre)cmbGenre.SelectedItem;
            string Title = txtTitle.Text;
            string Author = txtAuthor.Text;
            string Publisher = txtPublisher.Text;
            DateTime PublicationDate = dtpPublicationDate.Value;
            string ISBN = txtISBN.Text;
            string Cover = txtCover.Text;
            string Sypnosis = txtSynopsis.Text;


            // Add the new book to the database using the BookController class
            ControllerModifyData<Book> result = await BookController.CreateBook(Genre.ID, Title, Author, Publisher, PublicationDate, ISBN, Cover, Sypnosis);

            if (result.IsSuccess)
            {
                // Clear the textboxes and other controls
                cmbGenre.SelectedIndex = -1;
                txtTitle.Text = "";
                txtAuthor.Text = "";
                txtPublisher.Text = "";
                dtpPublicationDate.Value = DateTime.Now;
                txtISBN.Text = "";
                txtCover.Text = "";
                txtSynopsis.Text = "";

                // Refresh the book list in the DataGridView
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Error!!");
            }
        }
    }
}
