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

namespace LibraryManagementSystemWF.views
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
            this.Hide();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string reguser = txtRegUser.Text.Trim();
            string regpass = txtRegPass.Text.Trim();
            string firstname = txtFirstName.Text.Trim();
            string lastname = txtLastName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string profile = txtProfile.Text;

            // CALLING THE METHOD FROM AUTHCONTROLLER
            ControllerModifyData<User> res = await AuthController.Register(reguser, regpass, firstname, lastname, address, phone, email, profile);

            if (res.IsSuccess)
            {
                // CHECK IF THE REGISTRATION IS SUCCESS
                MessageBox.Show("Registration Successfull!!");

                SignIn signin = new SignIn();
                signin.Show();
                this.Hide();
            }
            else
            {
                // SHOWS ERROR MESSAGE
                string errors = " ";
                foreach (var error in res.Errors)
                {
                    errors += error.Value + "\n";
                }

                MessageBox.Show(errors);

            }
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
