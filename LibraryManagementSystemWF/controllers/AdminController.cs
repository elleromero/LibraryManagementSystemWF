using Isopoh.Cryptography.Argon2;
using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
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
            string address,
            string phone,
            int roleId,
            string email = ""
            )
        {
            ControllerModifyData<User> returnData = new()
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

            // validate fields
            if (!Validator.IsName(firstName)) errors.Add("first_name", "Name is invalid");
            if (!Validator.IsName(lastName)) errors.Add("last_name", "Name is invalid");
            if (string.IsNullOrWhiteSpace(address)) errors.Add("address", "Address is required");
            if (string.IsNullOrWhiteSpace(phone)) errors.Add("phone", "Phone is required");
            if (!string.IsNullOrWhiteSpace(email) && !Validator.IsEmail(email)) errors.Add("email", "Email is invalid");
            if (!Validator.IsUsername(username)) errors.Add(
                "username",
                "Username should contain only letters, numbers, underscores, or hyphens"
                );
            if (!await Validator.IsUsernameUnique(username)) errors.Add(
                "username",
                "Username already exists"
                );
            if (!Validator.IsPassword(password)) errors.Add(
                "password",
                "Password is too short"
                );

            // register admin if theres no error
            if (errors.Count == 0)
            {
                AdminDAO adminDao = new();
                ReturnResult<User> result = await adminDao.Create(new User
                {
                    Username = username,
                    PasswordHash = Argon2.Hash(password), // This method consumes some time (2-10 secs.)
                    Member = new Member
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        Phone = phone
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
            string address,
            string phone,
            string adminPassword,
            string email = ""
            )
        {
            ControllerModifyData<User> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin
            if (!await AuthGuard.IsAdmin(true, adminPassword))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate fields
            if (!Validator.IsName(firstName)) errors.Add("first_name", "Name is invalid");
            if (!Validator.IsName(lastName)) errors.Add("last_name", "Name is invalid");
            if (string.IsNullOrWhiteSpace(address)) errors.Add("address", "Address is required");
            if (string.IsNullOrWhiteSpace(phone)) errors.Add("phone", "Phone is required");
            if (!string.IsNullOrWhiteSpace(email) && !Validator.IsEmail(email)) errors.Add("email", "Email is invalid");
            if (!Validator.IsUsername(username)) errors.Add(
                "username",
                "Username should contain only letters, numbers, underscores, or hyphens"
                );
            if (!Validator.IsPassword(password)) errors.Add(
                "password",
                "Password is too short"
                );

            // update user if theres no error
            if (errors.Count == 0)
            {
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
                    Username = username,
                    PasswordHash = Argon2.Hash(password), // This method consumes some time (2-10 secs.)
                    Member = new Member
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        Phone = phone,
                        Email = email
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
            if (!await AuthGuard.IsAdmin())
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate fields
            if (string.IsNullOrWhiteSpace(id)) errors.Add("id", "ID is invalid");

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
            if (!await AuthGuard.IsAdmin())
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            if (page <= 0) errors.Add("page", "Invalid page");

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
            if (!await AuthGuard.IsAdmin(true, password))
            {
                returnResult.Errors.Add("permission", "Forbidden");

                return returnResult;
            }

            if (AuthGuard.IsLoggedIn(id)) returnResult.Errors.Add("auth", "Cannot remove logged in user"); 
            
            if (returnResult.Errors.Count == 0)
            {
                AdminDAO adminDao = new();
                returnResult.IsSuccess = await adminDao.Remove(id);
            }

            return returnResult;
        }

    }
}
