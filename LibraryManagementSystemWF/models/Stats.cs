using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.models
{
    public class Stats
    {
        // This model is not part of the erd.

        public int TotalBooks { get; set; }
        public int TotalBorrowedBooks { get; set; }
        public int TotalReturnedBooks { get; set; }
        public int TotalAvailableCopies { get; set; }
    }
}
