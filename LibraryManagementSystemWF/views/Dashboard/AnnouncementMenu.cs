using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
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

namespace LibraryManagementSystemWF.views.Dashboard
{
    public partial class AnnouncementMenu : Form
    {
        private List<Announcement> announcements = new();
        private ICustomForm form;
        private Form? parentForm;
        private Loader loader;
        private int page = 1;
        private int maxPage = 1;

        public AnnouncementMenu(ICustomForm form, Form? parentForm = null)
        {
            InitializeComponent();

            this.form = form;
            this.parentForm = parentForm;

            // determine role
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                if (user.Role.ID == (int) RoleEnum.ADMINISTRATOR)
                {
                    checkBoxAdmin.Checked = true;
                    checkBoxAdmin.Enabled = false;
                } else if (user.Role.ID == (int)RoleEnum.LIBRARIAN)
                {
                    checkBoxAdmin.Enabled = false;
                    checkBoxLibrarian.Enabled = false;
                    checkBoxLibrarian.Checked = true;
                }
            }

            // load data grid columns
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Header", "Header");
            dataGridView1.Columns.Add("Body", "Body");
            dataGridView1.Columns.Add("Due", "Due");
            dataGridView1.Columns.Add("Date Created", "Date Created");
            dataGridView1.Columns.Add("Cover", "Cover");
            dataGridView1.Columns.Add("Audience", "Audience");

            this.loader = new(this);
            this.loader.StartLoading();

            LoadAnnouncements();
        }

        private async void LoadAnnouncements()
        {
            ControllerAccessData<Announcement> res = await AnnouncementController.GetAllWithPastDue(page);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                // set pages
                maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 20));
                pageLbl.Text = $"{page} | {maxPage}";

                // clear data grid
                dataGridView1.Rows.Clear();

                announcements = res.Results;

                if (announcements.Count == 0) DialogBuilder.Show("No announcements yet", "No announcements", MessageBoxIcon.Information);

                for (int i = 0; i < announcements.Count; i++)
                {
                    dataGridView1.Rows.Add(
                        announcements[i].ID,
                        announcements[i].Header,
                        announcements[i].Body,
                        announcements[i].Due.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        announcements[i].Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        announcements[i].Cover,
                        string.Join(" ", announcements[i].VisibleRoles)
                        );

                    if (announcements[i].IsPriority) dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fece2f");
                }
            } else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Fetch Announcements Error", MessageBoxIcon.Hand);
            }

        }

        private void Clear()
        {
            textAnnouncementID.Clear();
            txtHeader.Clear();
            txtBody.Clear();
            dtpAnnouncementDue.Value = DateTime.Now;
            txtCover.Clear();
            checkBoxImportant.Checked = false;

            // set checkbox
            checkBoxAdmin.Checked = false;
            checkBoxUser.Checked = false;
            checkBoxLibrarian.Checked = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.parentForm != null) this.parentForm.Enabled = true;
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string rowId = row.Cells["ID"].Value.ToString() ?? string.Empty;

                // Set the values of the text boxes to the values in the clicked row
                foreach (Announcement ann in announcements)
                {
                    if (rowId == ann.ID.ToString())
                    {
                        textAnnouncementID.Text = ann.ID.ToString();
                        txtHeader.Text = ann.Header;
                        txtBody.Text = ann.Body;
                        dtpAnnouncementDue.Value = ann.Due;
                        txtCover.Text = ann.Cover;
                        checkBoxImportant.Checked = ann.IsPriority;

                        // set checkbox
                        checkBoxAdmin.Checked = ann.VisibleRoles.Contains(RoleEnum.ADMINISTRATOR);
                        checkBoxUser.Checked = ann.VisibleRoles.Contains(RoleEnum.USER);
                        checkBoxLibrarian.Checked = ann.VisibleRoles.Contains(RoleEnum.LIBRARIAN);
                    }
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // publish announcement
            List<RoleEnum> publishToRoles = new();

            if (checkBoxAdmin.Checked) publishToRoles.Add(RoleEnum.ADMINISTRATOR);
            if (checkBoxLibrarian.Checked) publishToRoles.Add(RoleEnum.LIBRARIAN);
            if (checkBoxUser.Checked) publishToRoles.Add(RoleEnum.USER);

            this.loader = new(this);
            this.loader.StartLoading();

            ControllerModifyData<Announcement> res = await AnnouncementController.Create(
                txtHeader.Text,
                txtBody.Text,
                dtpAnnouncementDue.Value,
                publishToRoles,
                txtCover.Text,
                checkBoxImportant.Checked
                );

            if (res.IsSuccess)
            {
                this.loader.StopLoading();
                DialogBuilder.Show("Announcement published successfully", "Publish Announcement", MessageBoxIcon.Information);
                this.Clear();
                LoadAnnouncements();
                form.RefreshDataGrid();
            } else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(res.Errors, "Publish Announcement Error", MessageBoxIcon.Hand);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // update announcement
                List<RoleEnum> publishToRoles = new();

                if (checkBoxAdmin.Checked) publishToRoles.Add(RoleEnum.ADMINISTRATOR);
                if (checkBoxLibrarian.Checked) publishToRoles.Add(RoleEnum.LIBRARIAN);
                if (checkBoxUser.Checked) publishToRoles.Add(RoleEnum.USER);

                this.loader = new(this);
                this.loader.StartLoading();

                ControllerModifyData<Announcement> res = await AnnouncementController.Update(
                    textAnnouncementID.Text,
                    txtHeader.Text,
                    txtBody.Text,
                    dtpAnnouncementDue.Value,
                    publishToRoles,
                    txtCover.Text,
                    checkBoxImportant.Checked
                    );

                if (res.IsSuccess)
                {
                    this.loader.StopLoading();
                    DialogBuilder.Show("Announcement updated successfully", "Update Announcement", MessageBoxIcon.Information);
                    this.Clear();
                    LoadAnnouncements();
                    form.RefreshDataGrid();
                }
                else
                {
                    this.loader.StopLoading();
                    DialogBuilder.Show(res.Errors, "Update Announcement Error", MessageBoxIcon.Hand);
                }
            }
            else DialogBuilder.Show("No announcement selected", "Nothing Selected", MessageBoxIcon.Hand);
 
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this announcement", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    this.loader = new(this);
                    this.loader.StartLoading();

                    string? annId = dataGridView1.SelectedRows[0].Cells["ID"]?.Value?.ToString();

                    if (annId != null)
                    {
                        // remove announcement
                        ControllerActionData res = await AnnouncementController.RemoveById(
                            annId
                            );

                        if (res.IsSuccess)
                        {
                            this.loader.StopLoading();
                            DialogBuilder.Show("Announcement removed successfully", "Remove Announcement", MessageBoxIcon.Information);
                            this.Clear();
                            LoadAnnouncements();
                            form.RefreshDataGrid();
                        }
                        else
                        {
                            this.loader.StopLoading();
                            DialogBuilder.Show(res.Errors, "Remove Announcement", MessageBoxIcon.Information);
                        }
                    }
                }
            } else DialogBuilder.Show("No announcement selected", "Nothing Selected", MessageBoxIcon.Hand);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                txtCover.Text = imagePath;
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadAnnouncements();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page++;
                this.loader = new(this);
                this.loader.StartLoading();
                LoadAnnouncements();
            }
        }
    }
}
