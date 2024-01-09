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
        string infoFile = "../../../resources/config/config.txt";
        public AdminConfig()
        {
            InitializeComponent();

            LoadConfig();
        }

        private void LoadConfig()
        {
            Dictionary<string, string> dict = new();
            string[] configBase = File.ReadAllLines(infoFile);

            foreach (string s in configBase)
            {
                string[] parts = s.Split('=');
                dict.Add(parts[0], parts[1]);
            }

            numericMaxBorrowedBooks.Value = Int32.Parse(dict["MAX_BORROWED_BOOKS"]);
            numericMaxCopies.Value = Int32.Parse(dict["MAX_COPIES"]);
            numericMaxPrice.Value = Decimal.Parse(dict["MAX_PRICE"]);
            numDaysBeforeDue.Value = Int32.Parse(dict["DAYS_BEFORE_DUE"]);
            cbAllowBorrowAfterDue.Checked = Boolean.Parse(dict["ALLOW_BORROW_AFTER_DUE"]);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            int maxBorrowedBooks = (int)numericMaxBorrowedBooks.Value;
            int maxCopies = (int)numericMaxCopies.Value;
            decimal maxPrice = (decimal)numericMaxPrice.Value;
            int daysBeforeDue = (int)numDaysBeforeDue.Value;
            bool allowBorrowAfterDue = cbAllowBorrowAfterDue.Checked;

            DialogResult dr = MessageBox.Show("Overwrite Config?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // Store the Config Info
                string storeconfig = $"MAX_BORROWED_BOOKS={maxBorrowedBooks}\nMAX_COPIES={maxCopies}\nMAX_PRICE={maxPrice}\nALLOW_BORROW_AFTER_DUE={allowBorrowAfterDue}\nDAYS_BEFORE_DUE={daysBeforeDue}";

                File.WriteAllText(infoFile, storeconfig);

                MessageBox.Show("Configuration saved successfully!");
                this.Close();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Discard Changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
