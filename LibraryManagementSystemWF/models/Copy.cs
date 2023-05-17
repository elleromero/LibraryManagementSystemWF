using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.models
{
    public class Copy
    {
        public Guid ID { get; set; }
        public Book Book { get; set; } = new Book();
        public Status Status { get; set; } = new Status();
    }
}
