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
    internal class CopyController : BaseController
    {
        public static async Task<ControllerModifyData<Copy>> CreateCopies(string bookId, int copies = 1)
        {
            ControllerModifyData<Copy> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin
            if (!await AuthGuard.IsAdmin())
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            if (string.IsNullOrWhiteSpace(bookId)) errors.Add("bookId", "ID is invalid");
            if (copies <= 0 || copies > 50) errors.Add("copies", "Copies should between 1 to 50");

            if (errors.Count == 0)
            {
                CopyDAO copyDao = new();
                ReturnResult<Copy> result = await copyDao.CreateMany(bookId, copies);

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerModifyData<Copy>> GetCopyById(string id)
        {
            ControllerModifyData<Copy> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // validate fields
            if (string.IsNullOrWhiteSpace(id)) errors.Add("id", "ID is invalid");

            if (errors.Count == 0)
            {
                CopyDAO copyDao = new();
                ReturnResult<Copy> result = await copyDao.GetById(id);

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

        public static async Task<ControllerAccessData<Copy>> GetAllCopies(int page = 1)
        {
            ControllerAccessData<Copy> returnData = new()
            {
                Results = new List<Copy>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0)
            {
                CopyDAO copyDao = new();
                ReturnResultArr<Copy> result = await copyDao.GetAll(page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerAccessData<Copy>> GetAllCopiesWithBook(string bookId, int page = 1)
        {
            ControllerAccessData<Copy> returnData = new()
            {
                Results = new List<Copy>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0)
            {
                CopyDAO copyDao = new();
                ReturnResultArr<Copy> result = await copyDao.GetAllWithBooks(bookId, page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerActionData> RemoveById(string id)
        {
            ControllerActionData returnResult = new()
            {
                Errors = new Dictionary<string, string>(),
                IsSuccess = false
            };

            // is not admin
            if (!await AuthGuard.IsAdmin())
            {
                returnResult.Errors.Add("permission", "Forbidden");

                return returnResult;
            }

            if (returnResult.Errors.Count == 0)
            {
                CopyDAO copyDao = new();
                returnResult.IsSuccess = await copyDao.Remove(id);
            }

            return returnResult;
        }
    }
}
