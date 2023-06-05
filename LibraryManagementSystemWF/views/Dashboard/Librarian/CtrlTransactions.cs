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

namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    public partial class CtrlTransactions : UserControl
    {
        public CtrlTransactions()
        {
            InitializeComponent();

            LoadTransactions();
        }

        private async void LoadTransactions()
        {
            dataGridView1.Columns.Add("ID", "Transaction ID");
            dataGridView1.Columns.Add("CopyID", "Copy ID");
            dataGridView1.Columns.Add("Transaction", "Transaction");
            dataGridView1.Columns.Add("Timestamp", "Timestamp");

            ControllerAccessData<Loan> res = await LoanController.GetAllLoans();

            if (res.IsSuccess)
            {
                if (res.Results.Count > 0)
                {
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
                else MessageBox.Show("No records found");
            }
        }
    }
}
