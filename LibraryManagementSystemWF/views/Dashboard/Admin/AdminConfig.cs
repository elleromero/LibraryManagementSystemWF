using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace LibraryManagementSystemWF.views.Dashboard.Admin
{
    public partial class AdminConfig : Form
    {
        // string path with text file
        string infoFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "Config.txt");
        public AdminConfig()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            int maxBorrowedBooks = (int)numericMaxBorrowedBooks.Value;
            int maxCopies = (int)numericMaxCopies.Value;
            decimal maxPrice = (decimal)numericMaxPrice.Value;
            bool allowBorrowAfterDue = cbAllowBorrowAfterDue.Checked;

            // Store the Config Info
            string storeconfig = $"Max Borrowed Books: {maxBorrowedBooks}\nMax Copies: {maxCopies}\nMax Price: {maxCopies}\nAllow Borrow After Due: {allowBorrowAfterDue}";

            File.WriteAllText(infoFile, storeconfig);

            MessageBox.Show("Configuration saved successfully!");
        }
    }
}
