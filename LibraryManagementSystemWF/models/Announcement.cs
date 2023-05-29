using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.models
{
    internal class Announcement
    {
        public Guid ID { get; set; }

        public string Header { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;

        public DateTime Due { get; set; }

        public DateTime Timestamp { get; set; }

        public string Cover { get; set; } = string.Empty;

        public bool IsPriority { get; set; }

        public User User { get; set; } = new();
    }
}
