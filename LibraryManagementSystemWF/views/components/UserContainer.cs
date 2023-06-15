using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.Dashboard.Admin;
using System.Drawing;

namespace LibraryManagementSystemWF.views.components
{
    public partial class UserContainer : UserControl
    {
        private User user;
        private bool isPreview;

        public UserContainer(User user, bool isPreview = false)
        {
            InitializeComponent();
            this.user = user;
            this.isPreview = isPreview;

            new ToolTip().SetToolTip(titleLbl, $"{user.Member.FirstName} {user.Member.LastName} ({user.Username})");
            panel1.BackColor = ColorTranslator.FromHtml(PastelColorGenerator.GeneratePastelColor(user.Username));
            titleLbl.Text = $"{user.Member.FirstName} {user.Member.LastName} ({user.Username})";
            subtitleLbl.Text = user.Role.Name;
            if (File.Exists(user.ProfilePicture)) pictureBox1.Image = Image.FromFile(user.ProfilePicture);
            this.isPreview = isPreview;

        }

        private void titleLbl_Click(object sender, EventArgs e)
        {
            if (!isPreview) new UserInformation(this.user).ShowDialog();
        }

        private void titleLbl_MouseEnter(object sender, EventArgs e)
        {
            if (!isPreview) titleLbl.ForeColor = Color.Gray;
        }

        private void titleLbl_MouseLeave(object sender, EventArgs e)
        {
            if (!isPreview) titleLbl.ForeColor = Color.Black;
        }
    }
}
