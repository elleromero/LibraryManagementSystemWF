using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.controllers
{
    internal class GuestController : BaseController
    {
        public static async Task<ControllerAccessData<Loan>> GetAllBorrowedBooks(string userId, int page = 1)
        {
            ControllerAccessData<Loan> returnData = new()
            {
                Results = new List<Loan>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? signedUserId = AuthService.getSignedUser()?.ID.ToString();

            // is not user
            if (!await AuthGuard.HavePermission("USER") && signedUserId != null)
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate
            if (string.IsNullOrWhiteSpace(userId)) errors.Add("userId", "Please provide an id");
            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0 && userId != null)
            {
                LoanDAO loanDao = new();
                ReturnResultArr<Loan> result = await loanDao.GetAllLoans(page, new Loan
                {
                    User = new User
                    {
                        ID = new Guid(userId)
                    }
                });

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerAccessData<Loan>> Search(string keyword, string userId, int page = 1)
        {
            ControllerAccessData<Loan> returnData = new()
            {
                Results = new List<Loan>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? signedUserId = AuthService.getSignedUser()?.ID.ToString();

            // is not user
            if (!await AuthGuard.HavePermission("USER") && signedUserId != null)
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate
            if (string.IsNullOrWhiteSpace(userId)) errors.Add("userId", "Please provide an id");
            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0 && userId != null)
            {
                LoanDAO loanDao = new();
                ReturnResultArr<Loan> result = await loanDao.GetSearchResults(userId, keyword, page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerModifyData<User>> GetUserById(string id)
        {
            ControllerModifyData<User> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? signedUserId = AuthService.getSignedUser()?.ID.ToString();

            // validate fields
            if (string.IsNullOrWhiteSpace(id)) errors["id"] = "ID is invalid";

            if (errors.Count == 0)
            {
                AdminDAO adminDao = new();
                ReturnResult<User> result = await adminDao.GetById(id);

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
