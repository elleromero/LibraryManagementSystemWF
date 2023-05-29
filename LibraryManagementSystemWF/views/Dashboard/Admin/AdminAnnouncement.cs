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

namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    public partial class AdminAnnouncement : Form
    {
        public AdminAnnouncement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            List<RoleEnum> roles = new();
            roles.Add(RoleEnum.ADMINISTRATOR);
            roles.Add(RoleEnum.USER);
            roles.Add(RoleEnum.LIBRARIAN);

            ControllerModifyData<Announcement> res = await AnnouncementController.Create(
                "Announcement Importantdsakjkd",
                "This is the body",
                DateTime.Now.AddMonths(12),
                roles
                
                );

            // MessageBox.Show(res.IsSuccess.ToString() + res.Result?.Header);

            foreach (KeyValuePair<string, string> error in res.Errors)
            {
                MessageBox.Show(error.Key + ": " + error.Value);
            }
        }
    }
}
