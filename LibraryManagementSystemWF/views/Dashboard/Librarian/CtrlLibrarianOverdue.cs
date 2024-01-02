using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
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

namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    public partial class CtrlLibrarianOverdue : UserControl
    {
        private List<User> users = new();
        private List<Loan> loans = new();
        private User? currentUser = null;
        private ReceiptMaker receiptMaker = new();

        public CtrlLibrarianOverdue()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            this.LoadPreview();
            this.LoadUsers();
            this.LoadDueBooks();
        }

        private void LoadPreview()
        {
            this.AddUserToPreview(new User
            {
                Username = "juan_54",
                Member = new Member
                {
                    FirstName = "Juan",
                    LastName = "Dela Cruz"
                },
                Role = new Role
                {
                    Name = "USER"
                }
            });
        }

        private void AddUserToPreview(User user)
        {
            // load default preview
            panel1.Controls.Clear();
            panel1.Controls.Add(new UserContainer(user));
        }

        private async void LoadUsers()
        {
            ControllerAccessData<User> res = await LibrarianController.GetAllUsersOnly(1);
            this.users = res.Results;

            // load columns
            dataGridUsers.Columns.Add("ID", "ID");
            dataGridUsers.Columns.Add("Username", "Username");
            dataGridUsers.Columns.Add("Name", "Name");
            dataGridUsers.Columns.Add("Course", "Course");

            foreach (User user in res.Results)
            {
                dataGridUsers.Rows.Add(
                    user.ID,
                    user.Username,
                    $"{user.Member.FirstName} {user.Member.LastName}",
                    $"{user.Member.CourseYear} - {user.Member.Program.Name}"
                    );
            }
        }

        private void LoadDueBooks()
        {
            // load columns
            dataGridDueBooks.Columns.Add("Loan ID", "Loan ID");
            dataGridDueBooks.Columns.Add("Book Title", "Book Title");
            dataGridDueBooks.Columns.Add("Date Borrowed", "Date Borrowed");
            dataGridDueBooks.Columns.Add("Price", "Price");
        }

        private void dataGridUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count > 0)
            {
                // update preview
                string id = dataGridUsers.SelectedRows[0].Cells["ID"].Value.ToString();
                this.currentUser = this.users.Find((x) => x.ID == new Guid(id));
                this.AddUserToPreview(this.currentUser);
                this.UpdateDataGridBorrowedBooks();
            }
        }

        private async void UpdateDataGridBorrowedBooks()
        {
            if (this.currentUser != null)
            {
                ControllerAccessData<Loan> res = await LoanController.GetAllBorrowedBooksPastDue(this.currentUser.ID.ToString());
                this.loans = res.Results;

                dataGridDueBooks.Rows.Clear();
                foreach (Loan loan in res.Results)
                {
                    dataGridDueBooks.Rows.Add(
                        loan.ID,
                        loan.Copy.Book.BookMetadata.Title,
                        loan.DateBorrowed,
                        loan.Copy.Price
                        );
                }
            }
        }

        private void dataGridDueBooks_SelectionChanged(object sender, EventArgs e)
        {
            // clear
            lblTotalAmountDue.Text = "0.0";
            this.receiptMaker.Clear();

            foreach (DataGridViewRow row in dataGridDueBooks.SelectedRows)
            {
                // init values
                double price = Double.Parse(row.Cells["Price"].Value.ToString());
                string itemName = $"{row.Cells["Book Title"].Value} ({row.Cells["Loan ID"].Value.ToString().Substring(0, 4)})";

                // calculate value
                double totalAmountDue = Double.Parse(lblTotalAmountDue.Text.Trim());
                totalAmountDue += price;

                // add item to receipt
                this.receiptMaker.AddItem(itemName, price);

                // set value
                lblTotalAmountDue.Text = totalAmountDue.ToString();
            }
        }

        private async void btnProceedPayment_Click(object sender, EventArgs e)
        {
            List<string> loansIdList = new();

            foreach (DataGridViewRow row in dataGridDueBooks.SelectedRows)
            {
                Loan foundLoan = this.loans.Find((x) => x.ID.ToString() == row.Cells["Loan ID"].Value.ToString());
                if (foundLoan != null) loansIdList.Add(foundLoan.ID.ToString());
            }
            Console.WriteLine(loansIdList.Count);
            ControllerAccessData<Loan> res = await LoanController.ReturnDueBooks(loansIdList);
            new ConfirmPayment(this.receiptMaker.GetReceipt()).ShowDialog();
        }
    }
}
