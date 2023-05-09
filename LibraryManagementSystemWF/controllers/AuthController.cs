using Isopoh.Cryptography.Argon2;
using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.interfaces;
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
    internal class AuthController : BaseController
    {
        public static async Task<ControllerModifyData<User>> Register(
            string username,
            string password,
            string firstName,
            string lastName,
            string address,
            string phone,
            string email = ""
            ) {
            ControllerModifyData<User> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

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

            // register user if theres no error
            if (errors.Count == 0)
            {
                AuthDAO authDao = new();
                ReturnResult<User> result = await authDao.Create(new User
                {
                    Username = username,
                    PasswordHash = Argon2.Hash(password), // This method consumes some time (2-10 secs.)
                    Member = new Member
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        Phone = phone,
                        Email = email
                    },
                    Role = new Role
                    {
                        ID = 2
                    }
                });

                isSuccess = result.IsSuccess;
                if (isSuccess && result.Result != null)
                {
                    // clear password field
                    result.Result.PasswordHash = "";
                    returnData.Result = result.Result;
                }
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerModifyData<User>> SignIn(string username, string password)
        {
            ControllerModifyData<User> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // get username
            AuthDAO authDao = new();
            ReturnResult<User> result = await authDao.GetByUsername(username);

            // if username did not exist
            if (result.Result != default(User))
            {
                // if password did not match
                if (Argon2.Verify(result.Result.PasswordHash, password))
                {
                    // clear password field
                    result.Result.PasswordHash = "";

                    // both username and password matched
                    AuthService.setSignedUser(result.Result);
                    returnData.Result = result.Result;
                    isSuccess = true;
                }
                else errors.Add("password", "Incorrect password");
            } else errors.Add("username", "Username did not exist");

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static ControllerActionData LogOut() {
            ControllerActionData returnData = new();
            
            AuthService.setSignedUser(default);
            returnData.IsSuccess = true;

            return returnData;
        }
    }
}
