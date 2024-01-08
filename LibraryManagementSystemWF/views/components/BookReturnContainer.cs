using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.Dashboard.Librarian;
using LibraryManagementSystemWF.views.loader;

namespace LibraryManagementSystemWF.views.components
{
    public partial class BookReturnContainer : UserControl
    {
        private Loan loan;
        private ICustomForm form;
        private Form parentForm;
        private Loader loader;

        public BookReturnContainer(Loan loan, ICustomForm form, Form parentForm, bool isGuest = false)
        {
            InitializeComponent();

            this.loan = loan;
            this.form = form;
            this.parentForm = parentForm;
            this.loader = new(this.parentForm);

            lblTitle.Text = loan.Copy.Book.BookMetadata.Title;
            lblAuthor.Text = $"by {loan.Copy.Book.BookMetadata.Author}";
            txtDescription.Text = loan.Copy.Book.BookMetadata.Sypnosis;
            lblCopyId.Text = $"Copy ID: {loan.Copy.ID}";
            lblDueDate.Text = $"Due on {loan.DateDue:MMM dd, yyyy 'at' h:mm tt}";

            if (File.Exists(loan.Copy.Book.BookMetadata.Cover)) pictureBoxCover.Image = Image.FromFile(loan.Copy.Book.BookMetadata.Cover);
            if (isGuest)
            {
                button1.Hide();
                button2.Hide();
                txtDescription.Size = new Size(txtDescription.Size.Width, 80);
                lblCopyId.Location = new Point(lblCopyId.Location.X, 143);
                lblDueDate.Location = new Point(lblDueDate.Location.X, 162);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new BookInformation(this.loan.Copy.Book).ShowDialog();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.loader = new(this.parentForm);
            this.loader.StartLoading();

            ControllerModifyData<Loan> res = await LoanController.ReturnBook(loan.ID.ToString());

            if (res.IsSuccess)
            {
                this.loader.StopLoading();
                DialogBuilder.Show($"'{loan.Copy.Book.BookMetadata.Title}' is returned successfully.\nCopyID: {loan.Copy.ID}", "Return Book", MessageBoxIcon.Information);
                form.RefreshDataGrid();
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Return Book Failed", MessageBoxIcon.Hand);
            }
        }
    }
}
