using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.utils
{
    internal class DialogBuilder
    {
        public static void Show(string msgString, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(
                msgString,
                title,
                MessageBoxButtons.OK,
                icon
                );
        }

        public static void Show(Dictionary<string, string> errors, string title, MessageBoxIcon icon)
        {
            string msgString = "Action failed. The following errors occurred: \n";

            foreach (KeyValuePair<string, string> err in errors)
            {
                msgString += $"\n{err.Key}: '{err.Value}'";
            }

            MessageBox.Show(
                msgString,
                title,
                MessageBoxButtons.OK,
                icon
                );
        }
    }
}
