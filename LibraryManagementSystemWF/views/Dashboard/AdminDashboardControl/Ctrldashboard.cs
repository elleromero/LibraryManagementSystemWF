using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.Dashboard.AdminDashboardControl
{
    public partial class Ctrldashboard : UserControl
    {
        public Ctrldashboard()
        {
            InitializeComponent();

            // init greeting
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                titleLbl.Text = GreetingGenerator.GenerateGreeting(user.Member.FirstName, DateTime.Now.ToString());
            }

            LoadStats();
        }
    
        private async void LoadStats()
        {
            ControllerModifyData<Stats> res = await StatsController.GetStats();

            if (res.IsSuccess && res.Result != null)
            {
                totalBooksLbl.Text = res.Result.TotalBooks.ToString();
                btrRatioLbl.Text = $"{res.Result.TotalBorrowedBooks} : {res.Result.TotalReturnedBooks}";
                availableCopiesLbl.Text = res.Result.TotalAvailableCopies.ToString();
            }
        }
    }
}
