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

namespace LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl
{
    public partial class CtrlGenre : UserControl
    {
        private List<Genre> genresList = new List<Genre>();

        private int currentPage = 1;

        public async void LoadGenres(int page)
        {
            // Creating an Instance of the GenreController class
            ControllerAccessData<Genre> genres = await GenreController.GetAllGenres(page);

            if (genres.IsSuccess)
            {
                genresList = genres.Results;

                dataGridView1.Rows.Clear(); // Clear existing rows before adding new ones

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("Description", "Description");

                foreach (Genre genre in genresList)
                {
                    dataGridView1.Rows.Add(
                        genre.ID,
                        genre.Name,
                        genre.Description
                    );
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

            int initialPage = 1;

            LoadGenres(initialPage);

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = txtDescription.Text;

            ControllerModifyData<Genre> result = await GenreController.CreateGenre(name, description);

            if (result.IsSuccess)
            {
                Genre genre = result.Result;
                genresList.Add(genre);

                int initialPage = 1;
                LoadGenres(initialPage);

                // Clear input fields
                txtName.Text = "";
                txtDescription.Text = "";
            }
            else
            {
                string errorMessage = result.Errors.FirstOrDefault().Value;
                MessageBox.Show("Failed to create genre: " + errorMessage);
            }
        }

        private async void btnUpdateGenre_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Retrieve the genre ID from the selected row
                if (int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int genreId))
                {
                    // Retrieve the updated values from the input fields
                    string name = txtName.Text;
                    string description = txtDescription.Text;

                    // Update the genre
                    ControllerModifyData<Genre> result = await GenreController.UpdateGenre(genreId, name, description);

                    if (result.IsSuccess)
                    {
                        // Update the genresList with the modified genre
                        Genre updatedGenre = result.Result;
                        int index = genresList.FindIndex(g => g.ID == genreId);
                        if (index >= 0)
                        {
                            genresList[index] = updatedGenre;
                        }

                        int initialPage = 1;
                        LoadGenres(initialPage);

                        // Clear input fields
                        txtName.Text = "";
                        txtDescription.Text = "";
                    }
                    else
                    {
                        string errorMessage = result.Errors.FirstOrDefault().Value;
                        MessageBox.Show("Failed to update genre: " + errorMessage);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a genre to update.");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell clickedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string cellValue = clickedCell.Value.ToString();

                // Display the cell value in a separate control or message box
                MessageBox.Show(cellValue, "Cell Value");
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Reload data from the database
                int initialPage = 1;
                LoadGenres(initialPage);
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Set the values of the text boxes to the values in the clicked row
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadGenres(currentPage);
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
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        if (int.TryParse(selectedRow.Cells["ID"]?.Value?.ToString(), out int genreId))
                        {
                            // Call the appropriate method from your controller to delete the genre by its ID
                            ControllerActionData deleteResult = await GenreController.RemoveById(genreId);

                            if (deleteResult.IsSuccess)
                            {
                                MessageBox.Show("Row deleted successfully.");

                                // Remove the selected row from the DataGridView
                                dataGridView1.Rows.Remove(selectedRow);

                                // You may need to remove the genre from the genresList as well if it's being used elsewhere in your code

                                // Optional: Reload the data to refresh the DataGridView
                                int initialPage = 1;
                                LoadGenres(initialPage);
                            }
                            else
                            {
                                MessageBox.Show("Error deleting the row. Please try again.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid genre ID. Please try again.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            txtID.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";

        }
    }
    }

