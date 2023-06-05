using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.components
{
    public partial class BookReturnContainer : UserControl
    {
        private Loan loan;

        public BookReturnContainer(Loan loan)
        {
            InitializeComponent();

            this.loan = loan;

            lblTitle.Text = loan.Copy.Book.Title;
            lblAuthor.Text = $"by {loan.Copy.Book.Author}";
            txtDescription.Text = loan.Copy.Book.Sypnosis;
            lblCopyId.Text = $"Copy ID: {loan.Copy.ID}";
            lblDueDate.Text = $"Due on {loan.DateDue:MMM dd, yyyy 'at' h:mm tt}";

            if (File.Exists(loan.Copy.Book.Cover)) pictureBoxCover.Image = Image.FromFile(loan.Copy.Book.Cover);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new BookContainer(this.loan.Copy.Book).Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ControllerModifyData<Loan> res = await LoanController.ReturnBook(loan.ID.ToString());
        }
    }
}
