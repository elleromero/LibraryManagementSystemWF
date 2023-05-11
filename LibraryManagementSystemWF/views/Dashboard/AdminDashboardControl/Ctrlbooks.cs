using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views;
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

namespace LibraryManagementSystemWF.Dashboard.AdminDashboardControl
{
    public partial class Ctrlbooks : UserControl
    {
        private List<Book> booksList = new List<Book>();
        public async void LoadBooks()
        {

            // Create an Instance of the BookController class
            ControllerAccessData<Book> books = await BookController.GetAllBooks();

            if (books.IsSuccess)
            {

                dataGridView1.DataSource = books.Results;

            }
            else
            {
                MessageBox.Show("Error!!");
            }

        }
        public Ctrlbooks()
        {
            InitializeComponent();

            LoadBooks();

        }


        private void btnAddForm_Click(object sender, EventArgs e)
        {
            AddBooks addbooks = new AddBooks();

            addbooks.Show();

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            AddBooks addbooks = new AddBooks();

            addbooks.Show();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            AddBooks addbooks = new AddBooks();

            addbooks.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminDashboard AD = new AdminDashboard();
            AD.Show();
            this.Hide();
        }
    }
}
