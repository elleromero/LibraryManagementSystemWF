using Isopoh.Cryptography.Argon2;
using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.controllers
{
    internal class AdminController : BaseController
    {
        public static async Task<ControllerModifyData<User>> CreateUser(
            string username,
            string password,
            string firstName,
            string lastName,
            string schoolNumber,
            string address,
            string phone,
            int roleId,
            string email = "",
            string profilePicture = "",
            int? programId = null,
            int? courseYear = null
            )
        {
            ControllerModifyData<User> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin
            if (!await AuthGuard.HavePermission("ADMINISTRATOR"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate fields
            if (!await Validator.IsPhoneUnique(phone)) errors["phone"] = "Phone was already registered";
            if (!await Validator.IsEmailUnique(email)) errors["email"] = "Email was already registered";
            if (!await Validator.IsUsernameUnique(username)) errors["username"] = "Username already exists";
            if (!await Validator.IsSchoolNumUnique(schoolNumber)) errors["school_no"] = "School Number is already exist";
            if (!await Validator.IsRoleIdValid(roleId)) errors["roleId"] = "Invalid Role ID";
            if (programId != null && !await Validator.IsProgramIdValid(programId)) errors["programId"] = "Invalid Program ID";
            if (!Validator.IsName(firstName)) errors["first_name"] = "Name is invalid";
            if (!Validator.IsName(lastName)) errors["last_name"] = "Name is invalid";
            if (!Validator.IsSchoolNum(schoolNumber)) errors["school_no"] = "School Number should atleast 5 characters and contain only numbers";
            if (string.IsNullOrWhiteSpace(address)) errors["address"] = "Address is required";
            if (string.IsNullOrWhiteSpace(phone)) errors["phone"] = "Phone is required";
            if (!string.IsNullOrWhiteSpace(email) && !Validator.IsEmail(email)) errors["email"] = "Email is invalid";
            if (!Validator.IsUsername(username)) errors["username"] = "Username should atleast 5 characters in length and contain only letters, numbers, underscores, or hyphens";
            if (!Validator.IsPassword(password)) errors["password"] = "Password is too short";
            if (phone.Length > 11 || phone.Length < 11) errors["phone"] = "Phone should not exceed or below 11 characters";
            if (courseYear != null && courseYear < 0) errors["courseYear"] = "Invalid Course Year";

            // register user if theres no error
            if (errors.Count == 0)
            {
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                AdminDAO adminDao = new();
                ReturnResult<User> result = await adminDao.Create(new User
                {
                    Username = username.Trim(),
                    PasswordHash = Argon2.Hash(password), // This method consumes some time (2-10 secs.)
                    ProfilePicture = profilePicture,
                    Member = new Member
                    {
                        FirstName = textInfo.ToTitleCase(firstName.Trim()),
                        LastName = textInfo.ToTitleCase(lastName.Trim()),
                        CourseYear = courseYear,
                        SchoolNumber = schoolNumber.Trim(),
                        Address = address.Trim(),
                        Phone = phone.Trim(),
                        Email = email.Trim(),
                        Program = new models.Program
                        {
                            ID = programId
                        }
                    },
                    Role = new Role
                    {
                        ID = roleId
                    }
                });

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

        public static async Task<ControllerModifyData<User>> UpdateUser(
            string userId,
            string username,
            string password,
            string firstName,
            string lastName,
            string schoolNumber,
            string address,
            string phone,
            string adminPassword,
            string email = "",
            string profilePicture = "",
            int? programId = null,
            int? courseYear = null
            )
        {
            ControllerModifyData<User> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin
            if (!await AuthGuard.HavePermission("ADMINISTRATOR", true, adminPassword))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate fields
            if(string.IsNullOrWhiteSpace(phone)) errors["user_id"] = "User ID is required";
            if (!await Validator.IsPhoneUnique(phone, userId)) errors["phone"] = "Phone was already registered";
            if (!await Validator.IsEmailUnique(email, userId)) errors["email"] = "Email was already registered";
            if (!await Validator.IsUsernameUnique(username)) errors["username"] = "Username already exists";
            if (!await Validator.IsSchoolNumUnique(schoolNumber)) errors["school_no"] = "School Number is already exist";
            if (programId != null && !await Validator.IsProgramIdValid(programId)) errors["programId"] = "Invalid Program ID";
            if (!Validator.IsName(firstName)) errors["first_name"] = "Name is invalid";
            if (!Validator.IsName(lastName)) errors["last_name"] = "Name is invalid";
            if (!Validator.IsSchoolNum(schoolNumber)) errors["school_no"] = "School Number should atleast 5 characters and contain only numbers";
            if (string.IsNullOrWhiteSpace(address)) errors["address"] = "Address is required";
            if (string.IsNullOrWhiteSpace(phone)) errors["phone"] = "Phone is required";
            if (!string.IsNullOrWhiteSpace(email) && !Validator.IsEmail(email)) errors["email"] = "Email is invalid";
            if (!Validator.IsUsername(username)) errors["username"] = "Username should atleast 5 characters in length and contain only letters, numbers, underscores, or hyphens";
            if (!Validator.IsPassword(password)) errors["password"] = "Password is too short";
            if (phone.Length > 11 || phone.Length < 11) errors["phone"] = "Phone should not exceed or below 11 characters";
            if (courseYear != null && courseYear < 0) errors["courseYear"] = "Invalid Course Year";

            // update user if theres no error
            if (errors.Count == 0)
            {
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                AdminDAO adminDao = new();

                // check if user with access exists
                ReturnResult<User> user = await adminDao.GetById(userId);

                if (!user.IsSuccess)
                {
                    errors.Add("userId", "User not found");
                    returnData.Errors = errors;
                    returnData.IsSuccess = isSuccess;
                    return returnData;
                }

                // proceed if user is found
                ReturnResult<User> result = await adminDao.Update(new User
                {
                    ID = new Guid(userId),
                    Username = username.Trim(),
                    PasswordHash = Argon2.Hash(password), // This method consumes some time (2-10 secs.)
                    ProfilePicture = profilePicture,
                    Member = new Member
                    {
                        FirstName = textInfo.ToTitleCase(firstName.Trim()),
                        LastName = textInfo.ToTitleCase(lastName.Trim()),
                        CourseYear = courseYear,
                        SchoolNumber = schoolNumber.Trim(),
                        Address = address.Trim(),
                        Phone = phone.Trim(),
                        Email = email.Trim(),
                        Program = new models.Program
                        {
                            ID = programId
                        }
                    }
                });

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

        public static async Task<ControllerModifyData<User>> GetUserById(string id)
        {
            ControllerModifyData<User> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin
            if (!await AuthGuard.HavePermission("ADMINISTRATOR"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

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

        public static async Task<ControllerAccessData<User>> GetAllUsers(int page = 1)
        {
            ControllerAccessData<User> returnData = new()
            {
                Results = new List<User>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin
            if (!await AuthGuard.HavePermission("ADMINISTRATOR"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            if (page <= 0) errors["page"] = "Invalid page";

            if (errors.Count == 0)
            {
                AdminDAO adminDao = new();
                ReturnResultArr<User> result = await adminDao.GetAll(page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerActionData> RemoveById(string id, string password)
        {
            ControllerActionData returnResult = new()
            {
                Errors = new Dictionary<string, string>(),
                IsSuccess = false
            };

            // is not admin
            if (!await AuthGuard.HavePermission("ADMINISTRATOR", true, password))
            {
                returnResult.Errors["permission"] = "Forbidden";

                return returnResult;
            }

            if (AuthGuard.IsLoggedIn(id)) returnResult.Errors["auth"] = "Cannot remove logged in user";

            if (string.IsNullOrWhiteSpace(id)) returnResult.Errors["id"] = "ID is required";

            if (returnResult.Errors.Count == 0)
            {
                AdminDAO adminDao = new();
                returnResult.IsSuccess = await adminDao.Remove(id);
            }

            return returnResult;
        }

        public static async Task<ControllerAccessData<User>> Search(string keyword, int page = 1)
        {
            ControllerAccessData<User> returnData = new()
            {
                Results = new List<User>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin
            if (!await AuthGuard.HavePermission("ADMINISTRATOR"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            if (page <= 0) errors["page"] = "Invalid page";

            if (errors.Count == 0)
            {
                AdminDAO adminDao = new();
                ReturnResultArr<User> result = await adminDao.GetSearchResults(keyword, page);

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
