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
        public static ControllerModifyData<Copy> CreateCopies(string bookId, int copies = 1)
        {
            ControllerModifyData<Copy> returnData = new ControllerModifyData<Copy>();
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;

            // is not admin
            if (!AuthGuard.IsAdmin())
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
                CopyDAO copyDao = new CopyDAO();
                ReturnResult<Copy> result = copyDao.CreateMany(bookId, copies);

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static ControllerModifyData<Copy> GetCopyById(string id)
        {
            ControllerModifyData<Copy> returnData = new ControllerModifyData<Copy>();
            returnData.Result = default(Copy);
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;

            // validate fields
            if (string.IsNullOrWhiteSpace(id)) errors.Add("id", "ID is invalid");

            if (errors.Count == 0)
            {
                CopyDAO copyDao = new CopyDAO();
                ReturnResult<Copy> result = copyDao.GetById(id);

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

        public static ControllerAccessData<Copy> GetAllCopies(int page = 1)
        {
            ControllerAccessData<Copy> returnData = new ControllerAccessData<Copy>();
            returnData.Results = new List<Copy>();
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;
            returnData.rowCount = 0;

            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0)
            {
                CopyDAO copyDao = new CopyDAO();
                ReturnResultArr<Copy> result = copyDao.GetAll(page);

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
