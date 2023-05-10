using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystemWF.controllers
{
    internal class RoleController : BaseController
    {
        public static async Task<ControllerAccessData<Role>> GetAllRoles()
        {
            ControllerAccessData<Role> returnData = new ControllerAccessData<Role>
            {
                Results = new List<Role>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (errors.Count == 0)
            {
                RoleDAO roleDao = new();
                ReturnResultArr<Role> result = await roleDao.GetAll();

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
