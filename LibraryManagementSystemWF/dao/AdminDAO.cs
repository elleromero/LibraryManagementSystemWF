using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.dao
{
    internal class AdminDAO : IDAO<User>
    {
        public async Task<ReturnResult<User>> Create(User model)
        {
            ReturnResult<User> returnResult = new()
            {
                Result = null,
                IsSuccess = false
            };

            string declareQuery = "DECLARE @member_id UNIQUEIDENTIFIER = NEWID();";
            string memberQuery = 
                $"INSERT INTO members " +
                $"(first_name, last_name, course_year, school_no, " +
                $"address, phone, email, member_id, program_id) " +
                $"VALUES ('{model.Member.FirstName}', '{model.Member.LastName}', {(model.Member.CourseYear == null ? "NULL" : model.Member.CourseYear)}, '{22413}', " +
                $"'{model.Member.Address}', '{model.Member.Phone}', '{model.Member.Email}', @member_id, {(model.Member.Program.ID == null ? "NULL" : $"'{model.Member.Program.ID}'")});";
            string userQuery = $"INSERT INTO users (member_id, role_id, username, password_hash, profile_picture) " +
                $"VALUES (@member_id, {model.Role.ID}, '{model.Username}', '{model.PasswordHash}', '{model.ProfilePicture}');";
            string selectQuery = "SELECT * FROM members m JOIN users u ON m.member_id = u.member_id JOIN roles r ON r.role_id = u.role_id LEFT JOIN programs p ON p.program_id = m.program_id WHERE u.member_id = @member_id;";
            string query = $"{declareQuery} {memberQuery} {userQuery} {selectQuery}";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        returnResult.Result = Fill(reader);
                    }

                    returnResult.IsSuccess = returnResult.Result != null;
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<ReturnResultArr<User>> GetAll(int page = 1)
        {
            ReturnResultArr<User> returnResult = new()
            {
                Results = new List<User>(),
                IsSuccess = false,
                rowCount = 0
            };

            string query = "SELECT COUNT(*) as row_count FROM users; " +
                "SELECT * FROM users u " +
                "JOIN members m ON m.member_id = u.member_id " +
                "JOIN roles r ON r.role_id = u.role_id " +
                "LEFT JOIN programs p ON p.program_id = m.program_id " +
                $"ORDER BY (SELECT NULL) OFFSET ({page} - 1) * 10 ROWS FETCH NEXT 10 ROWS ONLY;";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    // Add row count
                    if (await reader.ReadAsync())
                    {
                        returnResult.rowCount = reader.GetInt32(reader.GetOrdinal("row_count"));
                    }

                    // Fill data
                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            User? user = Fill(reader);

                            if (user != null) returnResult.Results.Add(user);
                        }
                    }

                    returnResult.IsSuccess = true;
                }
                catch (Exception e) { MessageBox.Show(e.ToString());  return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<ReturnResult<User>> GetById(string id)
        {
            ReturnResult<User> returnResult = new()
            {
                Result = null,
                IsSuccess = false
            };

            string query = "SELECT * FROM users u " +
                $"JOIN members m ON m.member_id = u.member_id JOIN roles r ON r.role_id = u.role_id LEFT JOIN programs p ON p.program_id = m.program_id WHERE u.user_id = '{id}';";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        returnResult.Result = Fill(reader);
                        returnResult.IsSuccess = returnResult.Result != null;
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<bool> Remove(string id)
        {
            bool isRemoved = false;

            // Remove user
            string declareQuery = "DECLARE @member_id UNIQUEIDENTIFIER;" +
                $"SELECT @member_id = member_id FROM users WHERE user_id = '{id}';";
            string userQuery = $"DELETE FROM users WHERE user_id = '{id}';";
            string memberQuery = "DELETE FROM members WHERE member_id = @member_id;";
            string query = $"{declareQuery} {userQuery} {memberQuery}";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    await command.ExecuteNonQueryAsync();

                    isRemoved = true;
                }
                catch { return; }
            });

            return isRemoved;
        }

        public async Task<ReturnResult<User>> Update(User model)
        {
            ReturnResult<User> returnResult = new()
            {
                Result = null,
                IsSuccess = false
            };

            string declareQuery = "DECLARE @user table (member_id UNIQUEIDENTIFIER);";
            string updateUserQuery = "UPDATE users SET " +
                $"username = '{model.Username}', " +
                $"password_hash = '{model.PasswordHash}', " +
                $"profile_picture = '{model.ProfilePicture}' " +
                "OUTPUT inserted.member_id INTO @user(member_id) " +
                $"WHERE user_id = '{model.ID}';";
            string updateMemberQuery = "UPDATE members SET " +
                $"first_name = '{model.Member.FirstName}', " +
                $"last_name = '{model.Member.LastName}', " +
                $"course_year = {(model.Member.CourseYear == null ? "NULL" : model.Member.CourseYear)}, " +
                $"school_no = '{244713781}', " +
                $"address = '{model.Member.Address}', " +
                $"email = '{model.Member.Email}', " +
                $"phone = '{model.Member.Phone}' " +
                "WHERE member_id = (SELECT member_id FROM @user as u WHERE u.member_id = members.member_id);";
            string selectQuery = $"SELECT * FROM users u JOIN members m ON m.member_id = u.member_id JOIN roles r ON r.role_id = u.role_id LEFT JOIN programs p ON p.program_id = m.program_id WHERE user_id = '{model.ID}';";
            string query = $"{declareQuery} {updateUserQuery} {updateMemberQuery} {selectQuery}";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        returnResult.Result = Fill(reader);
                    }

                    returnResult.IsSuccess = returnResult.Result != null;

                    // Update info of current logged-in user
                    if (returnResult.IsSuccess && AuthGuard.IsLoggedIn(model.ID.ToString()))
                    {
                        AuthService.setSignedUser(returnResult.Result);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public User Fill(SqlDataReader reader)
        {
            User? user = new()
            {
                ID = reader.GetGuid(reader.GetOrdinal("user_id")),
                Username = reader.GetString(reader.GetOrdinal("username")),
                ProfilePicture = reader.GetString(reader.GetOrdinal("profile_picture")),
                Role = new Role
                {
                    ID = reader.GetInt32(reader.GetOrdinal("role_id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    HasAccess = reader.GetBoolean(reader.GetOrdinal("has_access"))
                },
                Member = new Member
                {
                    ID = reader.GetGuid(reader.GetOrdinal("member_id")),
                    FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                    LastName = reader.GetString(reader.GetOrdinal("last_name")),
                    CourseYear = reader.IsDBNull(reader.GetOrdinal("course_year")) ? null : reader.GetInt32(reader.GetOrdinal("course_year")),
                    SchoolNumber = reader.GetString(reader.GetOrdinal("school_no")),
                    Phone = reader.GetString(reader.GetOrdinal("phone")),
                    Email = reader.GetString(reader.GetOrdinal("email")),
                    Address = reader.GetString(reader.GetOrdinal("address")),
                    Program = new models.Program
                    {
                        ID = reader.IsDBNull(reader.GetOrdinal("program_id")) ? null : reader.GetInt32(reader.GetOrdinal("program_id")),
                        Name = reader.IsDBNull(reader.GetOrdinal("program_name")) ? string.Empty : reader.GetString(reader.GetOrdinal("program_name")),
                        Description = reader.IsDBNull(reader.GetOrdinal("program_description")) ? string.Empty : reader.GetString(reader.GetOrdinal("program_description"))
                    }
                }
            };

            return user;
        }

        public async Task<ReturnResultArr<User>> GetSearchResults(string searchText, int page)
        {
            ReturnResultArr<User> returnResult = new()
            {
                Results = new List<User>(),
                IsSuccess = false,
                rowCount = 0
            };

            string query = $"SELECT COUNT(*) as row_count FROM users WHERE username LIKE '%{searchText}%'; " +
                "SELECT * FROM users u " +
                "JOIN members m ON m.member_id = u.member_id " +
                "JOIN roles r ON r.role_id = u.role_id " +
                "JOIN programs p ON p.program_id = m.program_id " +
                $"WHERE username LIKE '%{searchText}%' " +
                $"ORDER BY (SELECT NULL) OFFSET ({page} - 1) * 10 ROWS FETCH NEXT 10 ROWS ONLY;";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    // Add row count
                    if (await reader.ReadAsync())
                    {
                        returnResult.rowCount = reader.GetInt32(reader.GetOrdinal("row_count"));
                    }

                    // Fill data
                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            User? user = Fill(reader);

                            if (user != null) returnResult.Results.Add(user);
                        }
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }
    }
}
