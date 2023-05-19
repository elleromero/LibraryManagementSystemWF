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
    public partial class CtrlCopies : UserControl
    {
        private List<Copy> copiesList = new List<Copy>();
        public CtrlCopies()
        {
            InitializeComponent();

            LoadCopies();

        }

        public async void LoadCopies()
        {
            // Create an instance of the CopyController class
            ControllerAccessData<Copy> copies = await CopyController.GetAllCopies();

            if (copies.IsSuccess)
            {
                copiesList.Clear();
                copiesList.AddRange(copies.Results);
                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("BookId", "BookId");
                dataGridView1.Columns.Add("Status", "Status");

                foreach (Copy copy in copiesList)
                {
                    dataGridView1.Rows.Add(copy.ID, copy.Book.ID, copy.Status.ID);
                }
            }
            else
            {
                MessageBox.Show("Error retrieving copies!");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Get the selected book's ID
                    string bookId = dataGridView1.SelectedRows[0].Cells["BookId"]?.Value?.ToString();

                    if (bookId != null)
                    {
                        int copies = Convert.ToInt32(numCopies.Value);

                        // Call the method to create copies of the book
                        ControllerModifyData<Copy> result = await CopyController.CreateCopies(bookId, copies);

                        if (result.IsSuccess)
                        {
                            MessageBox.Show($"{copies} copies of the book have been created successfully.");
                            LoadCopies();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Set the values of the text boxes to the values in the clicked row
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtBookID.Text = row.Cells["BookId"].Value.ToString();
                txtStatus.Text = row.Cells["Status"].Value.ToString();

            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        string copyId = selectedRow.Cells["BookId"]?.Value?.ToString(); // Assuming the column name for the ID is "ID"

                        // Call the appropriate method from your controller to delete the copy by its ID
                        if (copyId != null)
                        {
                            ControllerActionData deleteResult = await CopyController.RemoveById(copyId);

                            if (deleteResult.IsSuccess)
                            {
                                MessageBox.Show("Row deleted successfully.");

                                // Remove the selected row from the DataGridView
                                dataGridView1.Rows.Remove(selectedRow);
                            }
                            else
                            {
                                MessageBox.Show("Error deleting the row. Please try again.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unable to retrieve the copy ID. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the record: " + ex.Message);
            }
        }
    }
    }

