using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views.components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl
{
    public partial class CtrlGenre : UserControl
    {
        private List<Genre> genresList = new List<Genre>();
        private int maxPage = 1;
        private int currentPage = 1;

        public void SelectGenre(Genre genre)
        {
            txtID.Text = genre.ID.ToString();
            txtName.Text = genre.Name;
            txtDescription.Text = genre.Description;

            foreach (GenreContainer genreContainer in flowLayoutPanel1.Controls)
            {
                genreContainer.Clear();
            }
        }

        public async void LoadGenres(int page)
        {
            // Creating an Instance of the GenreController class
            ControllerAccessData<Genre> genres = await GenreController.GetAllGenres(page);

            if (genres.IsSuccess)
            {
                genresList = genres.Results;
                this.maxPage = Math.Max(1, (int)Math.Ceiling((double)genres.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";

                // Load genres on flow layout panel
                flowLayoutPanel1.Controls.Clear();
                
                foreach (Genre genre in genresList)
                {
                    flowLayoutPanel1.Controls.Add(new GenreContainer(genre, this));
                }
            }
            else
            {
                MessageBox.Show("Error retrieving genres!");
            }

        }

        public CtrlGenre()
        {
            InitializeComponent();

            LoadGenres(currentPage);

        }

        private void Clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";

            foreach (GenreContainer genreContainer in flowLayoutPanel1.Controls)
            {
                genreContainer.Clear();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = txtDescription.Text;

            ControllerModifyData<Genre> result = await GenreController.CreateGenre(name, description);

            if (result.IsSuccess && result.Result != null)
            {
                Genre genre = result.Result;
                genresList.Add(genre);

                LoadGenres(currentPage);

                // Clear input fields
                this.Clear();
            }
            else
            {
                string errorMessage = result.Errors.FirstOrDefault().Value;
                MessageBox.Show("Failed to create genre: " + errorMessage);
            }
        }

        private async void btnUpdateGenre_Click(object sender, EventArgs e)
        {
            // Retrieve the updated values from the input fields
            string name = txtName.Text;
            string description = txtDescription.Text;
            int genreId = Convert.ToInt32(txtID.Text);

            // Update the genre
            ControllerModifyData<Genre> result = await GenreController.UpdateGenre(genreId, name, description);

            if (result.IsSuccess && result.Result != null)
            {
                // Update the genresList with the modified genre
                Genre updatedGenre = result.Result;
                int index = genresList.FindIndex(g => g.ID == genreId);
                if (index >= 0)
                {
                    genresList[index] = updatedGenre;
                }

                LoadGenres(currentPage);

                // Clear input fields
                this.Clear();
            }
            else
            {
                string errorMessage = result.Errors.FirstOrDefault().Value;
                MessageBox.Show("Failed to update genre: " + errorMessage);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage++;
                LoadGenres(currentPage);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadGenres(currentPage);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int genreId = Convert.ToInt32(txtID.Text);

            // Call the appropriate method from your controller to delete the genre by its ID
            ControllerActionData deleteResult = await GenreController.RemoveById(genreId);

            if (deleteResult.IsSuccess)
            {
                MessageBox.Show("Row deleted successfully.");

                // Optional: Reload the data to refresh the DataGridView
                LoadGenres(currentPage);
            }
            else
            {
                MessageBox.Show("Error deleting the row. Please try again.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            this.Clear();
        }
    }
    }

