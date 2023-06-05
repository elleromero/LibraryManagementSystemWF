using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl.FrmBooks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystemWF.views.Dashboard
{
    public partial class Borrow : Form
    {
        private List<Book> books = new();
        private List<Book> booksList = new List<Book>();

        private int PageNumber = 1;


        public Borrow()
        {
            InitializeComponent();
            LoadBooks();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Set the values of the text boxes to the values in the clicked row

                textBookId.Text = row.Cells["ID"].Value.ToString();


            }
        }
        public async void LoadBooks()
        {
            ControllerAccessData<Book> res = await BookController.GetAllBooks();

            if (res.IsSuccess)
            {
                books = res.Results;



                // Fill books
                flowLayoutPanel1.Controls.Clear();
                if (res.Results.Count > 0)
                {
                    flowLayoutPanel1.Margin = new Padding(3);
                    // loop through results
                    foreach (Book book in books)
                    {
                        flowLayoutPanel1.Controls.Add(new BookContainer(book));
                    }
                }
                else
                {
                    // add empty template
                    flowLayoutPanel1.Margin = Padding.Empty;
                    flowLayoutPanel1.Controls.Add(new CtrlEmpty());
                }
            }

            if (res.IsSuccess)
            {
                booksList.Clear();
                booksList.AddRange(res.Results);

            }
            else
            {
                MessageBox.Show("Error!!");
            }
            dataGridView1.DataSource = null; // Clear the data source
            dataGridView1.DataSource = booksList; // Bind the booksList to the DataGridView


        }

        private void Borrow_Load(object sender, EventArgs e)
        {

        }

        public async void LoadBorrow()
        {
            ControllerAccessData<Loan> res = await LoanController.GetAllBorrowedBooks(PageNumber);

            if (res.IsSuccess)
            {
                dataGridView1.Columns.Add("BorrowDate", "Borrow date");
            }

            foreach (Loan L in res.Results)
            {
                dataGridView1.Rows.Add(L.ID, L.DateBorrowed);
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
                    DateTime dueDate = dtpDueDate.Value;

                    if (!string.IsNullOrEmpty(bookId))
                    {
                        // Call the method to create copies of the book
                        ControllerModifyData<Loan> result = await LoanController.BorrowBook(bookId);

                        if (result.IsSuccess)
                        {
                            MessageBox.Show("Loan book have been Borrow successfully.");
                            LoadBorrow();

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
                    MessageBox.Show("An error occurred while borrow books: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a book to Borrow.");
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
