using Isopoh.Cryptography.Argon2;
using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            string schoolNumber,
            string address,
            string phone,
            string email = "",
            string profilePicture = "",
            int? programId = null,
            int? courseYear = null
            ) {
            ControllerModifyData<User> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // validate fields
            if (!await Validator.IsPhoneUnique(phone)) errors["phone"] = "Phone was already registered";
            if (!await Validator.IsEmailUnique(email)) errors["email"] = "Email was already registered";
            if (!await Validator.IsUsernameUnique(username)) errors["username"] = "Username already exists";
            if (!Validator.IsName(firstName)) errors["first_name"] = "Name is invalid";
            if (!Validator.IsName(lastName)) errors["last_name"] = "Name is invalid";
            if (!Validator.IsSchoolNum(schoolNumber)) errors["school_no"] = "School Number should atleast 5 characters and contain only numbers";
            if (string.IsNullOrWhiteSpace(address)) errors["address"] = "Address is required";
            if (string.IsNullOrWhiteSpace(phone)) errors["phone"] = "Phone is required";
            if (!string.IsNullOrWhiteSpace(email) && !Validator.IsEmail(email)) errors["email"] = "Email is invalid";
            if (!Validator.IsUsername(username)) errors["username"] = "Username should atleast 5 characters in length and contain only letters, numbers, underscores, or hyphens";
            if (!Validator.IsPassword(password)) errors["password"] = "Password is too short";
            if (phone.Length > 11 || phone.Length < 11) errors["phone"] = "Phone should not exceed or below 11 characters";

            // register user if theres no error
            if (errors.Count == 0)
            {
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                AuthDAO authDao = new();
                ReturnResult<User> result = await authDao.Create(new User
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
                else errors["password"] = "Incorrect password";
            } else errors["username"] = "Username did not exist";

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
