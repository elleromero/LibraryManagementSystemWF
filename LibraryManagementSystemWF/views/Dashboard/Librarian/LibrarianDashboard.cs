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
        private Ctrldashboard dashboard = new();
        private Ctrlbooksrevamp books = new();
        private Ctrlstatus status = new();
        private CtrlGenre genre= new();
        private CtrlCopies copies = new();
        private User? user;

        public LibrarianDashboard()
        {
            InitializeComponent();

            versionlbl.Text = EnvService.GetVersion();

            mainPanel.Controls.Add(dashboard);
            mainPanel.Controls.Add(books);
            mainPanel.Controls.Add(status);
            mainPanel.Controls.Add(genre);
            mainPanel.Controls.Add(copies);

            this.ClearAndHide();
            button2.BackColor = SystemColors.Control;
            dashboard.Visible = true;
            navLbl.Text = "Home";

            // initialize user info
            user = AuthService.getSignedUser();

            if (user != null)
            {
                nameLbl.Text = $"{user.Member.FirstName} {user.Member.LastName} ({user.Username})";
                emailLbl.Text = user.Member.Email;
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

            books.Visible = false;
            dashboard.Visible = false;
            status.Visible = false;
            genre.Visible = false;
            copies.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button2.BackColor = SystemColors.Control;

            dashboard.Visible = true;
            navLbl.Text = "Home";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button3.BackColor = SystemColors.Control;

            books.Visible = true;
            navLbl.Text = "Books";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            AuthController.LogOut();
            new SignIn().Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button4.BackColor = SystemColors.Control;

            genre.Visible = true;
            navLbl.Text = "Genres";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.ClearAndHide();
            button5.BackColor = SystemColors.Control;

            copies.Visible = true;
            navLbl.Text = "Copies";
        }
    }
}
