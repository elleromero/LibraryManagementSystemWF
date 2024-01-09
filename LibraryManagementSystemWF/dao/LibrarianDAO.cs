using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.dao
{
    internal class LibrarianDAO : IDAO<User>
    {

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
                $"WHERE r.name = '{RoleEnum.USER}' " +
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

        public Task<ReturnResult<User>> Create(User model)
        {
            throw new NotImplementedException();
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

        public Task<ReturnResult<User>> GetById(string id)
        {
            throw new NotImplementedException();
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
                "LEFT JOIN programs p ON p.program_id = m.program_id " +
                $"WHERE username LIKE '%{searchText}%' " +
                $"AND r.name = '{RoleEnum.USER}' " +
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

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<User>> Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
