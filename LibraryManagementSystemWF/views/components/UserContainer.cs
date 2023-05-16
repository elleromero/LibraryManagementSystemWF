using LibraryManagementSystemWF.models;

namespace LibraryManagementSystemWF.views.components
{
    public partial class UserContainer : UserControl
    {
        private User user;

        public UserContainer(User user)
        {
            InitializeComponent();

            this.user = user;
            titleLbl.Text = $"{user.Member.FirstName} {user.Member.LastName} ({user.Username})";
            subtitleLbl.Text = user.Role.Name;
        }
    }
}
