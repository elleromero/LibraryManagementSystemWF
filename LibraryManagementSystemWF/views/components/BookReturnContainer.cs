using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views.Dashboard.Librarian;

namespace LibraryManagementSystemWF.views.components
{
    public partial class BookReturnContainer : UserControl
    {
        private Loan loan;
        private ICustomForm form;

        public BookReturnContainer(Loan loan, ICustomForm form)
        {
            InitializeComponent();

            this.loan = loan;
            this.form = form;

            lblTitle.Text = loan.Copy.Book.Title;
            lblAuthor.Text = $"by {loan.Copy.Book.Author}";
            txtDescription.Text = loan.Copy.Book.Sypnosis;
            lblCopyId.Text = $"Copy ID: {loan.Copy.ID}";
            lblDueDate.Text = $"Due on {loan.DateDue:MMM dd, yyyy 'at' h:mm tt}";

            if (File.Exists(loan.Copy.Book.Cover)) pictureBoxCover.Image = Image.FromFile(loan.Copy.Book.Cover);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new BookInformation(this.loan.Copy.Book).Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ControllerModifyData<Loan> res = await LoanController.ReturnBook(loan.ID.ToString());

            if (res.IsSuccess)
            {
                MessageBox.Show($"'{loan.Copy.Book.Title}' is returned successfully.\nCopyID: {loan.Copy.ID}");
                form.RefreshDataGrid();
            }
            else
            {
                foreach (KeyValuePair<string, string> error in res.Errors)
                {
                    MessageBox.Show($"{error.Key}: {error.Value}");
                }
            }
        }
    }
}
