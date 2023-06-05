using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
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

namespace LibraryManagementSystemWF.views.Dashboard.GeneralUser
{
    public partial class CtrlRepo : UserControl, ICustomForm
    {
        public CtrlRepo()
        {
            InitializeComponent();

            LoadBorrowedBooks();
        }

        public void RefreshDataGrid()
        {
            LoadBorrowedBooks();
        }

        private async void LoadBorrowedBooks()
        {
            ControllerAccessData<Loan> res = await LoanController.GetAllBorrowedBooks();

            flowLayoutPanel1.Controls.Clear();

            if (res.IsSuccess)
            {
                if (res.Results.Count > 0)
                {
                    foreach (Loan loan in res.Results)
                    {
                        flowLayoutPanel1.Controls.Add(new BookReturnContainer(loan, this));
                    }
                }
                else MessageBox.Show("No records found");
            }
        }
    }
}
