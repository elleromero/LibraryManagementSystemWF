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

namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    public partial class CtrlTransactions : UserControl
    {
        private int page = 1;
        private int maxPage = 1;
        private Form form;
        private Loader loader;

        public CtrlTransactions(Form form)
        {
            InitializeComponent();

            this.form = form;

            this.loader = new(this.form);
            this.loader.StartLoading();

            dataGridView1.Columns.Add("ID", "Transaction ID");
            dataGridView1.Columns.Add("CopyID", "Copy ID");
            dataGridView1.Columns.Add("Transaction", "Transaction");
            dataGridView1.Columns.Add("Timestamp", "Timestamp");

            LoadTransactions();
        }

        private async void LoadTransactions()
        {
            ControllerAccessData<Loan> res = await LoanController.GetAllLoans(page);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                if (res.Results.Count == 0) DialogBuilder.Show("No transactions recorded yet", "Fetch Transactions", MessageBoxIcon.Information);

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";

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
            } else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Fetch Transactions Failed", MessageBoxIcon.Hand);
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadTransactions();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page++;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadTransactions();
            }
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page = maxPage;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadTransactions();
            }
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page = 1;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadTransactions();
            }
        }
    }
}
