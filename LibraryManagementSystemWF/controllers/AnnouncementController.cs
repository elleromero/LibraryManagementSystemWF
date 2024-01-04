using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystemWF.controllers
{
    internal class AnnouncementController : BaseController
    {
        public static async Task<ControllerModifyData<Announcement>> Create(
            string header,
            string body,
            DateTime announcementDue,
            List<RoleEnum> publishToRoles,
            string cover = "",
            bool isPriority = false
            )
        {
            ControllerModifyData<Announcement> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            Guid? userId = AuthService.getSignedUser()?.ID;

            // is not librarian or administrator
            if (await AuthGuard.HavePermission("USER"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate fields
            // if (!await Validator.IsAnnouncementTitleUnique(header)) errors["header"] = "Header already exists";
            if (string.IsNullOrWhiteSpace(header)) errors["header"] = "Header is required";
            if (string.IsNullOrWhiteSpace(body)) errors["body"] = "Body is required";
            if (!Validator.IsDateAfter(announcementDue)) errors["announcementDue"] = "Datetime must be after the present date";
            if (!Validator.IsUserHavePermissionToPublish(publishToRoles)) errors["publishToRoles"] = "Forbidden";

            if (errors.Count == 0)
            {
                AnnouncementDAO announcementDao = new();
                ReturnResult<Announcement> result = await announcementDao.Create(new Announcement
                {
                    Header = header.Trim(),
                    Body = body.Trim(),
                    Due = announcementDue,
                    Cover = cover.Trim(),
                    IsPriority = isPriority,
                    User = new User()
                    {
                        ID = userId ?? Guid.Empty
                    }
                }, publishToRoles);

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerModifyData<Announcement>> Update(
            string announcementId,
            string header,
            string body,
            DateTime announcementDue,
            List<RoleEnum> publishToRoles,
            string cover,
            bool isPriority
            )
        {
            ControllerModifyData<Announcement> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            Guid? userId = AuthService.getSignedUser()?.ID;

            // is not librarian or administrator
            if (await AuthGuard.HavePermission("USER"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate fields
            if (string.IsNullOrWhiteSpace(announcementId)) errors["announcementId"] = "Announcement ID is required";
           //  if (!await Validator.IsAnnouncementTitleUnique(header, announcementId)) errors["header"] = "Header already exists";
            if (string.IsNullOrWhiteSpace(header)) errors["header"] = "Header is required";
            if (string.IsNullOrWhiteSpace(body)) errors["body"] = "Body is required";    
            if (!Validator.IsDateAfter(announcementDue)) errors["announcementDue"] = "Datetime must be after the present date";
            if (!Validator.IsUserHavePermissionToPublish(publishToRoles)) errors["publishToRoles"] = "Forbidden";

            if (errors.Count == 0)
            {
                AnnouncementDAO announcementDao = new();
                ReturnResult<Announcement> result = await announcementDao.Update(new Announcement
                {
                    ID = new Guid(announcementId),
                    Header = header.Trim(),
                    Body = body.Trim(),
                    Due = announcementDue,
                    Cover = cover.Trim(),
                    IsPriority = isPriority,
                    User = new User()
                    {
                        ID = userId ?? Guid.Empty
                    }
                }, publishToRoles);

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerAccessData<Announcement>> GetAllWithPastDue(int page = 1)
        {
            ControllerAccessData<Announcement> returnData = new()
            {
                Results = new List<Announcement>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (page <= 0) errors["page"] = "Invalid page";

            if (errors.Count == 0)
            {
                AnnouncementDAO announcementDAO = new();
                ReturnResultArr<Announcement> result = await announcementDAO.GetAllAndIncludePastDue(page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerAccessData<Announcement>> GetAll(int page = 1)
        {
            ControllerAccessData<Announcement> returnData = new()
            {
                Results = new List<Announcement>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (page <= 0) errors["page"] = "Invalid page";

            if (errors.Count == 0)
            {
                AnnouncementDAO announcementDao = new();
                ReturnResultArr<Announcement> result = await announcementDao.GetAll(page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerActionData> RemoveById(string announcementId)
        {
            ControllerActionData returnResult = new()
            {
                Errors = new Dictionary<string, string>(),
                IsSuccess = false
            };

            // is not librarian or admin
            if (await AuthGuard.HavePermission("USER"))
            {
                returnResult.Errors["permission"] = "Forbidden";

                return returnResult;
            }

            if (string.IsNullOrWhiteSpace(announcementId)) returnResult.Errors["id"] = "ID is required";

            if (returnResult.Errors.Count == 0)
            {
                AnnouncementDAO announcementDao = new();
                returnResult.IsSuccess = await announcementDao.Remove(announcementId);
            }

            return returnResult;
        }

        public static async Task<ControllerAccessData<Announcement>> Search(string keyword, int page = 1)
        {
            ControllerAccessData<Announcement> returnData = new()
            {
                Results = new List<Announcement>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (page <= 0) errors["page"] = "Invalid page";

            if (errors.Count == 0)
            {
                AnnouncementDAO annDao = new();
                ReturnResultArr<Announcement> result = await annDao.GetSearchResults(keyword, page);

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
