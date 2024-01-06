using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.dao
{
    internal class ActivityLogDAO : IDAO<ActivityLog>
    {
        private Dictionary<RoleEnum, string> roleRange = new();

        public ActivityLogDAO() {
            roleRange.Add(RoleEnum.LIBRARIAN, $"{(int)ActivityTypeEnum.BOOK_TRANSACT}, {(int)ActivityTypeEnum.BOOK_OPERATION}, {(int)ActivityTypeEnum.COPY_OPERATION}");
        }

        public async Task<ReturnResult<ActivityLog>> Create(ActivityLog model)
        {
            ReturnResult<ActivityLog> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "INSERT INTO activities (activity_log, activity_type_id, user_id) " +
                "VALUES (@MESSAGE, @TYPE_ID, @USER_ID); " +
                "SELECT * FROM activities a " +
                "JOIN activity_type at ON a.activity_type_id = at.activity_type_id " +
                "JOIN users u ON a.user_id = u.user_id " +
                "JOIN roles r ON r.role_id = u.role_id " +
                "JOIN members m ON m.member_id = u.member_id " +
                "JOIN programs p ON p.program_id = m.program_id;";
                
            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {

                    SqlCommand command = new(query, conn);
                    command.Parameters.Add("@MESSAGE", System.Data.SqlDbType.NVarChar).Value = model.Log;
                    command.Parameters.Add("@TYPE_ID", System.Data.SqlDbType.Int).Value = model.Type.ID;
                    command.Parameters.Add("@USER_ID", System.Data.SqlDbType.UniqueIdentifier).Value = model.User.ID;

                    reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        returnResult.Result = Fill(reader);
                        returnResult.IsSuccess = returnResult.Result != default(ActivityLog);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public ActivityLog? Fill(SqlDataReader reader)
        {
            ActivityLog? activityLog = new()
            {
                ID = reader.GetGuid(reader.GetOrdinal("activity_id")),
                Log = reader.GetString(reader.GetOrdinal("activity_log")),
                Timestamp = reader.GetDateTime(reader.GetOrdinal("timestamp")),
                Type = new ActivityType()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("activity_type_id")),
                    Name = reader.GetString(reader.GetOrdinal("activity_name")),
                    Description = reader.GetString(reader.GetOrdinal("activity_description")),
                },
                User = new()
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
                }
        };

            return activityLog;
        }

        public async Task<ReturnResultArr<ActivityLog>> GetAll(int page, string searchText = "", ActivityTypeEnum? ate = null)
        {
            ReturnResultArr<ActivityLog> returnResult = new()
            {
                Results = new List<ActivityLog>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = $"SELECT COUNT(*) as row_count FROM activities WHERE activity_log LIKE '%{searchText}%'; " +
                "SELECT * FROM activities a " +
                "JOIN activity_type at ON a.activity_type_id = at.activity_type_id " +
                "JOIN users u ON a.user_id = u.user_id " +
                "JOIN members m ON u.member_id = m.member_id " +
                "INNER JOIN programs p ON m.program_id = p.program_id " +
                "JOIN roles r ON u.role_id = r.role_id " +
                $"WHERE a.activity_log LIKE '%{searchText}%' " +
                $"{(ate != null ? $"AND a.activity_type_id = {(int)ate} " : string.Empty)}" +
                "ORDER BY timestamp DESC, " +
                $"(SELECT NULL) OFFSET ({page} - 1) * 20 ROWS FETCH NEXT 20 ROWS ONLY;";

            Console.WriteLine(query);

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    // add row count
                    if (await reader.ReadAsync())
                    {
                        returnResult.rowCount = reader.GetInt32(reader.GetOrdinal("row_count"));
                    }

                    // fill data
                    await reader.NextResultAsync();
                    while (reader.Read())
                    {
                        ActivityLog? activityLog = Fill(reader);

                        if (activityLog != null) returnResult.Results.Add(activityLog);
                    }

                    returnResult.IsSuccess = true;
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Task<ReturnResultArr<ActivityLog>> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnResultArr<ActivityLog>> GetAllByRole(RoleEnum role, int page)
        {
            ReturnResultArr<ActivityLog> returnResult = new()
            {
                Results = new List<ActivityLog>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT COUNT(*) as row_count FROM activities; " +
                "SELECT * FROM activities a " +
                "JOIN activity_type at ON a.activity_type_id = at.activity_type_id " +
                "JOIN users u ON a.user_id = u.user_id " +
                "JOIN members m ON u.member_id = m.member_id " +
                "INNER JOIN programs p ON m.program_id = p.program_id " +
                "JOIN roles r ON u.role_id = r.role_id " +
                $"WHERE r.role_id = {(int)role}" +
                "ORDER BY timestamp DESC, " +
                $"(SELECT NULL) OFFSET ({page} - 1) * 20 ROWS FETCH NEXT 20 ROWS ONLY;";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    // add row count
                    if (await reader.ReadAsync())
                    {
                        returnResult.rowCount = reader.GetInt32(reader.GetOrdinal("row_count"));
                    }

                    // fill data
                    await reader.NextResultAsync();
                    while (reader.Read())
                    {
                        ActivityLog? activityLog = Fill(reader);

                        if (activityLog != null) returnResult.Results.Add(activityLog);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<ReturnResultArr<ActivityLog>> GetAllWithPermission(RoleEnum role, int page)
        {
            ReturnResultArr<ActivityLog> returnResult = new()
            {
                Results = new List<ActivityLog>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT COUNT(*) as row_count FROM activities; " +
                "SELECT * FROM activities a " +
                "JOIN activity_type at ON a.activity_type_id = at.activity_type_id " +
                "JOIN users u ON a.user_id = u.user_id " +
                "JOIN members m ON u.member_id = m.member_id " +
                "INNER JOIN programs p ON m.program_id = p.program_id " +
                "JOIN roles r ON u.role_id = r.role_id " +
                $"WHERE a.activity_type_id IN ({roleRange[role]})" +
                "ORDER BY a.timestamp DESC, " +
                $"(SELECT NULL) OFFSET ({page} - 1) * 20 ROWS FETCH NEXT 20 ROWS ONLY;";
            Console.WriteLine(query);
            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    // add row count
                    if (await reader.ReadAsync())
                    {
                        returnResult.rowCount = reader.GetInt32(reader.GetOrdinal("row_count"));
                    }

                    // fill data
                    await reader.NextResultAsync();
                    while (reader.Read())
                    {
                        ActivityLog? activityLog = Fill(reader);

                        if (activityLog != null) returnResult.Results.Add(activityLog);
                    }

                    returnResult.IsSuccess = true;
                }
                catch (Exception e) { MessageBox.Show(e.ToString());  return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Task<ReturnResult<ActivityLog>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResultArr<ActivityLog>> GetSearchResults(string searchText, int page)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<ActivityLog>> Update(ActivityLog model)
        {
            throw new NotImplementedException();
        }
    }
}
