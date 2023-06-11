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

namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    public partial class UserInformation : Form
    {
        public UserInformation(User user)
        {
            InitializeComponent();

            this.nameLbl.Text = $"{user.Member.FirstName} {user.Member.LastName}";
            this.usernameLbl.Text = $"@{user.Username}";
            this.roleLbl.Text = user.Role.Name.ToUpper();
            this.emailLbl.Text = string.IsNullOrWhiteSpace(user.Member.Email) ? "No email provided" : user.Member.Email;
            this.phoneLbl.Text = user.Member.Phone;
            this.addressLbl.Text = user.Member.Address;
        }
    }
}
