using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.utils
{
    internal class Config
    {
        private string infoFile = "../../../resources/config/config.txt";
        public int maxBorrowedBooks { get; }
        public int maxCopies { get; }
        public int daysBeforeDue { get; }
        public decimal maxPrice { get; }
        public bool allowBorrowAfterDue { get; }

        public Config() 
        {
            Dictionary<string, string> dict = new();
            string[] configBase = File.ReadAllLines(infoFile);

            foreach (string s in configBase)
            {
                string[] parts = s.Split('=');
                dict.Add(parts[0], parts[1]);
            }

            maxBorrowedBooks = Int32.Parse(dict["MAX_BORROWED_BOOKS"]);
            maxCopies = Int32.Parse(dict["MAX_COPIES"]);
            maxPrice = Decimal.Parse(dict["MAX_PRICE"]);
            allowBorrowAfterDue = Boolean.Parse(dict["ALLOW_BORROW_AFTER_DUE"]);
            daysBeforeDue = Int32.Parse(dict["DAYS_BEFORE_DUE"]);
        }
    }
}
