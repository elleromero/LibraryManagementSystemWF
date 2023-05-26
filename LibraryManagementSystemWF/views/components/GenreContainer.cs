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
    public partial class GenreContainer : UserControl
    {
        private CtrlGenre ctrlGenre;
        private Genre genre;

        public GenreContainer(Genre genre, CtrlGenre parent)
        {
            InitializeComponent();

            this.ctrlGenre = parent;
            this.genre = genre;

            titleLbl.Text = genre.Name;
            txtDescription.Text = genre.Description;
            colorStrip.BackColor = ColorTranslator.FromHtml(PastelColorGenerator.GeneratePastelColor(genre.Name));
        }

        private void GenreContainer_Click(object sender, EventArgs e)
        {
            ctrlGenre.SelectGenre(this.genre);
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void Clear()
        {
            this.BorderStyle = BorderStyle.None;
        }
    }
}
