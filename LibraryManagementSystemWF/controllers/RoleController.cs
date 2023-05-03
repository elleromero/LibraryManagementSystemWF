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
        public static ControllerAccessData<Role> GetAllRoles()
        {
            ControllerAccessData<Role> returnData = new ControllerAccessData<Role>();
            returnData.Results = new List<Role>();
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;
            returnData.rowCount = 0;

            if (errors.Count == 0)
            {
                RoleDAO roleDao = new RoleDAO();
                ReturnResultArr<Role> result = roleDao.GetAll();

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
