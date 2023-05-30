using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.dao
{
    internal class AnnouncementDAO : IDAO<Announcement>
    {
        public async Task<ReturnResult<Announcement>> Create(Announcement model, List<RoleEnum> publishToRoles)
        {
            ReturnResult<Announcement> returnResult = new()
            {
                Result = null,
                IsSuccess = false
            };

            // announcement role query
            string insertValues = "";

            foreach (RoleEnum role in publishToRoles)
            {
                insertValues += $"(@announcement_id, {(int) role}), ";
            }

            insertValues = insertValues.Substring(0, insertValues.LastIndexOf(", ")).Trim();

            string declareQuery = "DECLARE @announcement_id UNIQUEIDENTIFIER; SET @announcement_id = NEWID();";
            string insertQuery = "INSERT INTO announcements (" +
                "announcement_id, " +
                "user_id, " +
                "announcement_header, " +
                "announcement_body, " +
                "announcement_due, " +
                "announcement_timestamp, " +
                "announcement_cover, " +
                "is_priority" +
                ") VALUES (" +
                $"@announcement_id, '{model.User.ID}', '{model.Header}', '{model.Body}', '{model.Due.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}', " +
                $"'{model.Cover}', {Convert.ToInt32(model.IsPriority)});";
            string insertAncmtRolesQuery = "INSERT INTO announcement_roles (announcement_id, role_id) " +
                $"VALUES {insertValues};";
            string selectQuery = "SELECT * FROM announcements a " +
                "JOIN users u ON a.user_id = u.user_id " +
                "JOIN members m ON u.member_id = m.member_id " +
                "JOIN roles r ON r.role_id = u.role_id WHERE a.announcement_id = @announcement_id;";
            string query = $"{declareQuery} {insertQuery} {insertAncmtRolesQuery} {selectQuery}";
            MessageBox.Show(query);

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

        public Task<ReturnResult<Announcement>> Create(Announcement model)
        {
            throw new NotImplementedException();
        }

        public Announcement? Fill(SqlDataReader reader)
        {
            // User
            User user = new()
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
                    Phone = reader.GetString(reader.GetOrdinal("phone")),
                    Email = reader.GetString(reader.GetOrdinal("email")),
                    Address = reader.GetString(reader.GetOrdinal("address")),
                }
            };

            // Annoucement
            Announcement? annoucement = new()
            {
                ID = reader.GetGuid(reader.GetOrdinal("announcement_id")),
                Header = reader.GetString(reader.GetOrdinal("announcement_header")),
                Body = reader.GetString(reader.GetOrdinal("announcement_body")),
                Due = reader.GetDateTime(reader.GetOrdinal("announcement_due")),
                Timestamp = reader.GetDateTime(reader.GetOrdinal("announcement_timestamp")),
                IsPriority = reader.GetBoolean(reader.GetOrdinal("is_priority")),
                Cover = reader.GetString(reader.GetOrdinal("announcement_cover")),
                User = user
            };

            return annoucement;
        }

        public async Task<ReturnResultArr<Announcement>> GetAll(int page)
        {
            ReturnResultArr<Announcement> returnResult = new()
            {
                Results = new List<Announcement>(),
                IsSuccess = false,
                rowCount = 0
            };

            // get authenticated role
            User? user = AuthService.getSignedUser();

            if (user == null) return returnResult;

            string query = $"SELECT COUNT(*) as row_count FROM announcement_roles WHERE role_id = {user.Role.ID}; " +
                "SELECT * FROM announcement_roles ar " +
                "JOIN announcements a ON a.announcement_id = ar.announcement_id " +
                "JOIN users u ON u.user_id = a.user_id " +
                "JOIN members m ON m.member_id = u.member_id " +
                "JOIN roles r ON r.role_id = u.role_id " +
                $"WHERE a.announcement_due > '{DateTime.Now.ToString("yyyy-MM-dd")}' " +
                $"AND ar.role_id = {user.Role.ID} " +
                $"ORDER BY is_priority DESC, (SELECT NULL) OFFSET ({page} - 1) * 20 ROWS FETCH NEXT 20 ROWS ONLY;";

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
                            Announcement? announcement = Fill(reader);

                            if (announcement != null) returnResult.Results.Add(announcement);
                        }
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<ReturnResultArr<Announcement>> GetAllAndIncludePastDue(int page)
        {
            ReturnResultArr<Announcement> returnResult = new()
            {
                Results = new List<Announcement>(),
                IsSuccess = false,
                rowCount = 0
            };

            string query = "SELECT COUNT(*) as row_count FROM announcements; " +
                "SELECT * FROM announcements a " +
                "JOIN users u ON u.user_id = a.user_id " +
                "JOIN members m ON m.member_id = u.member_id " +
                "JOIN roles r ON r.role_id = u.role_id " +
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
                            Announcement? announcement = Fill(reader);

                            if (announcement != null) returnResult.Results.Add(announcement);
                        }
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Task<ReturnResult<Announcement>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(string id)
        {
            bool isRemoved = false;

            // remove genre
            string query = $"DELETE FROM announcements WHERE announcement_id = ${id};";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                try
                {
                    SqlCommand command = new(query, conn);
                    await command.ExecuteNonQueryAsync();

                    isRemoved = true;
                }
                catch { return; }
            });

            return isRemoved;
        }

        public async Task<ReturnResult<Announcement>> Update(Announcement model)
        {
            ReturnResult<Announcement> returnResult = new()
            {
                Result = null,
                IsSuccess = false
            };

            string updateQuery = "UPDATE announcements SET " +
                $"announcement_header = '{model.Header}', " +
                $"announcement_body = '{model.Body}', " +
                $"announcement_due = '{model.Due.ToString("yyyy - MM - dd HH: mm: ss.fff")}', " +
                $"is_priority = {Convert.ToInt32(model.IsPriority)}, " +
                $"announcement_cover = '{model.Cover}' " +
                $"WHERE announcement_id = '{model.ID}';";
            string selectQuery = "SELECT * FROM announcements a " +
                "JOIN users u ON a.user_id = u.user_id " +
                "JOIN members m ON u.member_id = m.member_id " +
                $"JOIN roles r ON r.role_id = u.role_id WHERE a.announcement_id = '{model.ID}';";
            string query = $"{updateQuery} {selectQuery}";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    if (reader.Read())
                    {
                        returnResult.Result = Fill(reader);
                        returnResult.IsSuccess = returnResult.Result != default(Announcement);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;

        }
    }
}
