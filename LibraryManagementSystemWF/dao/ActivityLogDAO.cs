using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.dao
{
    internal class ActivityLogDAO : IDAO<ActivityLog>
    {
        public async Task<ReturnResult<ActivityLog>> Create(ActivityLog model)
        {
            ReturnResult<ActivityLog> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "INSERT INTO activities (activity_log, activity_type_id) VALUES (@MESSAGE, @TYPE_ID); " +
                "SELECT * FROM activities a JOIN activity_type at ON a.activity_type_id = at.activity_type_id;";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {

                    SqlCommand command = new(query, conn);
                    command.Parameters.Add("@MESSAGE", System.Data.SqlDbType.NVarChar).Value = model.Log;
                    command.Parameters.Add("@TYPE_ID", System.Data.SqlDbType.Int).Value = model.Type.ID;

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
                }
            };

            return activityLog;
        }

        public async Task<ReturnResultArr<ActivityLog>> GetAll(int page)
        {
            ReturnResultArr<ActivityLog> returnResult = new()
            {
                Results = new List<ActivityLog>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = $"SELECT * FROM activities a JOIN activity_type at ON a.activity_type_id = at.activity_type_id\r\nORDER BY timestamp DESC, (SELECT NULL) OFFSET ({page} - 1) * 20 ROWS FETCH NEXT 20 ROWS ONLY;";

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
