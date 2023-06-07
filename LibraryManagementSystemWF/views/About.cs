using LibraryManagementSystemWF.services;
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

namespace LibraryManagementSystemWF.views
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            lblVersion.Text = EnvService.GetVersion();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo {
                FileName = "https://facebook.com/jamesmar.mar",
                UseShellExecute = true
            });
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Jmsmr",
                UseShellExecute = true
            });
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://facebook.com/shello.handsome",
                UseShellExecute = true
            });
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/itsmekaitokun",
                UseShellExecute = true
            });
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://facebook.com/releazar72",
                UseShellExecute = true
            });
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/omineko",
                UseShellExecute = true
            });
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://facebook.com/jamesontheodoreII",
                UseShellExecute = true
            });
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/jtheodore",
                UseShellExecute = true
            });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/omineko/LibraryManagementSystemWF",
                UseShellExecute = true
            });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
