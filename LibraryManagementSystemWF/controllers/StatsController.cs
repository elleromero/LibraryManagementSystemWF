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
    internal class StatsController : BaseController
    {
        public static async Task<ControllerModifyData<Stats>> GetStats()
        {
            ControllerModifyData<Stats> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // validation
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            if (errors.Count == 0)
            {
                StatsDAO statsDao = new();
                ReturnResult<Stats> result = await statsDao.Get();

                isSuccess = result.IsSuccess;
                if (isSuccess && result.Result != null)
                {
                    returnData.Result = result.Result;
                }
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }
    }
}
