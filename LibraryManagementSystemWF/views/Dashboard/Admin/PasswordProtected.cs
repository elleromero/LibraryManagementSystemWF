
namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    public partial class PasswordProtected : Form
    {
        private AdminMenu form;

        public PasswordProtected(AdminMenu form)
        {
            InitializeComponent();

            this.form = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form.setAdminPassword(passwordTxt.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
