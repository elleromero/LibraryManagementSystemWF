﻿using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.Dashboard.AdminDashboardControl;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.Dashboard.GeneralUser
{
    public partial class UserDashboard : Form
    {
        private User? user;

        public UserDashboard()
        {
            InitializeComponent();

            versionlbl.Text = EnvService.GetVersion();

            this.ClearAndHide();

            mainPanel.Controls.Add(new CtrlDiscover());

            button2.BackColor = SystemColors.Control;
            navLbl.Text = "Discover";

            // initialize user info
            user = AuthService.getSignedUser();

            if (user != null)
            {
                nameLbl.Text = $"{user.Member.FirstName} {user.Member.LastName} ({user.Username})";
                emailLbl.Text = string.IsNullOrWhiteSpace(user.Member.Email) ? "No Email Provided" : user.Member.Email;
                idLbl.Text += user.ID;
                if (File.Exists(user.ProfilePicture)) pictureBox1.Image = Image.FromFile(user.ProfilePicture);
            }
            else
            {
                nameLbl.Text = "Unavailable User";
                emailLbl.Text = "No Email Provided";
                idLbl.Text += "Unable top fetch";
            }

            // run clock
            // Start the timer
            System.Windows.Forms.Timer timer = new();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            timerLbl.Text = now.ToString("MMM. d yyyy. dddd. hh:mm:ss tt");
        }

        private void ClearAndHide()
        {
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;

            mainPanel.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthController.LogOut();
            new SignIn().Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button2.BackColor = SystemColors.Control;

            mainPanel.Controls.Add(new CtrlDiscover());
            navLbl.Text = "Discover";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button3.BackColor = SystemColors.Control;

            mainPanel.Controls.Add(new CtrlRepo());
            navLbl.Text = "My Repo";
        }
    }
}
