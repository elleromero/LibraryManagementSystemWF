using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.utils
{
    internal class Validator
    {
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            try
            {
                var emailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
                    RegexOptions.Compiled);

                return emailRegex.IsMatch(email);
            }
            catch { return false; }
        }

        public static bool IsPhone(string phone) {
            if (string.IsNullOrWhiteSpace(phone)) return false;

            try
            {
                var phoneNumberRegex = new Regex(@"^\+63[0-9]{10}$");
                return phoneNumberRegex.IsMatch(phone);
            }
            catch { return false; }
        }

        public static bool IsName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            // Remove any whitespace from the beginning and end of the string
            name = name.Trim();

            // Check if the name contains only letters and spaces
            if (!Regex.IsMatch(name, @"^[a-zA-Z' -]+$")) return false;

            // Check if the name is not too long (100 characters or less)
            if (name.Length > 50) return false;

            return true;
        }

        public static bool IsUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;

            // Check if the username contains only letters, numbers, underscores, or hyphens
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_-]+$")) return false;

            // Check if the username is not too long (50 characters or less)
            if (username.Length > 50) return false;

            if (username.Length < 5) return false;

            return true;
        }

        public static async Task<bool> IsNameUnique(string tableName, string columnName, string value)
        {
            bool isUnique = false;
            
            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                SqlDataReader? reader = null;

                try
                {
                    if (error != null) return;
                    
                    string query = $"SELECT * FROM {tableName}";
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        string name = reader.GetString(reader.GetOrdinal(columnName));

                        name = Regex.Replace(name, @"\s+", "_").ToLower();
                        value = Regex.Replace(value, @"\s+", "_").ToLower();

                        if (name.Equals(value)) return;
                    }

                    isUnique = true;
                }
                catch { return; }
            });

            return isUnique;
        }

        public static async Task<bool> IsPhoneUnique(string phone, string userId = "")
        {
            bool isUnique = false;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                SqlDataReader? reader = null;

                try
                {
                    if (error != null) return;

                    string query = string.IsNullOrWhiteSpace(userId) ?
                    $"SELECT phone FROM members WHERE phone = '{phone}'" :
                    $"SELECT phone FROM users u JOIN members m ON m.member_id = u.member_id WHERE m.phone = '{phone}' AND u.user_id != '{userId}'";
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        string name = reader.GetString(reader.GetOrdinal("phone"));

                        if (name.Equals(phone)) return;
                    }

                    isUnique = true;
                }
                catch { return; }
            });

            return isUnique;
        }

        public static async Task<bool> IsEmailUnique(string email, string userId = "")
        {
            bool isUnique = false;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                SqlDataReader? reader = null;

                try
                {
                    if (error != null) return;

                    string query = string.IsNullOrWhiteSpace(userId) ?
                    $"SELECT email FROM members WHERE email = '{email}'" :
                    $"SELECT email FROM users u JOIN members m ON m.member_id = u.member_id WHERE m.email = '{email}' AND u.user_id != '{userId}'";
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        string name = reader.GetString(reader.GetOrdinal("email"));

                        if (name.Equals(email)) return;
                    }

                    isUnique = true;
                }
                catch { return; }
            });

            return isUnique;
        }

        public static async Task<bool> IsISBNUnique(string isbn, string bookId = "")
        {
            bool isUnique = false;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                SqlDataReader? reader = null;

                try
                {
                    if (error != null) return;

                    string query = string.IsNullOrWhiteSpace(bookId) ?
                    $"SELECT isbn FROM books WHERE isbn = '{isbn}'" :
                    $"SELECT isbn FROM books WHERE isbn = '{isbn}' AND book_id != '{bookId}'";
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        string name = reader.GetString(reader.GetOrdinal("isbn"));

                        if (name.Equals(isbn)) return;
                    }

                    isUnique = true;
                }
                catch { return; }
            });

            return isUnique;
        }

        public static async Task<bool> IsUsernameUnique(string username, string userId = "")
        {
            // Check if username is unique
            bool isUnique = false;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                SqlDataReader? reader = null;

                try
                {
                    if (error != null) return;

                    string query = string.IsNullOrWhiteSpace(userId) ?
                    $"SELECT username FROM users WHERE user = '{username}'" :
                    $"SELECT username FROM users WHERE username = '{username}' AND user_id != '{userId}'";
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        string name = reader.GetString(reader.GetOrdinal("username"));

                        if (name.Equals(username)) return;
                    }

                    isUnique = true;
                }
                catch { return; }
            });

            return isUnique;
        }

        public static async Task<bool> IsAnnouncementTitleUnique(string annTitle, string annId = "")
        {
            // Check if username is unique
            bool isUnique = false;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                SqlDataReader? reader = null;

                try
                {
                    if (error != null) return;

                    string query = string.IsNullOrWhiteSpace(annId) ?
                    $"SELECT announcement_title FROM announcements WHERE announcement_title = '{annTitle}'" :
                    $"SELECT announcement_title FROM announcements WHERE announcement_title = '{annTitle}' AND announcement_id != '{annId}'";
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        string name = reader.GetString(reader.GetOrdinal("announcement_title"));

                        if (name.Equals(annTitle)) return;
                    }

                    isUnique = true;
                }
                catch { return; }
            });

            return isUnique;
        }

        public static bool IsPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            if (password.Length < 6) return false;

            return true;
        }

        public static async Task<bool> IsGenreIdValid(int? genreId)
        {
            bool isValid = false;

            if (genreId == null) return isValid; 

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                try
                {
                    int count = 0;
                    if (error != null) return;

                    string query = $"SELECT COUNT(*) FROM genres WHERE genre_id = {genreId}";
                    SqlCommand command = new(query, conn);

                    object? v = await command.ExecuteScalarAsync();
                    if (v != null) count = (int)v;


                    isValid = count > 0;
                } catch { return; }
            });

            return isValid;
        }

        public static async Task<bool> IsRoleIdValid(int? roleId)
        {
            bool isValid = false;

            if (roleId == null) return isValid;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                try
                {
                    int count = 0;
                    if (error != null) return;

                    string query = $"SELECT COUNT(*) FROM roles WHERE role_id = {roleId}";
                    SqlCommand command = new(query, conn);

                    object? v = await command.ExecuteScalarAsync();
                    if (v != null) count = (int)v;


                    isValid = count > 0;
                }
                catch { return; }
            });

            return isValid;
        }

        public static bool IsDateBeforeOrOnPresent(DateTime date)
        {
            DateTime currentDate = DateTime.Now;
            return date <= currentDate;
        }

        public static bool IsDateAfter(DateTime date)
        {
            DateTime currentDate = DateTime.Now;
            return date > currentDate;
        }

        public static bool IsUserHavePermissionToPublish(List<RoleEnum> roles)
        {
            User? user = AuthService.getSignedUser();

            RoleEnum[] adminAccess = { RoleEnum.ADMINISTRATOR, RoleEnum.LIBRARIAN, RoleEnum.USER };
            RoleEnum[] librarianAccess = { RoleEnum.LIBRARIAN, RoleEnum.USER };

            if (user == null) return false;

            if (!user.Role.HasAccess) return false;

            if (user.Role.Name.ToUpper() == "ADMINISTRATOR" && roles.Any(adminAccess.Contains) && roles.Count <= adminAccess.Length) return true;
           
            if (user.Role.Name.ToUpper() == "LIBRARIAN" && roles.Any(librarianAccess.Contains) && roles.Count <= librarianAccess.Length) return true;

            return false;
        }

        public static bool IsValidISBN(string isbn)
        {
            // Remove any hyphens or spaces from the input string
            isbn = isbn.Replace("-", "").Replace(" ", "");

            // An ISBN must be 10 or 13 digits long
            if (isbn.Length != 10 && isbn.Length != 13)
            {
                return false;
            }

            // Check if the last character is an X (only valid for ISBN-10)
            if (isbn.Length == 10 && isbn[9] == 'X')
            {
                isbn = string.Concat(isbn.AsSpan(0, 9), "10");
            }

            // Check if all characters are digits (except for the last one in ISBN-10)
            for (int i = 0; i < isbn.Length; i++)
            {
                if (i == 9 && isbn.Length == 10)
                {
                    break;
                }
                if (!Char.IsDigit(isbn[i]))
                {
                    return false;
                }
            }

            // Calculate the check digit for ISBN-10
            if (isbn.Length == 10)
            {
                int sum = 0;
                for (int i = 0; i < 9; i++)
                {
                    sum += (i + 1) * int.Parse(isbn[i].ToString());
                }
                int checkDigit = sum % 11;
                if (checkDigit == 10 && isbn[9] != 'X' || checkDigit != int.Parse(isbn[9].ToString()))
                {
                    return false;
                }
            }

            // Calculate the check digit for ISBN-13
            if (isbn.Length == 13)
            {
                int sum = 0;
                for (int i = 0; i < 12; i++)
                {
                    sum += (i % 2 == 0 ? 1 : 3) * int.Parse(isbn[i].ToString());
                }
                int checkDigit = (10 - sum % 10) % 10;
                if (checkDigit != int.Parse(isbn[12].ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        public static async Task<bool> IsCopyAvailable(string bookId)
        {
            bool isValid = false;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                try
                {
                    int count = 0;
                    if (error != null) return;
                    
                    string query = $"SELECT COUNT(*) FROM copies WHERE book_id = '{bookId}' AND status_id = 1;";
                    SqlCommand command = new SqlCommand(query, conn);

                    object? v = await command.ExecuteScalarAsync();
                    if (v != null) count = (int)v;

                    isValid = count > 0;
                }
                catch { return; }
            });

            return isValid;
        }
    }
}
