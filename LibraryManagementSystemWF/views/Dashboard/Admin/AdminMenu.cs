using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views.components;
using LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl;
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
        private AdminDashboard adminDashboard = new();
        private string adminPassword = "";
        private bool isInitialized = true;

        public AdminMenu(AdminDashboard adminDashboard)
        {
            InitializeComponent();

            this.adminDashboard = adminDashboard;

            LoadUsers();
            LoadRoles();

            defaultPreview();
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
            }));
        }

        private async void LoadUsers()
        {
            ControllerAccessData<User> res = await AdminController.GetAllUsers();

            if (res.IsSuccess)
            {
                usersGridList.Rows.Clear(); // Clear existing rows before adding new ones

                usersGridList.Columns.Add("ID", "ID");
                usersGridList.Columns.Add("Username", "Username");
                usersGridList.Columns.Add("Role", "Role");
                usersGridList.Columns.Add("First Name", "First Name");
                usersGridList.Columns.Add("Last Name", "Last Name");
                usersGridList.Columns.Add("Address", "Address");
                usersGridList.Columns.Add("Phone", "Phone");
                usersGridList.Columns.Add("Email", "Email");
                usersGridList.Columns.Add("Profile Picture", "Profile Picture");

                foreach (User user in res.Results)
                {
                    usersGridList.Rows.Add(
                        user.ID,
                        user.Username,
                        user.Role.Name,
                        user.Member.FirstName,
                        user.Member.LastName,
                        user.Member.Address,
                        user.Member.Phone,
                        user.Member.Email,
                        user.ProfilePicture
                        );
                }

            }
            else
            {
                MessageBox.Show("Error retrieving users!");
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
            else
            {
                MessageBox.Show("Error retrieving roles!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem != null)
            {
                Role selectedRole = (Role)cmbRole.SelectedItem;
                int selectedRoleId = selectedRole.ID;
                string UserId = textUserID.Text;
                string Username = textUsername.Text;
                string Password = textPassword.Text;
                string FirstName = textFirstName.Text;
                string LastName = textLastName.Text;
                string Address = textAddress.Text;
                string Phone = textPhone.Text;
                string Email = textEmail.Text;
                string ProfilePicture = txtProfile.Text;

                ControllerModifyData<User> res = await AdminController.CreateUser(
                    Username,
                    Password,
                    FirstName,
                    LastName,
                    Address,
                    Phone,
                    selectedRoleId,
                    Email,
                    ProfilePicture
                    );

                if (res.IsSuccess)
                {
                    defaultPreview();

                    cmbRole.SelectedIndex = 0;
                    textUserID.Text = "";
                    textUsername.Text = "";
                    textPassword.Text = "";
                    textFirstName.Text = "";
                    textLastName.Text = "";
                    textAddress.Text = "";
                    textPhone.Text = "";
                    textEmail.Text = "";
                    txtProfile.Text = "";
                    pictureBox1.Image = null;

                    LoadUsers();
                    adminDashboard.LoadUsers();
                    clearBtn.PerformClick();
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        MessageBox.Show(error.Value);
                    }
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
            string Username = textUsername.Text;
            string Password = textPassword.Text;
            string FirstName = textFirstName.Text;
            string LastName = textLastName.Text;
            string Address = textAddress.Text;
            string Phone = textPhone.Text;
            string Email = textEmail.Text;
            string ProfilePicture = txtProfile.Text;

            // show password confirmation dialog
            PasswordProtected passProtected = new(this);

            if (passProtected.ShowDialog() == DialogResult.OK)
            {
                ControllerModifyData<User> res = await AdminController.UpdateUser(
                    UserId,
                    Username,
                    Password,
                    FirstName,
                    LastName,
                    Address,
                    Phone,
                    this.adminPassword,
                    Email,
                    ProfilePicture
                    );

                this.adminPassword = "";

                if (res.IsSuccess)
                {
                    defaultPreview();

                    cmbRole.SelectedIndex = 0;
                    textUserID.Text = "";
                    textUsername.Text = "";
                    textPassword.Text = "";
                    textFirstName.Text = "";
                    textLastName.Text = "";
                    textAddress.Text = "";
                    textPhone.Text = "";
                    textEmail.Text = "";
                    txtProfile.Text = "";
                    pictureBox1.Image = null;

                    LoadUsers();
                    adminDashboard.LoadUsers();
                    clearBtn.PerformClick();
                }
                else
                {
                    MessageBox.Show("ERROR");
                    foreach (var error in res.Errors)
                    {
                        MessageBox.Show(error.Value);
                    }
                }
            }

        }

        public void setAdminPassword(string adminPassword)
        {
            this.adminPassword = adminPassword;
        }

        private void usersList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = usersGridList.Rows[e.RowIndex];

                // Set the values of the text boxes to the values in the clicked row
                textUserID.Text = row.Cells["ID"].Value.ToString();
                textUsername.Text = row.Cells["Username"].Value.ToString();
                cmbRole.Text = row.Cells["Role"].Value.ToString();
                textFirstName.Text = row.Cells["First Name"].Value.ToString();
                textLastName.Text = row.Cells["Last Name"].Value.ToString();
                textAddress.Text = row.Cells["Address"].Value.ToString();
                textPhone.Text = row.Cells["Phone"].Value.ToString();
                textEmail.Text = row.Cells["Email"].Value.ToString();
                txtProfile.Text = row.Cells["Profile Picture"].Value.ToString();

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
        }

        private async void btnDeleteBooks_Click(object sender, EventArgs e)
        {
            try
            {
                if (usersGridList.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // show password confirmation dialog
                    PasswordProtected passProtected = new(this);

                    if ((passProtected.ShowDialog() == DialogResult.OK) && (result == DialogResult.Yes))
                    {
                        DataGridViewRow selectedRow = usersGridList.SelectedRows[0];

                        string userId = selectedRow.Cells["ID"]?.Value?.ToString(); // Assuming the column name for the ID is "ID"

                        // Call the appropriate method from your controller to delete the book by its ID
                        if (userId != null)
                        {
                            ControllerActionData deleteResult = await AdminController.RemoveById(userId, this.adminPassword);

                            if (deleteResult.IsSuccess)
                            {
                                MessageBox.Show("Row deleted successfully.");

                                LoadUsers();
                                adminDashboard.LoadUsers();
                                clearBtn.PerformClick();
                            }
                            else
                            {

                                foreach (KeyValuePair<string, string> error in deleteResult.Errors)
                                {
                                    MessageBox.Show(error.Value);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unable to retrieve the book ID. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the record: " + ex.Message);
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
                }));
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
        }
    }
}
