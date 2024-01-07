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

namespace LibraryManagementSystemWF.views.Dashboard.Librarian
{
    public partial class ConfirmPayment : Form
    {
        public ConfirmPayment(string txt)
        {
            InitializeComponent();

            richTextBox1.Text = txt;
        }
    }
}
