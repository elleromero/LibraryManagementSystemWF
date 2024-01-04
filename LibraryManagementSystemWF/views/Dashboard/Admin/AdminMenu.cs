using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl;
using LibraryManagementSystemWF.views.loader;
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
    public partial class AdminMenu : Form
    {
        private AdminDashboard adminDashboard;
        private string adminPassword = "";
        private bool isInitialized = true;
        private Loader loader;
        private int page = 1;
        private int maxPage = 1;
        private bool isSearch = false;

        public AdminMenu(AdminDashboard adminDashboard)
        {
            InitializeComponent();

            this.adminDashboard = adminDashboard;

            // init columns
            usersGridList.Columns.Add("ID", "ID");
            usersGridList.Columns.Add("Username", "Username");
            usersGridList.Columns.Add("Role", "Role");
            usersGridList.Columns.Add("School Number", "School Number");
            usersGridList.Columns.Add("First Name", "First Name");
            usersGridList.Columns.Add("Last Name", "Last Name");
            usersGridList.Columns.Add("Address", "Address");
            usersGridList.Columns.Add("Phone", "Phone");
            usersGridList.Columns.Add("Email", "Email");
            usersGridList.Columns.Add("Profile Picture", "Profile Picture");
            usersGridList.Columns.Add("Program", "Program");
            usersGridList.Columns.Add("Course Year", "Course Year");

            this.loader = new(this);
            this.loader.StartLoading();

            LoadUsers();
            LoadRoles();
            LoadPrograms();

            defaultPreview();
            this.DisableButtons();
        }

        private void defaultPreview()
        {
            isInitialized = true;

            // load default preview
            panel2.Controls.Clear();
            panel2.Controls.Add(new UserContainer(new User
            {
                Username = "juan_54",
                Member = new Member
                {
                    FirstName = "Juan",
                    LastName = "Dela Cruz"
                },
                Role = new Role
                {
                    Name = "ADMINISTRATOR"
                }
            }, true));
        }

        private async void LoadSearchUsers()
        {
            ControllerAccessData<User> res = await AdminController.Search(txtSearch.Text, page);

            this.SetData(res);
        }

        private async void LoadUsers()
        {
            ControllerAccessData<User> res = await AdminController.GetAllUsers(page);

            this.SetData(res);
        }

        private void SetData(ControllerAccessData<User> res)
        {
            if (res.IsSuccess)
            {
                loader.StopLoading();

                // set page
                this.maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";

                if (res.Results.Count == 0) DialogBuilder.Show("No Users Found", "Information", MessageBoxIcon.Information);

                usersGridList.Rows.Clear(); // Clear existing rows before adding new ones

                foreach (User user in res.Results)
                {
                    usersGridList.Rows.Add(
                        user.ID,
                        user.Username,
                        user.Role.Name,
                        user.Member.SchoolNumber,
                        user.Member.FirstName,
                        user.Member.LastName,
                        user.Member.Address,
                        user.Member.Phone,
                        user.Member.Email,
                        user.ProfilePicture,
                        user.Member.Program.Name,
                        user.Member.CourseYear
                        );
                }

            }
            else
            {
                loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Error Fetching Users", MessageBoxIcon.Hand);
            }
        }

        private async void LoadRoles()
        {
            ControllerAccessData<Role> res = await RoleController.GetAllRoles();

            if (res.IsSuccess)
            {
                for (int i = 0; i < res.Results.Count; i++)
                {
                    cmbRole.ValueMember = nameof(Genre.ID);
                    cmbRole.DisplayMember = nameof(Genre.Name);
                    cmbRole.DataSource = res.Results;
                }
            }
        }

        private async void LoadPrograms()
        {
            ControllerAccessData<models.Program> res = await ProgramController.GetAllPrograms();

            if (res.IsSuccess)
            {
                for (int i = 0; i < res.Results.Count; i++)
                {
                    cmbProgram.ValueMember = nameof(models.Program.ID);
                    cmbProgram.DisplayMember = nameof(models.Program.Name);
                    cmbProgram.DataSource = res.Results;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.adminDashboard.Enabled = true;
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem != null)
            {
                Role selectedRole = (Role)cmbRole.SelectedItem;
                models.Program selectedProgram = (models.Program)cmbProgram.SelectedItem;
                int selectedRoleId = selectedRole.ID;
                int? selectedProgramId = selectedProgram.ID;
                string SchoolNumber = SchoolNum.Text;
                string Username = textUsername.Text;
                string Password = textPassword.Text;
                string FirstName = textFirstName.Text;
                string LastName = textLastName.Text;
                string Address = textAddress.Text;
                string Phone = textPhone.Text;
                string Email = textEmail.Text;
                string ProfilePicture = txtProfile.Text;
                int CourseYear = (int)numCourseYear.Value;

                this.loader = new(this);
                this.loader.StartLoading();

                ControllerModifyData<User> res = await AdminController.CreateUser(
                    Username,
                    Password,
                    FirstName,
                    LastName,
                    SchoolNumber, 
                    Address,
                    Phone,
                    selectedRoleId,
                    Email,
                    ProfilePicture,
                    selectedProgramId,
                    CourseYear 
                    );

                if (res.IsSuccess)
                {
                    this.loader.StopLoading();

                    this.page = 1;
                    LoadUsers();
                    adminDashboard.RefreshDataGrid();
                    clearBtn.PerformClick();

                    DialogBuilder.Show("User added successfully", "Add User", MessageBoxIcon.Information);
                }
                else
                {
                    this.loader.StopLoading();

                    DialogBuilder.Show(res.Errors, "Add User Error", MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Please select a role.");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string UserId = textUserID.Text;
            string SchoolNumber = SchoolNum.Text;
            string Username = textUsername.Text;
            string Password = textPassword.Text;
            string FirstName = textFirstName.Text;
            string LastName = textLastName.Text;
            string Address = textAddress.Text;
            string Phone = textPhone.Text;
            string Email = textEmail.Text;
            string ProfilePicture = txtProfile.Text;
            models.Program selectedProgram = (models.Program)cmbProgram.SelectedItem;
            int? selectedProgramId = selectedProgram.ID;
            int CourseYear = (int)numCourseYear.Value;

            // show password confirmation dialog
            PasswordProtected passProtected = new(this);

            if (passProtected.ShowDialog() == DialogResult.OK)
            {
                this.loader = new(this);
                this.loader.StartLoading();

                ControllerModifyData<User> res = await AdminController.UpdateUser(
                    UserId,
                    Username,
                    Password,
                    FirstName,
                    LastName,
                    SchoolNumber,
                    Address,
                    Phone,
                    this.adminPassword,
                    Email,
                    ProfilePicture,
                    selectedProgramId,
                    CourseYear
                    );

                this.adminPassword = "";

                if (res.IsSuccess)
                {
                    this.loader.StopLoading();

                    this.page = 1;
                    LoadUsers();
                    adminDashboard.RefreshDataGrid();
                    clearBtn.PerformClick();

                    DialogBuilder.Show("User updated successfully", "Update User", MessageBoxIcon.Information);
                }
                else
                {
                    this.loader.StopLoading();

                    DialogBuilder.Show(res.Errors, "Update User Error", MessageBoxIcon.Hand);
                }
            }

        }

        public void setAdminPassword(string adminPassword)
        {
            this.adminPassword = adminPassword;
        }

        private void usersList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (usersGridList.SelectedRows.Count <= 0)
            {
                this.clearBtn_Click(sender, e);
            }
            else if (e.RowIndex >= 0)
            {
                DataGridViewRow row = usersGridList.Rows[e.RowIndex];

                // Set the values of the text boxes to the values in the clicked row
                textUserID.Text = row.Cells["ID"].Value.ToString();
                textUsername.Text = row.Cells["Username"].Value.ToString();
                SchoolNum.Text = row.Cells["School Number"].Value.ToString();
                cmbRole.Text = row.Cells["Role"].Value.ToString();
                textFirstName.Text = row.Cells["First Name"].Value.ToString();
                textLastName.Text = row.Cells["Last Name"].Value.ToString();
                textAddress.Text = row.Cells["Address"].Value.ToString();
                textPhone.Text = row.Cells["Phone"].Value.ToString();
                textEmail.Text = row.Cells["Email"].Value.ToString();
                txtProfile.Text = row.Cells["Profile Picture"].Value.ToString();

                if (row.Cells["Program"].Value != null) cmbProgram.Text = row.Cells["Program"].Value.ToString();
                if (row.Cells["Course Year"].Value != null) numCourseYear.Value = Decimal.Parse(row.Cells["Course Year"].Value.ToString());

                // update image
                if (File.Exists(txtProfile.Text))
                {
                    pictureBox1.Image = Image.FromFile(txtProfile.Text);
                }
                else pictureBox1.Image = null;

                // disable role
                cmbRole.Enabled = false;
                textUserID.Enabled = false;
            }
            this.DisableButtons();

        }

        private async void btnDeleteBooks_Click(object sender, EventArgs e)
        {
            if (usersGridList.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // show password confirmation dialog
                    PasswordProtected passProtected = new(this);

                    if ((passProtected.ShowDialog() == DialogResult.OK) && (result == DialogResult.Yes))
                    {
                        DataGridViewRow selectedRow = usersGridList.SelectedRows[0];

                        string userId = selectedRow.Cells["ID"]?.Value?.ToString(); // Assuming the column name for the ID is "ID"

                        // Call the appropriate method from your controller to delete the book by its ID
                        if (userId != null)
                        {

                            this.loader = new(this);
                            this.loader.StartLoading();

                            ControllerActionData deleteResult = await AdminController.RemoveById(userId, this.adminPassword);

                            if (deleteResult.IsSuccess)
                            {
                                this.loader.StopLoading();

                                this.page = 1;
                                LoadUsers();
                                adminDashboard.RefreshDataGrid();
                                clearBtn.PerformClick();

                                DialogBuilder.Show("User Deleted Successfully", "Delete User", MessageBoxIcon.Information);
                            }
                            else
                            {
                                this.loader.StopLoading();

                                DialogBuilder.Show(deleteResult.Errors, "Delete User Error", MessageBoxIcon.Hand);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unable to retrieve the book ID. Please try again.");
                        }
                    }
                }
            }
        }

        private void text_TextChanged(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                // refresh preview
                panel2.Controls.Clear();
                panel2.Controls.Add(new UserContainer(new User
                {
                    Username = textUsername.Text,
                    ProfilePicture = txtProfile.Text,
                    Member = new Member
                    {
                        FirstName = textFirstName.Text,
                        LastName = textLastName.Text
                    },
                    Role = new Role
                    {
                        Name = cmbRole.Text
                    }
                }, true));
            }

            isInitialized = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                txtProfile.Text = imagePath;
                pictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 0;
            textUserID.Text = "";
            SchoolNum.Text = "";
            textUsername.Text = "";
            textPassword.Text = "";
            textFirstName.Text = "";
            textLastName.Text = "";
            textAddress.Text = "";
            textPhone.Text = "";
            textEmail.Text = "";
            txtProfile.Text = "";
            pictureBox1.Image = null;
            cmbRole.Enabled = true;

            defaultPreview();

            this.ResetButtons();
        }

        private void textPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                this.loader = new(this);
                loader.StartLoading();
                if (this.isSearch) LoadSearchUsers(); else LoadUsers();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page++;
                this.loader = new(this);
                loader.StartLoading();
                if (this.isSearch) LoadSearchUsers(); else LoadUsers();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = true;
                this.loader = new(this);
                this.loader.StartLoading();
                this.page = 1;
                this.LoadSearchUsers();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                this.isSearch = false;
                this.loader = new(this);
                this.loader.StartLoading();
                this.page = 1;
                LoadUsers();
            }
        }

        private void DisableButtons()
        {
            if (usersGridList.SelectedRows.Count > 0)
            {
                button1.Enabled = false;
                btnDeleteBooks.Enabled = true;
                button2.Enabled = true;
            } else
            {
                this.ResetButtons();
            }
        }

        private void ResetButtons()
        {
            button1.Enabled = true;
            btnDeleteBooks.Enabled = false;
            button2.Enabled = false;
        }
    }
}
