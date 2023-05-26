using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl.FrmBooks;
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
    public partial class Ctrlbooksrevamp : UserControl
    {
        private List<Book> books = new();
        private int page = 1;
        private int maxPage = 1;

        public Ctrlbooksrevamp()
        {
            InitializeComponent();
            LoadBooks();
        }

        public async void LoadBooks()
        {
            ControllerAccessData<Book> res = await BookController.GetAllBooks(page);
            
            if (res.IsSuccess)
            {
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
                        flowLayoutPanel1.Controls.Add(new BookContainer(book));
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

                // init pagination buttons
                prevLastBtn.Enabled = page > 1;
                prevBtn.Enabled = page > 1;

                nextLastBtn.Enabled = page < maxPage;
                nextBtn.Enabled = page < maxPage;

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new AddBooks().Show(this);
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            page = 1;
            LoadBooks();
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            page = maxPage;
            LoadBooks();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            page += 1;
            LoadBooks();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            page -= 1;
            LoadBooks();
        }
    }
}
