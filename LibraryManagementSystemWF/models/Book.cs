using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.models
{
    public class Book
    {
        public Guid ID { get; set; }
        public BookMetadata BookMetadata { get; set; } = new BookMetadata();
        public int AvailableCopies { get; set; }
    }
}
