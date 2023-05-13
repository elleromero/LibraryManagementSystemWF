using LibraryManagementSystemWF.controllers;
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

namespace LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl
{
    public partial class Ctrlbooksrevamp : UserControl
    {
        private List<Book> books = new();
        private int page = 1;

        public Ctrlbooksrevamp()
        {
            InitializeComponent();
            LoadBooks();
        }

        private async void LoadBooks()
        {
            ControllerAccessData<Book> res = await BookController.GetAllBooks(page);
            
            if (res.IsSuccess)
            {
                books = res.Results;

                subtitleLbl.Text = $"You currently have {res.rowCount} book(s) registered.";

                // Fill books
                foreach (Book book in books)
                {   
                    flowLayoutPanel1.Controls.Add(new BookContainer(book));
                }
            }
        }
    }
}
