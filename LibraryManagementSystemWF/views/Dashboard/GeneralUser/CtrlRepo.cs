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
        private bool isSearch;
        private List<Loan> loansList = new();

        public CtrlRepo(Form form)
        {
            InitializeComponent();

            this.form = form;
            this.isSearch = false;
            this.loader = new(this.form);
            this.loader.StartLoading();

            LoadBorrowedBooks();

        }

        public void RefreshDataGrid()
        {
            this.txtSearch.Clear();
            this.page = 1;
            LoadBorrowedBooks();
        }

        private async void LoadSearchBorrowedBooks()
        {
            ControllerAccessData<Loan> res = await LoanController.Search(txtSearch.Text, page);

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
            }
            else
            {
                this.loader.StopLoading();

            }
        }

        public async void LoadBorrowedBooks()
        {
            ControllerAccessData<Loan> res = await LoanController.GetAllBorrowedBooks(page);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();
                flowLayoutPanel1.Controls.Clear();

                if (res.Results.Count == 0) flowLayoutPanel1.Controls.Add(new CtrlEmpty());

                // init page
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";

                this.loansList = res.Results;
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
                if (this.isSearch) LoadSearchBorrowedBooks(); else LoadBorrowedBooks();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page++;
                this.loader = new(this.form);
                this.loader.StartLoading();
                if (this.isSearch) LoadSearchBorrowedBooks(); else LoadBorrowedBooks();
            }
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page = maxPage;
                this.loader = new(this.form);
                this.loader.StartLoading();
                if (this.isSearch) LoadSearchBorrowedBooks(); else LoadBorrowedBooks();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = true;
                this.loader = new(this.form);
                this.loader.StartLoading();
                this.page = 1;
                LoadSearchBorrowedBooks();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = false;
                this.loader = new(this.form);
                this.loader.StartLoading();
                this.page = 1;
                LoadBorrowedBooks();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new BorrowerCard(this.loansList).ShowDialog();
        }
    }
}
