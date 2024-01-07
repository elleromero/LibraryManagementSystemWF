using LibraryManagementSystemWF.controllers;
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
        private Loader loader;
        private Form form;
        private ReceiptMaker receiptMaker = new();
        private bool isSearch = false;
        private int currentPage = 1;
        private int maxPage = 1;
        private double cash = 0;
        private double amountDue = 0;
        private double change = 0;

        public CtrlLibrarianOverdue(Form form)
        {
            InitializeComponent();

            this.form = form;
            this.loader = new(this.form);

            this.loader.StartLoading();
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
            dataGridUsers.Rows.Clear();
            // Handle the Controller
            try
            {
                ControllerAccessData<User> res = await LibrarianController.GetAllUsersOnly(this.currentPage);
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

                this.loader.StopLoading();
                // set page
                this.maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{currentPage} | {maxPage}";

            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error Load User: ", ex.Message);
            }
        }

        private async void LoadSearchUsers()
        {
            dataGridUsers.Rows.Clear();
            // Handle the Controller
            try
            {
                ControllerAccessData<User> res = await LibrarianController.SearchUsersOnly(txtSearch.Text, this.currentPage);
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

                this.loader.StopLoading();
                // set page
                this.maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{currentPage} | {maxPage}";

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Load User: ", ex.Message);
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
            if (txtCash.Text.ToString().Trim() != string.Empty)
            {
                this.cash = Double.Parse(txtCash.Text.ToString());
            }

            // clear
            lblTotalAmountDue.Text = "0.0";
            this.receiptMaker.Clear();

            foreach (DataGridViewRow row in dataGridDueBooks.SelectedRows)
            {
                // init values
                double price = Double.Parse(row.Cells["Price"].Value.ToString());
                string itemName = $"{row.Cells["Book Title"].Value} ({row.Cells["Loan ID"].Value.ToString().Substring(0, 4)})";

                // add item to receipt
                this.receiptMaker.AddItem(itemName, price);

                // set value
                this.amountDue = this.receiptMaker.GetTotal();
                lblTotalAmountDue.Text = this.amountDue.ToString();

                if (this.receiptMaker.GetTotal() <= this.cash)
                {
                    lblChange.Text = this.receiptMaker.GetChange(this.cash).ToString();
                }
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

            if (double.TryParse(txtCash.Text, out double ChangeCash))
            {
                ControllerAccessData<Loan> res = await LoanController.ReturnDueBooks(loansIdList, this.cash, this.amountDue);
                
                if (res.IsSuccess && this.currentUser != null)
                {
                    new ConfirmPayment(this.receiptMaker.GetReceipt(
                        $"{this.currentUser.Member.FirstName} {this.currentUser.Member.FirstName}",
                        this.currentUser.Username
                        )).ShowDialog();
                } else
                {
                    DialogBuilder.Show(res.Errors, "Error", MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Error!!");
            }

        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (double.TryParse(txtCash.Text, out double ChangeCash))
                {
                    this.cash = ChangeCash;
                    dataGridDueBooks_SelectionChanged(sender, e);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : ", ex.Message);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage < maxPage)
            {
                currentPage++;
                this.loader = new(this.form);
                loader.StartLoading();
                if (this.isSearch) LoadSearchUsers(); else LoadUsers();
            }
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage < maxPage)
            {
                currentPage++;
                this.loader = new(this.form);
                loader.StartLoading();
                if (this.isSearch) LoadSearchUsers(); else LoadUsers();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 1)
            {
                this.currentPage--;
                this.loader = new(this.form);
                loader.StartLoading();
                if (this.isSearch) LoadSearchUsers(); else LoadUsers();
            }
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 1)
            {
                this.currentPage--;
                this.loader = new(this.form);
                loader.StartLoading();
                if (this.isSearch) LoadSearchUsers(); else LoadUsers();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = true;
                this.loader = new(this.form);
                this.loader.StartLoading();
                this.currentPage = 1;
                this.LoadSearchUsers();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = false;
                this.loader = new(this.form);
                this.loader.StartLoading();
                this.currentPage = 1;
                LoadUsers();
            }
        }
    }
}
