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
        public static ControllerAccessData<Status> GetAllStatuses()
        {
            ControllerAccessData<Status> returnData = new ControllerAccessData<Status>();
            returnData.Results = new List<Status>();
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;
            returnData.rowCount = 0;

            if (errors.Count == 0)
            {
                StatusDAO statusDao = new StatusDAO();
                ReturnResultArr<Status> result = statusDao.GetAll();

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
