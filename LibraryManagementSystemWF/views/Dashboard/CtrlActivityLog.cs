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

namespace LibraryManagementSystemWF.views.Dashboard
{
    public partial class CtrlActivityLog : UserControl
    {
        private bool isSearch = false;
        private int currentPage = 1;

        public CtrlActivityLog()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            // load columns
            dataGridView1.Columns.Add("TYPE", "TYPE");
            dataGridView1.Columns.Add("LOG", "LOG");
            dataGridView1.Columns.Add("SOURCE", "SOURCE");
            dataGridView1.Columns.Add("TIMESTAMP", "TIMESTAMP");

            LoadActivities();
        }

        private async void LoadActivities()
        {
            ControllerAccessData<ActivityLog> res = await ActivityLogController.GetAllForLibrarian(currentPage);

            Console.WriteLine("IM FIRRED");
            Console.WriteLine(res.IsSuccess);
            if (res.IsSuccess)
            {
                foreach (ActivityLog al in res.Results)
                {
                    dataGridView1.Rows.Add(
                            $"[{al.Type.Name}]",
                            al.Log,
                            $"{al.User.Member.FirstName} {al.User.Member.LastName} ({al.User.Username})",
                            al.Timestamp.ToString("MMM d, yyyy 'at' hh:mm tt")
                        );
                }
            }
        }

        private async void LoadSearchActivities() 
        { 
        
        }
    }
}
