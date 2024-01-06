﻿using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using LibraryManagementSystemWF.views.components;
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

namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    public partial class AdminActivityLog : Form
    {
        private bool isSearch = false;
        private int currentPage = 1;
        private int maxPage = 1;
        private Loader loader;
        private List<ActivityLog> results = new();
        private bool isComboBoxInit = false;

        public AdminActivityLog()
        {
            InitializeComponent();

            this.loader = new(this);

            Init();
        }

        private void Init()
        {
            // load columns
            dataGridView1.Columns.Add("TYPE", "TYPE");
            dataGridView1.Columns.Add("LOG", "LOG");
            dataGridView1.Columns.Add("SOURCE", "SOURCE");
            dataGridView1.Columns.Add("TIMESTAMP", "TIMESTAMP");
            dataGridView1.Columns.Add("ID", "ID");

            loader.StartLoading();
            LoadFilters();
            LoadActivities();
            LoadPreview();

            loader.StopLoading();
        }

        private void LoadFilters()
        {
            this.isComboBoxInit = true;
            foreach (ActivityTypeEnum ate in Enum.GetValues(typeof(ActivityTypeEnum)))
            {
                cmbFilter.Items.Add(ate);
            }

            cmbFilter.Items.Add("ALL");
            cmbFilter.Text = "ALL";

            this.isComboBoxInit = false;
        }

        private void LoadPreview(User? user = null)
        {
            // load default preview
            panel1.Controls.Clear();

            if (user != null)
            {
                panel1.Controls.Add(new UserContainer(user));
            } else
            {
                panel1.Controls.Add(new UserContainer(new User
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
                }, true));
            }
        }

        private async void LoadActivities()
        {
            ActivityTypeEnum? ate = null;
            foreach (ActivityTypeEnum x in Enum.GetValues(typeof(ActivityTypeEnum)))
            {
                if (cmbFilter.Text == x.ToString())
                {
                    ate = x;
                }
            }

            ControllerAccessData<ActivityLog> res = await ActivityLogController.GetAllUsers(currentPage, txtSearch.Text, ate);

            if (res.IsSuccess)
            {
                this.results = res.Results;

                dataGridView1.Rows.Clear();
                this.maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 20));
                this.pageLbl.Text = $"{currentPage} | {maxPage}";

                foreach (ActivityLog al in res.Results)
                {
                    dataGridView1.Rows.Add(
                            $"[{al.Type.Name}]",
                            al.Log,
                            $"{al.User.Member.FirstName} {al.User.Member.LastName} ({al.User.Username})",
                            al.Timestamp.ToString("MMM d, yyyy 'at' hh:mm tt"),
                            al.ID
                        );
                }
            } else
            {
                DialogBuilder.Show(res.Errors, "Activity Log Error", MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.isSearch = true;
            this.currentPage = 1;

            this.loader = new(this);
            loader.StartLoading();
            LoadActivities();
            loader.StopLoading();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ActivityLog? al = this.results.Find((x) => { return dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString() == x.ID.ToString(); });

            LoadPreview(al?.User);
        }

        private void navigatePage()
        {
            this.loader = new(this);
            loader.StartLoading();
            if (!isSearch) txtSearch.Clear();
            LoadActivities();
            loader.StopLoading();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 1)
            {
                this.currentPage -= 1;
                this.navigatePage();
            }
        }

        private void prevLastBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 1)
            {
                this.currentPage = 1;
                this.navigatePage();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage < this.maxPage)
            {
                this.currentPage += 1;
                this.navigatePage();
            }
        }

        private void nextLastBtn_Click(object sender, EventArgs e)
        {
            if (this.currentPage < this.maxPage)
            {
                this.currentPage = this.maxPage;
                this.navigatePage();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadActivities();
            }
        }

        private void cmbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!this.isComboBoxInit) navigatePage();
        }
    }
}
