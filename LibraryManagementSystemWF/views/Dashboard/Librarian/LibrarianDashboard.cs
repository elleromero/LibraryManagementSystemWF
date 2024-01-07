using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.Dashboard.AdminDashboardControl;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
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

namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    public partial class LibrarianDashboard : Form
    {
        private User? user;

        public LibrarianDashboard()
        {
            InitializeComponent();

            versionlbl.Text = EnvService.GetVersion();

            this.ClearAndHide();

            mainPanel.Controls.Add(new Ctrldashboard(this));

            button2.BackColor = SystemColors.Control;
            navLbl.Text = "Home";

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
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;

            mainPanel.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button2.BackColor = SystemColors.Control;

            mainPanel.Controls.Add(new Ctrldashboard(this));
            navLbl.Text = "Home";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button3.BackColor = SystemColors.Control;

            mainPanel.Controls.Add(new Ctrlbooksrevamp(this));
            navLbl.Text = "Books";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                AuthController.LogOut();
                new SignIn().Show();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button4.BackColor = SystemColors.Control;

            mainPanel.Controls.Add(new CtrlGenre(this));
            navLbl.Text = "Genres";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button6.BackColor = SystemColors.Control;

            mainPanel.Controls.Add(new CtrlLibrarianActivityLog(this));
            navLbl.Text = "Activity Log";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button7.BackColor = SystemColors.Control;

            mainPanel.Controls.Add(new CtrlLibrarianOverdue(this));
            navLbl.Text = "Overdue Returns";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button5.BackColor = SystemColors.Control;

            mainPanel.Controls.Add(new CtrlProgram(this));
            navLbl.Text = "Programs";
        }
    }
}
