using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.dao;
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

namespace LibraryManagementSystemWF.Dashboard.AdminDashboardControl
{
    public partial class Ctrlstatus : UserControl
    {

        public async void getStatuses()
        {


            ControllerAccessData<Status> statuses = await StatusController.GetAllStatuses();

            if (statuses.IsSuccess)
            {

                dataGridView1.DataSource = statuses.Results;

            }
            else
            {
                MessageBox.Show("Error!!");
            }

        }

        public Ctrlstatus()
        {
            InitializeComponent();

            getStatuses();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

    }
}

