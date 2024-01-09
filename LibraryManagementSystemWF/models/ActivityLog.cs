using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.models
{
    public class ActivityLog
    {
        public Guid ID { get; set; }

        public string Log { get; set; } = string.Empty;

        public ActivityType Type { get; set; } = new ActivityType();

        public User User { get; set; } = new();

        public DateTime Timestamp { get; set; }
    }
}
