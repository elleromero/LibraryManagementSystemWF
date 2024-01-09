using LibraryManagementSystemWF.controllers;
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

namespace LibraryManagementSystemWF.views.Dashboard.AdminDashboardControl
{
    public partial class CtrlProgram : UserControl
    {
        private List<models.Program> progsList = new List<models.Program>();
        private int maxPage = 1;
        private int currentPage = 1;
        private Form form;
        private Loader loader;

        public void SelectProgram(models.Program program)
        {
            txtID.Text = program.ID.ToString();
            txtName.Text = program.Name;
            txtDescription.Text = program.Description;

            foreach (ProgramContainer progContainer in flowLayoutPanel1.Controls)
            {
                progContainer.Clear();
            }
        }

        public async void LoadPrograms(int page)
        {
            // Creating an Instance of the ProgramController class
            ControllerAccessData<models.Program> res = await ProgramController.GetAllPrograms(page);

            if (res.IsSuccess)
            {
                this.loader.StopLoading();

                progsList = res.Results;

                if (progsList.Count == 0)
                {
                    Label lbl = new();
                    lbl.Text = "No programs found";
                    DialogBuilder.Show("No programs found", "Fetch Programs", MessageBoxIcon.Information);
                }

                this.maxPage = Math.Max(1, (int)Math.Ceiling((double)res.rowCount / 10));
                pageLbl.Text = $"{page} | {maxPage}";

                // Load programs on flow layout panel
                flowLayoutPanel1.Controls.Clear();

                foreach (models.Program prog in progsList)
                {
                    flowLayoutPanel1.Controls.Add(new ProgramContainer(prog, this));
                }
            }
            else this.loader.StopLoading();
        }

        public CtrlProgram(Form form)
        {
            InitializeComponent();

            this.form = form;

            this.loader = new(this.form);
            this.loader.StartLoading();

            LoadPrograms(currentPage);

        }

        private void Clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";

            foreach (ProgramContainer progContainer in flowLayoutPanel1.Controls)
            {
                progContainer.Clear();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = txtDescription.Text;

            this.loader = new(this.form);
            this.loader.StartLoading();

            ControllerModifyData<models.Program> result = await ProgramController.CreateProgram(name, description);

            if (result.IsSuccess && result.Result != null)
            {
                this.loader.StopLoading();

                models.Program prog = result.Result;
                progsList.Add(prog);

                this.currentPage = 1;
                LoadPrograms(currentPage);

                // Clear input fields
                this.Clear();

                DialogBuilder.Show("Program successfully created", "Create Program", MessageBoxIcon.Information);
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(result.Errors, "Create Program Failed", MessageBoxIcon.Hand);
            }
        }

        private async void btnUpdateProgram_Click(object sender, EventArgs e)
        {
            // Retrieve the updated values from the input fields
            string name = txtName.Text;
            string description = txtDescription.Text;
            int progId = string.IsNullOrWhiteSpace(txtID.Text) ? -1 : Convert.ToInt32(txtID.Text);

            this.loader = new(this.form);
            this.loader.StartLoading();

            // Update the program
            ControllerModifyData<models.Program> result = await ProgramController.UpdateProgram(progId, name, description);

            if (result.IsSuccess && result.Result != null)
            {
                this.loader.StopLoading();

                // Update the progsList with the modified program
                models.Program updatedProg = result.Result;
                int index = progsList.FindIndex(g => g.ID == progId);
                if (index >= 0)
                {
                    progsList[index] = updatedProg;
                }

                this.currentPage = 1;
                LoadPrograms(currentPage);

                // Clear input fields
                this.Clear();

                DialogBuilder.Show("Program successfully updated", "Update Program", MessageBoxIcon.Information);
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(result.Errors, "Update Program Failed", MessageBoxIcon.Hand);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage++;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadPrograms(currentPage);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                this.loader = new(this.form);
                this.loader.StartLoading();
                LoadPrograms(currentPage);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int progId = string.IsNullOrWhiteSpace(txtID.Text) ? -1 : Convert.ToInt32(txtID.Text);

            this.loader = new(this.form);
            this.loader.StartLoading();

            // Call the appropriate method from your controller to delete the program by its ID
            ControllerActionData deleteResult = await ProgramController.RemoveById(progId);

            if (deleteResult.IsSuccess)
            {

                this.loader.StopLoading();

                this.currentPage = 1;
                LoadPrograms(currentPage);

                this.Clear();

                DialogBuilder.Show("Program successfully removed", "Remove Program", MessageBoxIcon.Information);
            }
            else
            {
                this.loader.StopLoading();
                DialogBuilder.Show(deleteResult.Errors, "Remove Program", MessageBoxIcon.Hand);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            this.Clear();
        }
    }
}
