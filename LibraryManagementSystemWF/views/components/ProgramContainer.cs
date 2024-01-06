using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
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

namespace LibraryManagementSystemWF.views.components
{
    public partial class ProgramContainer : UserControl
    {
        private CtrlProgram ctrlProgram;
        private models.Program prog;

        public ProgramContainer(models.Program prog, CtrlProgram parent)
        {
            InitializeComponent();

            this.ctrlProgram = parent;
            this.prog = prog;

            titleLbl.Text = prog.Name;
            txtDescription.Text = prog.Description;
            colorStrip.BackColor = ColorTranslator.FromHtml(PastelColorGenerator.GeneratePastelColor(prog.Name));
        }

        private void ProgContainer_Click(object sender, EventArgs e)
        {
            ctrlProgram.SelectProgram(this.prog);
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void Clear()
        {
            this.BorderStyle = BorderStyle.None;
        }
    }
}
