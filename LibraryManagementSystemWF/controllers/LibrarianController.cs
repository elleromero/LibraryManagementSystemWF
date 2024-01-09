using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.controllers
{
    internal class LibrarianController : BaseController
    {
        public static async Task<ControllerAccessData<User>> GetAllUsersOnly(int page = 1)
        {
            ControllerAccessData<User> returnData = new()
            {
                Results = new List<User>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? userId = AuthService.getSignedUser()?.ID.ToString();

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate
            if (string.IsNullOrWhiteSpace(userId)) errors.Add("auth", "Please login");
            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0 && userId != null)
            {
                LibrarianDAO libDao = new();
                ReturnResultArr<User> result = await libDao.GetAll(page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerAccessData<User>> SearchUsersOnly(string keyword, int page = 1)
        {
            ControllerAccessData<User> returnData = new()
            {
                Results = new List<User>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            if (page <= 0) errors["page"] = "Invalid page";

            if (errors.Count == 0)
            {
                LibrarianDAO libDao = new();
                ReturnResultArr<User> result = await libDao.GetSearchResults(keyword, page);

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
