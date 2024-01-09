﻿using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
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

namespace LibraryManagementSystemWF.views
{
    public partial class Register : Form
    {
        private Form form;

        public Register(Form form)
        {
            InitializeComponent();

            this.form = form;
            LoadPrograms();
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.form.Show();
            this.Close();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string SchoolNumber = schoolNum.Text.Trim();
            string reguser = txtRegUser.Text.Trim();
            string regpass = txtRegPass.Text.Trim();
            string firstname = txtFirstName.Text.Trim();
            string lastname = txtLastName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string profile = txtProfile.Text;
            Loader loader = new(this);

            // call loader
            loader.StartLoading();

            // CALLING THE METHOD FROM AUTHCONTROLLER
            ControllerModifyData<User> res = await AuthController.Register(reguser, regpass, firstname, lastname, SchoolNumber, address, phone, email, profile, ((models.Program)cmbProgram.SelectedItem).ID, (int)numCourseYear.Value);

            if (res.IsSuccess)
            {
                loader.StopLoading();

                // CHECK IF THE REGISTRATION IS SUCCESS
                DialogBuilder.Show("Registered Successfully. Please login.", "Registration Success", MessageBoxIcon.Information);

                this.form.Show();
                this.Close();
            }
            else
            {
                loader.StopLoading();

                // SHOWS ERROR MESSAGE
                DialogBuilder.Show(res.Errors, "Registration Error", MessageBoxIcon.Stop);
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
