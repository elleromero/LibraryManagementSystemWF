using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl.FrmBooks;
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

namespace LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl
{
    public partial class Ctrlbooksrevamp : UserControl, ICustomForm
    {
        private List<Book> books = new();
        private int page = 1;
        private int maxPage = 1;
        private Loader loader;
        private Form form;
        private bool isSearch;

        public Ctrlbooksrevamp(Form form)
        {
            InitializeComponent();

            this.form = form;
            this.isSearch = false;
            this.loader = new(this.form);
            this.loader.StartLoading();

            LoadBooks();
        }

        public async void LoadSearchBooks()
        {
            ControllerAccessData<Book> res = await BookController.Search(txtSearch.Text, page);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                books = res.Results;

                subtitleLbl.Text = $"{res.rowCount} book(s) found.";

                // Fill books
                flowLayoutPanel1.Controls.Clear();
                if (res.Results.Count > 0)
                {
                    flowLayoutPanel1.Margin = new Padding(3);
                    // loop through results
                    foreach (Book book in books)
                    {
                        flowLayoutPanel1.Controls.Add(new BookContainer(book, false, this.form, this));
                    }
                }
                else
                {
                    // add empty template
                    flowLayoutPanel1.Margin = Padding.Empty;
                    flowLayoutPanel1.Controls.Add(new CtrlEmpty());
                }

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Fetch Books", MessageBoxIcon.Hand);
            }
        }

        public async void LoadBooks()
        {
            ControllerAccessData<Book> res = await BookController.GetAllBooks(page);
            
            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                books = res.Results;

                subtitleLbl.Text = $"You currently have {res.rowCount} book(s) registered.";

                // Fill books
                flowLayoutPanel1.Controls.Clear();
                if (res.Results.Count > 0)
                {
                    flowLayoutPanel1.Margin = new Padding(3);
                    // loop through results
                    foreach (Book book in books)
                    {
                        flowLayoutPanel1.Controls.Add(new BookContainer(book, false, this.form, this));
                    }
                }
                else
                {
                    // add empty template
                    flowLayoutPanel1.Margin = Padding.Empty;
                    flowLayoutPanel1.Controls.Add(new CtrlEmpty());
                }

                // init page label
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";
            } else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Fetch Books", MessageBoxIcon.Hand);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new AddBooks(this, this.form).Show();
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page = 1;
                this.loader = new(this.form);
                this.loader.StartLoading();
                if (this.isSearch) LoadSearchBooks(); else LoadBooks();
            }
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page = maxPage;
                this.loader = new(this.form);
                this.loader.StartLoading();
                if (this.isSearch) LoadSearchBooks(); else LoadBooks();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page++;
                this.loader = new(this.form);
                this.loader.StartLoading();
                if (this.isSearch) LoadSearchBooks(); else LoadBooks();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
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
                this.page = 1;
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
                this.page = 1;
                LoadBooks();
            }
        }

        public void RefreshDataGrid()
        {
            this.txtSearch.Clear();
            this.page = 1;
            LoadBooks();
        }
    }
}
