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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    public partial class BookCopies : Form
    {
        private string bookId;
        private int maxPage = 1;
        private int currentPage = 1;

        public BookCopies(string bookId)
        {
            InitializeComponent();

            this.bookId = bookId;
            this.LoadCopies();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Set the values of the text boxes to the values in the clicked row
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtBookId.Text = row.Cells["BookId"].Value.ToString();
                txtStatus.Text = row.Cells["StatusName"].Value.ToString();

            }
        }

        public async void LoadCopies()
        {
            // Create an instance of the CopyController class
            ControllerAccessData<Copy> copies = await CopyController.GetAllCopiesWithBook(bookId, currentPage);

            if (copies.IsSuccess)
            {
                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("BookId", "BookId");
                dataGridView1.Columns.Add("StatusName", "Status");

                foreach (Copy copy in copies.Results)
                {
                    dataGridView1.Rows.Add(copy.ID, copy.Book.ID, copy.Status.Name);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string val = (string)row.Cells[dataGridView1.Columns.Count - 1].Value;
                    
                    switch (val.ToUpper())
                    {
                        case "AVAILABLE":
                            row.Cells[dataGridView1.Columns.Count - 1].Style.BackColor = ColorTranslator.FromHtml("#4ade80");
                            break;
                        case "NOT AVAILABLE":
                            row.Cells[dataGridView1.Columns.Count - 1].Style.BackColor = ColorTranslator.FromHtml("#f87171");
                            break;
                        case "ON HOLD":
                            row.Cells[dataGridView1.Columns.Count - 1].Style.BackColor = ColorTranslator.FromHtml("#facc15");
                            break;
                    }
                }

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)copies.rowCount / 10));
                pageLbl.Text = $"{currentPage} | {maxPage}";

                // init pagination buttons
                prevBtn.Enabled = currentPage > 1;

                nextBtn.Enabled = currentPage < maxPage;
            }
            else
            {
                MessageBox.Show("Error retrieving copies!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            currentPage -= 1;
            LoadCopies();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            currentPage += 1;
            LoadCopies();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        string copyId = selectedRow.Cells["ID"]?.Value?.ToString(); // Assuming the column name for the ID is "ID"

                        // Call the appropriate method from your controller to delete the copy by its ID
                        if (copyId != null)
                        {
                            ControllerActionData deleteResult = await CopyController.RemoveById(copyId);

                            if (deleteResult.IsSuccess)
                            {
                                MessageBox.Show("Row deleted successfully.");

                                // Remove the selected row from the DataGridView
                                LoadCopies();
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

        private async void button2_Click(object sender, EventArgs e)
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
    }
}
