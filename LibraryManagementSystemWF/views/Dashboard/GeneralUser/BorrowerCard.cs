using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
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
    public partial class BorrowerCard : Form
    {
        private List<Loan> listLoans;
        private User? guest;

        public BorrowerCard(List<Loan> loans, User? guest = null)
        {
            InitializeComponent();

            this.listLoans = loans;
            this.guest = guest;

            dataGridView1.Columns.Add("Due On", "Due On");
            dataGridView1.Columns.Add("Book Title", "Book Title");
            dataGridView1.Columns.Add("Is Returned", "Is Returned");

            LoadInfo();
        }

        private void LoadInfo()
        {
            // Load user
            User? user = this.guest != null ? this.guest : AuthService.getSignedUser();

            if (user != null)
            {
                lblName.Text = $"{user.Member.FirstName} {user.Member.LastName}";
                lblEmail.Text = string.IsNullOrWhiteSpace(user.Member.Email) ? "No email provided" : user.Member.Email;
                lblUsername.Text = user.Username;
                lblUserId.Text = user.ID.ToString();

                if (File.Exists(user.ProfilePicture)) profilePicture.Image = Image.FromFile(user.ProfilePicture);
            }

            // load loans
            foreach (Loan loan in listLoans)
            {
                dataGridView1.Rows.Add(
                    loan.DateDue.ToString("MMMM dd',' yyyy 'at' hh:mm:ss tt"),
                    loan.Copy.Book.BookMetadata.Title,
                    loan.IsReturned ? "Yes" : "No"
                    );
            }

            // load qr
            transactionQr.Image = BarcodeMaker.BuildQR(Guid.NewGuid().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrinterUtil printUtil = new(this, 50);
            printUtil.Print();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
