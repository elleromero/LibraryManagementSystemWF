using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.models
{
    public class Loan
    {
        public Guid ID { get; set; }
        public User User { get; set; } = new User();
        public Copy Copy { get; set; } = new Copy();
        public DateTime DateBorrowed { get; set; }
        public DateTime DateDue { get; set; }
        public bool IsReturned { get; set; }
    }
}
