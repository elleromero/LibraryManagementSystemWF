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
    internal class ProgramController : BaseController
    {
        public static async Task<ControllerAccessData<models.Program>> GetAllPrograms()
        {
            ControllerAccessData<models.Program> returnData = new()
            {
                Results = new List<models.Program>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (errors.Count == 0)
            {
                ProgramDAO programDao = new();
                ReturnResultArr<models.Program> result = await programDao.GetAll();

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
