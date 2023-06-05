using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl;
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
    public partial class CtrlDiscover : UserControl
    {
        private int currentPage = 1;
        private int maxPage = 1;

        public CtrlDiscover()
        {
            InitializeComponent();

            // init greeting
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                titleLbl.Text = GreetingGenerator.GenerateGreeting(user.Member.FirstName, DateTime.Now.ToString());
            }

            LoadBooks();
        }

        private async void LoadBooks()
        {
            ControllerAccessData<Book> res = await BookController.GetAllBooks(currentPage);

            flowLayoutPanel1.Controls.Add(new CtrlEmpty());

            if (res.IsSuccess)
            {
                if (res.Results.Count > 0)
                {
                    flowLayoutPanel1.Controls.Clear();

                    foreach (Book book in res.Results)
                    {
                        flowLayoutPanel1.Controls.Add(new BookBorrowContainer(book));
                    }
                }
            }
            else MessageBox.Show("Can't fetch books at the moment.");
        }
    }
}
