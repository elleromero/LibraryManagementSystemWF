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
            Guid userId = AuthService.getSignedUser().ID;

            // is not librarian or administrator
            if (await AuthGuard.HavePermission("USER"))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate fields
            if (!await Validator.IsNameUnique("announcements", "announcement_header", header)) errors.Add("header", "Header already exists");
            if (string.IsNullOrWhiteSpace(header)) errors.Add("header", "Header is required");
            if (string.IsNullOrWhiteSpace(body)) errors.Add("body", "Body is required");
            if (!Validator.IsDateAfter(announcementDue)) errors.Add("announcementDue", "Datetime must be after date");
            if (!Validator.IsUserHavePermissionToPublish(publishToRoles)) errors.Add("publishToRoles", "Forbidden");

            if (errors.Count == 0)
            {
                AnnouncementDAO announcementDao = new();
                ReturnResult<Announcement> result = await announcementDao.Create(new Announcement
                {
                    Header = header,
                    Body = body,
                    Due = announcementDue,
                    Cover = cover,
                    IsPriority = isPriority,
                    User = new User()
                    {
                        ID = userId
                    }
                }, publishToRoles);

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerModifyData<Announcement>> Update()
        {
            throw new NotImplementedException();
        }

        public static async Task<ControllerAccessData<Announcement>> GetAllBeforeDue(int page = 1)
        {
            throw new NotImplementedException();
        }

        public static async Task<ControllerAccessData<Announcement>> GetAll(int page = 1)
        {
            throw new NotImplementedException();
        }

        public static async Task<ControllerActionData> Remove(string announcementId)
        {
            throw new NotImplementedException();
        }
    }
}
