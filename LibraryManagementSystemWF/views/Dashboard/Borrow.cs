using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystemWF.views.Dashboard
{
    public partial class Borrow : Form
    {
        private List<Book> books = new();
        public Borrow()
        {
            InitializeComponent();
            LoadBooks();
        }

        public async void LoadBooks()
        {
            ControllerAccessData<Book> res = await BookController.GetAllBooks();

            if (res.IsSuccess)
            {
                books = res.Results;



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
            }


        }
    }
}
