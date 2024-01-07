using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.loader;
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
        private BookInformation form;
        private Loader loader;

        public BookCopies(string bookId, BookInformation form)
        {
            InitializeComponent();

            this.bookId = bookId;
            this.form = form;

            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("BookId", "BookId");
            dataGridView1.Columns.Add("Source", "Source");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("StatusName", "Status");

            this.loader = new(this);
            this.loader.StartLoading();

            this.LoadCopies();
            this.LoadSources();
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

        public async void LoadSources()
        {
            ControllerAccessData<Source> res = await SourceController.GetAllSources();

            if (res.IsSuccess)
            {
                cmbSource.ValueMember = nameof(Source.ID);
                cmbSource.DisplayMember = nameof(Source.Name);
                cmbSource.DataSource = res.Results;
            }
        }

        public async void LoadCopies()
        {
            // Create an instance of the CopyController class
            ControllerAccessData<Copy> copies = await CopyController.GetAllCopiesWithBook(bookId, currentPage);

            if (copies.IsSuccess)
            {
                this.loader.StopLoading();
                dataGridView1.Rows.Clear();

                if (copies.Results.Count == 0) DialogBuilder.Show("No copies found", "Fetch Copies", MessageBoxIcon.Information);

                foreach (Copy copy in copies.Results)
                {
                    dataGridView1.Rows.Add(copy.ID, copy.Book.ID, copy.Source.Name, copy.Price.ToString(), copy.Status.Name);
                }

                if (copies.Results.Count > 0)
                {
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
                }

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)copies.rowCount / 10));
                pageLbl.Text = $"{currentPage} | {maxPage}";
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(copies.Errors, "Fetch Copies", MessageBoxIcon.Hand);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.form.Enabled = true;
            this.Close();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadCopies();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage++;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadCopies();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected copy?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    string copyId = selectedRow.Cells["ID"]?.Value?.ToString(); // Assuming the column name for the ID is "ID"

                    // Call the appropriate method from your controller to delete the copy by its ID
                    if (copyId != null)
                    {
                        this.loader = new(this);
                        this.loader.StartLoading();

                        ControllerActionData deleteResult = await CopyController.RemoveById(copyId);

                        if (deleteResult.IsSuccess) {
                            this.loader.StopLoading();
                            this.form.RefreshBook();
                            DialogBuilder.Show("Row removed successfully.", "Remove Copy", MessageBoxIcon.Information);

                            LoadCopies();
                        } else
                        {
                            this.loader.StopLoading();
                            DialogBuilder.Show(deleteResult.Errors, "Remove Copy Error", MessageBoxIcon.Hand);
                        }
                    }
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int copies = Convert.ToInt32(numCopies.Value);
            Source source = (Source)cmbSource.SelectedItem;
            decimal price = numPrice.Value;

            this.loader = new(this);
            this.loader.StartLoading();

            // Call the method to create copies of the book
            ControllerModifyData<Copy> result = await CopyController.CreateCopies(this.bookId, source.ID, price, copies);

            if (result.IsSuccess && result.Result != null)
            {
                this.loader.StopLoading();
                this.form.RefreshBook();
                DialogBuilder.Show($"{copies} copies of the book have been created successfully.", "Add Copies", MessageBoxIcon.Information);
                LoadCopies();
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(result.Errors, "Copy Error", MessageBoxIcon.Hand);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string copyId = selectedRow.Cells["ID"]?.Value?.ToString(); // Assuming the column name for the ID is "ID"
                Source source = (Source)cmbSource.SelectedItem;
                decimal price = numPrice.Value;


                // Call the appropriate method from your controller to delete the copy by its ID
                if (copyId != null)
                {
                    this.loader = new(this);
                    this.loader.StartLoading();

                    ControllerModifyData<Copy> res = await CopyController.UpdateCopy(copyId, source.ID, price);

                    if (res.IsSuccess)
                    {
                        this.loader.StopLoading();
                        this.form.RefreshBook();
                        DialogBuilder.Show("Row updated successfully.", "Update Copy", MessageBoxIcon.Information);

                        LoadCopies();
                    }
                    else
                    {
                        this.loader.StopLoading();
                        DialogBuilder.Show(res.Errors, "Update Copy Error", MessageBoxIcon.Hand);
                    }
                }
            }
        }
    }
}
