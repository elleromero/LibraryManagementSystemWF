using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.utils
{
    internal class ActivityLogger
    {
        public static async void Log(string message, Guid userId, ActivityTypeEnum type)
        {
            // store history
            await new ActivityLogDAO().Create(new ActivityLog
            {
                Log = message,
                Type = new ActivityType
                {
                    ID = (int)type
                },
                User = new User
                {
                    ID = userId
                }
            });
        }
    }
}
