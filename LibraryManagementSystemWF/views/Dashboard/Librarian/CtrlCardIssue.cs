using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.loader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    public partial class CtrlCardIssue : UserControl
    {
        private bool isSearch = false;
        private int maxPage = 1;
        private int currentPage = 1;
        private Loader loader;
        private Form form;
        private List<User> users;
        private User currentUser;
        private Image qr;

        public CtrlCardIssue(Form form)
        {
            InitializeComponent();

            this.form = form;
            this.loader = new(this.form);
            this.Init();
        }

        private void Init()
        {
            this.loader.StartLoading();
            LoadUsers();
            LoadPreview();
            this.loader.StopLoading();
        }

        private async void LoadUsers()
        {
            ControllerAccessData<User> res = await LibrarianController.GetAllUsersOnly(this.currentPage);
            this.SetData(res);
        }

        private async void LoadSearchUsers()
        {
            ControllerAccessData<User> res = await LibrarianController.SearchUsersOnly(txtSearch.Text, this.currentPage);
            this.SetData(res);
        }

        private void LoadPreview()
        {

            this.AddUserToPreview(new User
            {
                Username = "juan_54",
                Member = new Member
                {
                    FirstName = "Juan",
                    LastName = "Dela Cruz"
                },
                Role = new Role
                {
                    Name = "USER"
                }
            });
        }

        private void AddUserToPreview(User user)
        {
            // load default preview
            panel1.Controls.Clear();
            panel1.Controls.Add(new UserContainer(user));
        }

        private void SetData(ControllerAccessData<User> res)
        {
            dataGridUsers.Rows.Clear();

            // load columns
            dataGridUsers.Columns.Add("ID", "ID");
            dataGridUsers.Columns.Add("Username", "Username");
            dataGridUsers.Columns.Add("Name", "Name");
            dataGridUsers.Columns.Add("Course", "Course");

            this.users = res.Results;
            foreach (User user in res.Results)
            {
                dataGridUsers.Rows.Add(
                    user.ID,
                    user.Username,
                    $"{user.Member.FirstName} {user.Member.LastName}",
                    $"{user.Member.CourseYear} - {user.Member.Program.Name}"
                    );
            }

            if (res.IsSuccess)
            {
                this.loader.StopLoading();
                // set page
                this.maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{currentPage} | {maxPage}";
            }
        }

        private void dataGridUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count > 0)
            {
                // update preview
                string id = dataGridUsers.SelectedRows[0].Cells["ID"].Value.ToString();
                this.currentUser = this.users.Find((x) => x.ID == new Guid(id));
                this.AddUserToPreview(this.currentUser);
                this.qr = QRMaker.GenerateQR(this.currentUser.ID.ToString(), 162);
                pictureBox1.Image = this.qr;
            }
        }

        private void dataGridUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage < maxPage)
            {
                currentPage++;
                this.loader = new(this.form);
                loader.StartLoading();
                if (this.isSearch) LoadSearchUsers(); else LoadUsers();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage < maxPage)
            {
                currentPage++;
                this.loader = new(this.form);
                loader.StartLoading();
                if (this.isSearch) LoadSearchUsers(); else LoadUsers();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 1)
            {
                this.currentPage--;
                this.loader = new(this.form);
                loader.StartLoading();
                if (this.isSearch) LoadSearchUsers(); else LoadUsers();
            }
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 1)
            {
                this.currentPage--;
                this.loader = new(this.form);
                loader.StartLoading();
                if (this.isSearch) LoadSearchUsers(); else LoadUsers();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = false;
                this.loader = new(this.form);
                this.loader.StartLoading();
                this.currentPage = 1;
                LoadUsers();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = true;
                this.loader = new(this.form);
                this.loader.StartLoading();
                this.currentPage = 1;
                this.LoadSearchUsers();
            }
        }

        private void btnIssueCard_Click(object sender, EventArgs e)
        {
            Loader loader = new(this.form);

            loader.StartLoading();
            //PowerpointBuilder.UpdatePowerPointFile("../../../resources/templates/LIBRARY-ID-CARD.pptx", "TESTING EHE");
            string basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = Path.Combine(basePath, "resources", "templates", "LIBRARY-ID-CARD.pptx");
            new PowerpointBuilder(path).Modify(
                this.qr,
                this.currentUser.Member.SchoolNumber,
                this.currentUser.ID.ToString(),
                $"{this.currentUser.Member.FirstName} {this.currentUser.Member.LastName}",
                $"{(this.currentUser.Member.CourseYear != null ? this.currentUser.Member.CourseYear.ToString() : "UNKNOWN")}",
                $"{(this.currentUser.Member.Program.Description != null ? this.currentUser.Member.Program.Description : "UNKNOWN")}",
                this.currentUser.ProfilePicture,
                true
                );

            loader.StopLoading();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loader loader = new(this.form);

            loader.StartLoading();

            string basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = Path.Combine(basePath, "resources", "library_id");

            if (Directory.Exists(path))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = path,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }

            loader.StopLoading();
        }
    }
}

