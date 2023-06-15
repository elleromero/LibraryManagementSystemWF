using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
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
    public partial class CtrlTransactions : UserControl
    {
        private int page;
        private int maxPage;
        private Form form;

        public CtrlTransactions()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("ID", "Transaction ID");
            dataGridView1.Columns.Add("CopyID", "Copy ID");
            dataGridView1.Columns.Add("Transaction", "Transaction");
            dataGridView1.Columns.Add("Timestamp", "Timestamp");

            LoadTransactions();
        }

        private async void LoadTransactions()
        {
            ControllerAccessData<Loan> res = await LoanController.GetAllLoans();

            if (res.IsSuccess)
            {
                if (res.Results.Count == 0) DialogBuilder.Show("No transactions recorded yet", "Fetch Transactions", MessageBoxIcon.Information);

                foreach (Loan loan in res.Results)
                {
                    string transaction = $"{loan.User.Username} " +
                        $"{(loan.IsReturned ? "returned" : "borrowed")} " +
                        $"{loan.Copy.Book.Title}";

                    dataGridView1.Rows.Add(
                        loan.ID,
                        loan.Copy.ID,
                        transaction,
                        loan.Timestamp.ToString("MMM dd, yyyy 'at' h:mm tt")
                        );
                }
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                LoadTransactions();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page++;
                LoadTransactions();
            }
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page = maxPage;
                LoadTransactions();
            }
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page = 1;
                LoadTransactions();
            }
        }
    }
}
