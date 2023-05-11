using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.Dashboard.AdminDashboardControl;
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
        private List<Book> booksList = new List<Book>();
        public async void LoadBooks()
        {

            // Create an Instance of the BookController class
            ControllerAccessData<Book> books = await BookController.GetAllBooks();

            if (books.IsSuccess)
            {
                booksList.Clear();
                booksList.AddRange(books.Results);

                dataGridView1.DataSource = null; // Clear the data source to refresh the DataGridView
                dataGridView1.DataSource = books.Results;
            }
            else
            {
                MessageBox.Show("Error retrieving books!");
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


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        string bookId = selectedRow.Cells["ID"]?.Value?.ToString(); // Assuming the column name for the ID is "ID"

                        // Call the appropriate method from your controller to delete the book by its ID
                        if (bookId != null)
                        {
                            ControllerActionData deleteResult = await BookController.RemoveById(bookId);

                            if (deleteResult.IsSuccess)
                            {
                                MessageBox.Show("Row deleted successfully.");

                                // Remove the selected row from the BindingList
                                booksList.RemoveAt(selectedRow.Index);

                                LoadBooks();
                            }
                            else
                            {
                                MessageBox.Show("Error deleting the row. Please try again.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unable to retrieve the book ID. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the record: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            Ctrlbooks ctrlbooks = new Ctrlbooks();

            ctrlbooks.Show();
            this.Hide();

        }
    }
    }

    

