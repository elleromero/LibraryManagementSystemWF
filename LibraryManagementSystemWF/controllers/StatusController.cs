using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.controllers
{
    internal class StatusController
    {
        public static async Task<ControllerAccessData<Status>> GetAllStatuses()
        {
            ControllerAccessData<Status> returnData = new()
            {
                Results = new List<Status>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (errors.Count == 0)
            {
                StatusDAO statusDao = new();
                ReturnResultArr<Status> result = await statusDao.GetAll();

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
