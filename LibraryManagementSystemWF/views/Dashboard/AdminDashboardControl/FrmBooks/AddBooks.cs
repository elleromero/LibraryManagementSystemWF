using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.Dashboard.AdminDashboardControl;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.loader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl.FrmBooks
{
    public partial class AddBooks : Form
    {
        private List<Genre> genresList = new List<Genre>();
        private List<Book> booksList = new List<Book>();
        private Ctrlbooksrevamp ctrlbookRevamp;
        private Form parentForm;
        private bool isInitialized = true;
        private int currentPage = 1;
        private int maxPage = 1;
        private Loader loader;

        private void defaultPreview()
        {
            isInitialized = true;

            // load default preview
            panel2.Controls.Clear();
            panel2.Controls.Add(new BookContainer(new Book
            {
                Cover = "",
                Author = "J. K. Rowling",
                Title = "Harry Potter"
            }, true));

            isInitialized = false;
        }

        public async void LoadBooks()
        {

            // Create an Instance of the BookController class
            ControllerAccessData<Book> books = await BookController.GetAllBooks();

            if (books.IsSuccess)
            {
                this.loader.StopLoading();

                if (books.Results.Count == 0) DialogBuilder.Show("No books found", "Fetch Books", MessageBoxIcon.Information);

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)books.rowCount / 20));
                pageLbl.Text = $"{currentPage} | {maxPage}";

                booksList.Clear();
                booksList.AddRange(books.Results);
                dataGridView1.Rows.Clear(); // Clear existing rows before adding new ones

                foreach (Book book in books.Results)
                {
                    dataGridView1.Rows.Add(
                        book.ID,
                        book.AvailableCopies,
                        book.Title,
                        book.Genre.Name,
                        book.Author,
                        book.Publisher,
                        book.Sypnosis,
                        book.PublicationDate,
                        book.ISBN,
                        book.Cover
                        );

                }

            }
            else
            {
                this.loader.StopLoading();
                MessageBox.Show("Error retrieving books!");
            }
        }

        public async void LoadGenres()
        {
            // Creating an Instance of the GenreController class
            ControllerAccessData<Genre> genres = await GenreController.GetAllGenres();

            genresList = genres.Results;

            if (genres.IsSuccess)
            {
                if (genresList.Count == 0) DialogBuilder.Show("No genres found", "Fetch Genres", MessageBoxIcon.Information);

                for (int i = 0; i < genres.Results.Count; i++)
                {
                    Genre genre = genresList[i];
                    cmbGenre.ValueMember = nameof(Genre.ID);
                    cmbGenre.DisplayMember = nameof(Genre.Name);
                    cmbGenre.DataSource = genresList;

                }
            }
        }

        public AddBooks(Ctrlbooksrevamp ctrlbookrevamp, Form form)
        {
            InitializeComponent();

            this.ctrlbookRevamp = ctrlbookrevamp;
            this.parentForm = form;
            this.parentForm.Enabled = false;

            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Copies", "Copies");
            dataGridView1.Columns.Add("Title", "Title");
            dataGridView1.Columns.Add("Genre", "Genre");
            dataGridView1.Columns.Add("Author", "Author");
            dataGridView1.Columns.Add("Publisher", "Publisher");
            dataGridView1.Columns.Add("Sypnosis", "Sypnosis");
            dataGridView1.Columns.Add("PubDate", "Publication Date");
            dataGridView1.Columns.Add("ISBN", "ISBN");
            dataGridView1.Columns.Add("Cover", "Cover");

            this.loader = new(this);
            this.loader.StartLoading();

            LoadBooks();
            LoadGenres();

            defaultPreview();
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
                int copies = (int)numCopies.Value;

                this.loader = new(this);
                this.loader.StartLoading();

                ControllerModifyData<Book> result = await BookController.CreateBook(selectedGenreId, Title, Author, Publisher, PublicationDate, ISBN, copies, Cover, Sypnosis);

                if (result.IsSuccess)
                {
                    DialogBuilder.Show("Book created successfully", "Create Book", MessageBoxIcon.Information);

                    LoadBooks();
                    ctrlbookRevamp.LoadBooks();
                    clearBtn.PerformClick();
                }
                else
                {
                    this.loader.StopLoading();
                    DialogBuilder.Show(result.Errors, "Create Book Failed", MessageBoxIcon.Hand);
                }
            }
            else
            {
                DialogBuilder.Show("Please select a genre.", "Alert", MessageBoxIcon.Information);
            }

        }

        private async void button2_Click_1(object sender, EventArgs e)
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

                this.loader = new(this);
                this.loader.StartLoading();

                ControllerModifyData<Book> result = await BookController.UpdateBook(
                    BookId, selectedGenreId, Title, Author, Publisher, PublicationDate, ISBN, Cover, Sypnosis);


                if (result.IsSuccess)
                {
                    cmbGenre.SelectedIndex = 0;
                    textBookID.Text = "";
                    txtTitle.Text = "";
                    txtAuthor.Text = "";
                    txtPublisher.Text = "";
                    dtpPublicationDate.Value = DateTime.Now;
                    txtISBN.Text = "";
                    txtCover.Text = "";
                    txtSynopsis.Text = "";
                    coverImg.Image = null;

                    DialogBuilder.Show("Book updated successfully", "Update Book", MessageBoxIcon.Information);

                    LoadBooks();
                    ctrlbookRevamp.LoadBooks();
                    clearBtn.PerformClick();
                }
                else
                {
                    this.loader.StopLoading();
                    DialogBuilder.Show(result.Errors, "Update Book Failed", MessageBoxIcon.Hand);
                }
            }
            else
            {
                DialogBuilder.Show("Please select a genre.", "Alert", MessageBoxIcon.Information);
            }

        }

        private async void btnDeleteBooks_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    string? bookId = selectedRow.Cells["ID"]?.Value?.ToString(); // Assuming the column name for the ID is "ID"

                    // Call the appropriate method from your controller to delete the book by its ID
                    if (bookId != null)
                    {
                        this.loader = new(this);
                        this.loader.StartLoading();

                        ControllerActionData deleteResult = await BookController.RemoveById(bookId);

                        if (deleteResult.IsSuccess)
                        {
                            DialogBuilder.Show("Book removed successfully", "Remove Book", MessageBoxIcon.Information);

                            // Remove the selected row from the BindingList
                            booksList.RemoveAt(selectedRow.Index);

                            LoadBooks();
                            ctrlbookRevamp.LoadBooks();
                            clearBtn.PerformClick();
                        }
                        else
                        {
                            this.loader.StopLoading();
                            DialogBuilder.Show(deleteResult.Errors, "Remove Book Failed", MessageBoxIcon.Hand);
                        }
                    }
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.parentForm.Enabled = true;
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                txtCover.Text = imagePath;
                coverImg.Image = Image.FromFile(imagePath);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Set the values of the text boxes to the values in the clicked row
                textBookID.Text = row.Cells["ID"].Value.ToString();
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtAuthor.Text = row.Cells["Author"].Value.ToString();
                txtPublisher.Text = row.Cells["Publisher"].Value.ToString();
                dtpPublicationDate.Value = DateTime.Parse(row.Cells["PubDate"].Value.ToString());
                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
                txtCover.Text = row.Cells["Cover"].Value.ToString();
                txtSynopsis.Text = row.Cells["Sypnosis"].Value.ToString();
                numCopies.Value = (int)row.Cells["Copies"].Value;
                cmbGenre.Text = row.Cells["Genre"].Value.ToString();

                // disable num copies
                numCopies.Enabled = false;

                // update image
                if (File.Exists(txtCover.Text))
                {
                    coverImg.Image = Image.FromFile(txtCover.Text);
                }
                else coverImg.Image = null;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            cmbGenre.SelectedIndex = 0;
            textBookID.Text = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtPublisher.Text = "";
            dtpPublicationDate.Value = DateTime.Now;
            txtISBN.Text = "";
            txtCover.Text = "";
            txtSynopsis.Text = "";
            coverImg.Image = null;
            numCopies.Value = 1;

            // enable num copies
            numCopies.Enabled = true;

            defaultPreview();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                // refresh preview
                panel2.Controls.Clear();
                panel2.Controls.Add(new BookContainer(new Book
                {
                    Cover = txtCover.Text,
                    Author = txtAuthor.Text,
                    Title = txtTitle.Text
                }, true));
            }

            isInitialized = false;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Get the selected book's ID
                    string bookId = dataGridView1.SelectedRows[0].Cells["ID"]?.Value?.ToString();

                    if (bookId != null)
                    {
                        int copies = Convert.ToInt32(numCopies.Value);

                        // Call the method to create copies of the book
                        ControllerModifyData<Copy> result = await CopyController.CreateCopies(bookId, copies);

                        if (result.IsSuccess)
                        {
                            MessageBox.Show($"{copies} copies of the book have been created successfully.");
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
                        MessageBox.Show("Unable to retrieve the book ID. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while creating copies: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a book to create copies.");
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadBooks();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage++;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadBooks();
            }
        }
    }
}



