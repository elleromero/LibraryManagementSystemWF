using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.controllers
{
    internal class ActivityLogController : BaseController
    {
        public static async Task<ControllerAccessData<ActivityLog>> GetAllUsers(int page = 1)
        {
            ControllerAccessData<ActivityLog> returnData = new()
            {
                Results = new List<ActivityLog>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin or not librarian
            if (!await AuthGuard.HavePermission("ADMINISTRATOR") || !await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            if (page <= 0) errors["page"] = "Invalid page";

            if (errors.Count == 0)
            {
                ActivityLogDAO activityLogDao = new();
                ReturnResultArr<ActivityLog> result = await activityLogDao.GetAll(page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }
    }
}
