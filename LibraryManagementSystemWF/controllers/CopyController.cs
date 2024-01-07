﻿using LibraryManagementSystemWF.dao;
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
    internal class CopyController : BaseController
    {
        public static async Task<ControllerModifyData<Copy>> CreateCopies(string bookId, int sourceId, decimal price, int copies = 1)
        {
            ControllerModifyData<Copy> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            Config config = new();
            int maxCopies = config.maxCopies;
            decimal maxPrice = config.maxPrice;
            if (string.IsNullOrWhiteSpace(bookId)) errors["bookId"] = "ID is invalid";
            if (copies < 0 || copies > maxCopies) errors["copies"] = $"Copies should between 1 to {maxCopies}";
            if (price > maxPrice || price < 0) errors["price"] = "Invalid Price";
            if (!await Validator.IsSourceIdValid(sourceId)) errors["sourceId"] = "Source is invalid";

            if (errors.Count == 0)
            {
                CopyDAO copyDao = new();
                ReturnResult<Copy> result = await copyDao.CreateMany(bookId, copies, sourceId, price);

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;

                if (isSuccess)
                {
                    // Log
                    User? signedUser = AuthService.getSignedUser();
                    if (signedUser != null)
                    {
                        // log history
                        ActivityLogger.Log($"{signedUser.Username} created {copies} copies of '{bookId[..4]}' [SOURCE: {(SourceEnum)sourceId}]", signedUser.ID, ActivityTypeEnum.COPY_OPERATION);
                    }
                }
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
            if (string.IsNullOrWhiteSpace(id)) errors["id"] = "ID is invalid";

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

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

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

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

            // validate fields
            if (string.IsNullOrWhiteSpace(bookId)) errors["bookId"] = "Book ID is invalid";
            if (page <= 0) errors["page"] = "Invalid page";

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

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                returnResult.Errors["permission"] = "Forbidden";

                return returnResult;
            }

            // validate fields
            if (string.IsNullOrWhiteSpace(id)) returnResult.Errors["id"] = "ID is invalid";

            if (returnResult.Errors.Count == 0)
            {
                CopyDAO copyDao = new();
                returnResult.IsSuccess = await copyDao.Remove(id);


                if (returnResult.IsSuccess)
                {
                    // Log
                    User? signedUser = AuthService.getSignedUser();
                    if (signedUser != null)
                    {
                        // log history
                        ActivityLogger.Log($"{signedUser.Username} removed copy '{id[..4]}'", signedUser.ID, ActivityTypeEnum.COPY_OPERATION);
                    }
                }
            }

            return returnResult;
        }

        public static async Task<ControllerModifyData<Copy>> UpdateCopy(string copyId, int sourceId, decimal price)
        {
            ControllerModifyData<Copy> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            Config config = new();
            decimal maxPrice = config.maxPrice;
            if (string.IsNullOrWhiteSpace(copyId)) errors["copyId"] = "ID is invalid";
            if (price > maxPrice || price < 0) errors["price"] = "Invalid Price";
            if (!await Validator.IsSourceIdValid(sourceId)) errors["sourceId"] = "Source is invalid";

            if (errors.Count == 0)
            {
                CopyDAO copyDao = new();
                ReturnResult<Copy> result = await copyDao.Update(new Copy
                {
                    ID = new Guid(copyId),
                    Price = price,
                    Source = new Source
                    {
                        ID = sourceId
                    }
                });

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;

                if (isSuccess)
                {
                    // Log
                    User? signedUser = AuthService.getSignedUser();
                    if (signedUser != null)
                    {
                        // log history
                        ActivityLogger.Log($"{signedUser.Username} updated '{copyId[..4]}' to price {price} [SOURCE: {(SourceEnum)sourceId}]", signedUser.ID, ActivityTypeEnum.COPY_OPERATION);
                    }
                }
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

    }
}
