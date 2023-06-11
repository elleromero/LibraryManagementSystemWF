using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.Dashboard.Admin;
using System.Drawing;

namespace LibraryManagementSystemWF.views.components
{
    public partial class UserContainer : UserControl
    {
        private User user;

        public UserContainer(User user)
        {
            InitializeComponent();
            this.user = user;

            new ToolTip().SetToolTip(titleLbl, $"{user.Member.FirstName} {user.Member.LastName} ({user.Username})");
            panel1.BackColor = ColorTranslator.FromHtml(PastelColorGenerator.GeneratePastelColor(user.Username));
            titleLbl.Text = $"{user.Member.FirstName} {user.Member.LastName} ({user.Username})";
            subtitleLbl.Text = user.Role.Name;
            if (File.Exists(user.ProfilePicture)) pictureBox1.Image = Image.FromFile(user.ProfilePicture);
        }

        private void titleLbl_Click(object sender, EventArgs e)
        {
            new UserInformation(this.user).ShowDialog();
        }

        private void titleLbl_MouseEnter(object sender, EventArgs e)
        {
            titleLbl.ForeColor = Color.Gray;
        }

        private void titleLbl_MouseLeave(object sender, EventArgs e)
        {
            titleLbl.ForeColor = Color.Black;
        }
    }
}
