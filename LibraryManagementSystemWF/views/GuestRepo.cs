﻿using LibraryManagementSystemWF.views.Dashboard.GeneralUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views
{
    public partial class GuestRepo : Form
    {
        public GuestRepo(string userId)
        {
            InitializeComponent();

            this.panel1.Controls.Add(new CtrlRepo(this, userId));
        }
    }
}
