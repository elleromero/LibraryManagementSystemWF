using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.dao;
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
        private List<Genre> genresList = new List<Genre>();
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


            /*            // Adding the result of Genre in the ComboBox
                        if (genres.IsSuccess)
                        {
                            foreach (Genre genre in genres.Results)
                            {
                                cmbGenre.Items.Add(genre.Name);


                            }
                        }
                        else
                        {
                            MessageBox.Show("Error retrieving genres!");
                        }*/
            genresList = genres.Results;

            if (genres.IsSuccess)
            {
                for (int i = 0; i < genres.Results.Count; i++)
                {
                    Genre genre = genresList[i];
                    cmbGenre.ValueMember = nameof(Genre.ID);
                    cmbGenre.DisplayMember = nameof(Genre.Name);
                    cmbGenre.DataSource = genresList;

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


            if (cmbGenre.SelectedItem != null)
            {
                Genre selectedGenre = (Genre)cmbGenre.SelectedItem;
                int selectedGenreId = selectedGenre.ID;
                string BookId = textBookID.Text;
                string Title = txtTitle.Text;
                string Author = txtAuthor.Text;
                string Publisher = txtPublisher.Text;
                DateTime PublicationDate = dtpPublicationDate.Value;
                string ISBN = txtISBN.Text;
                string Cover = txtCover.Text;
                string Sypnosis = txtSynopsis.Text;

                ControllerModifyData<Book> result = await BookController.CreateBook(selectedGenreId, Title, Author, Publisher, PublicationDate, ISBN, Cover, Sypnosis);

                if (result.IsSuccess)
                {
                    cmbGenre.SelectedIndex = -1;
                    textBookID.Text = "";
                    txtTitle.Text = "";
                    txtAuthor.Text = "";
                    txtPublisher.Text = "";
                    dtpPublicationDate.Value = DateTime.Now;
                    txtISBN.Text = "";
                    txtCover.Text = "";
                    txtSynopsis.Text = "";

                    LoadBooks();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        MessageBox.Show(error.Value);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a genre.");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (cmbGenre.SelectedItem != null)
            {
                Genre selectedGenre = (Genre)cmbGenre.SelectedItem;
                int selectedGenreId = selectedGenre.ID;

                string BookId = textBookID.Text;
                string Title = txtTitle.Text;
                string Author = txtAuthor.Text;
                string Publisher = txtPublisher.Text;
                DateTime PublicationDate = dtpPublicationDate.Value;
                string ISBN = txtISBN.Text;
                string Cover = txtCover.Text;
                string Sypnosis = txtSynopsis.Text;

                ControllerModifyData<Book> result = await BookController.UpdateBook(
                    new Guid(BookId).ToString(), selectedGenreId, Title, Author, Publisher, PublicationDate, ISBN, Cover, Sypnosis);


                if (result.IsSuccess)
                {
                    cmbGenre.SelectedIndex = -1;
                    textBookID.Text = "";
                    txtTitle.Text = "";
                    txtAuthor.Text = "";
                    txtPublisher.Text = "";
                    dtpPublicationDate.Value = DateTime.Now;
                    txtISBN.Text = "";
                    txtCover.Text = "";
                    txtSynopsis.Text = "";

                    LoadBooks();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        MessageBox.Show(error.Value);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a genre.");
            }
        }
    }
}


