using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl;
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

namespace LibraryManagementSystemWF.views.Dashboard.GeneralUser
{
    public partial class CtrlRepo : UserControl, ICustomForm
    {
        private int maxPage = 1;
        private int page = 1;
        private Loader loader;
        private Form form;

        public CtrlRepo(Form form)
        {
            InitializeComponent();

            this.form = form;
            this.loader = new(this.form);
            this.loader.StartLoading();

            LoadBorrowedBooks();

        }

        public void RefreshDataGrid()
        {
            LoadBorrowedBooks();
        }

        public async void LoadBorrowedBooks()
        {
            ControllerAccessData<Loan> res = await LoanController.GetAllBorrowedBooks();

            if (res.IsSuccess)
            {
                this.loader.StopLoading();
                flowLayoutPanel1.Controls.Clear();

                if (res.Results.Count == 0) flowLayoutPanel1.Controls.Add(new CtrlEmpty());

                // init page
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";

                foreach (Loan loan in res.Results)
                {
                    flowLayoutPanel1.Controls.Add(new BookReturnContainer(loan, this, this.form));
                }
            } else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Fetch Repo Failed", MessageBoxIcon.Hand);
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadBorrowedBooks();
            }
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page = 1;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadBorrowedBooks();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page++;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadBorrowedBooks();
            }
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page = maxPage;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadBorrowedBooks();
            }
        }
    }
}
