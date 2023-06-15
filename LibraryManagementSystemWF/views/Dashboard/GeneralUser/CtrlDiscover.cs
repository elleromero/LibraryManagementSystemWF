using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
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
    public partial class CtrlDiscover : UserControl, ICustomForm
    {
        private int currentPage = 1;
        private int maxPage = 1;
        private Form form;
        private Loader loader;
        private bool isSearch;

        public CtrlDiscover(Form form)
        {
            InitializeComponent();

            this.form = form;
            this.isSearch = false;
            this.loader = new(this.form);
            this.loader.StartLoading();

            // init greeting
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                titleLbl.Text = GreetingGenerator.GenerateGreeting(user.Member.FirstName, DateTime.Now.ToString());
            }

            LoadBooks();
        }

        public async void LoadBooks()
        {
            ControllerAccessData<Book> res = await BookController.GetAllBooks(currentPage);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                flowLayoutPanel1.Controls.Clear();

                if (res.Results.Count == 0)
                {
                    flowLayoutPanel1.Controls.Add(new CtrlEmpty());
                    DialogBuilder.Show("No books available at the moment", "Fetch Books", MessageBoxIcon.Information);
                }

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{currentPage} | {maxPage}";

                foreach (Book book in res.Results)
                {
                    flowLayoutPanel1.Controls.Add(new BookBorrowContainer(book, this, this.form));
                }
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Fetch Books Failed", MessageBoxIcon.Hand);
            }
        }

        private async void LoadSearchBooks()
        {
            ControllerAccessData<Book> res = await BookController.Search(txtSearch.Text, currentPage);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                flowLayoutPanel1.Controls.Clear();

                if (res.Results.Count == 0)
                {
                    flowLayoutPanel1.Controls.Add(new CtrlEmpty());
                }

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{currentPage} | {maxPage}";

                foreach (Book book in res.Results)
                {
                    flowLayoutPanel1.Controls.Add(new BookBorrowContainer(book, this, this.form));
                }
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Fetch Books Failed", MessageBoxIcon.Hand);
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                this.loader = new(this.form);
                this.loader.StartLoading();
                if (this.isSearch) LoadSearchBooks(); else LoadBooks();
            }
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                this.loader = new(this.form);
                this.loader.StartLoading();
                if (this.isSearch) LoadSearchBooks(); else LoadBooks();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage++;
                this.loader = new(this.form);
                this.loader.StartLoading();
                if (this.isSearch) LoadSearchBooks(); else LoadBooks();
            }
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage = maxPage;
                this.loader = new(this.form);
                this.loader.StartLoading();
                if (this.isSearch) LoadSearchBooks(); else LoadBooks();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = true;
                this.loader = new(this.form);
                this.loader.StartLoading();
                this.currentPage = 1;
                LoadSearchBooks();
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
                LoadBooks();
            }
        }

        public void RefreshDataGrid()
        {
            this.txtSearch.Clear();
            this.currentPage = 1;
            if (this.isSearch) LoadSearchBooks(); else LoadBooks();
        }
    }
}
