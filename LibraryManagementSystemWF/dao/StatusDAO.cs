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
    internal class StatusDAO : IDAO<Status>
    {
        public Task<ReturnResult<Status>> Create(Status model)
        {
            throw new NotImplementedException();
        }

        public Status? Fill(SqlDataReader reader)
        {
            Status? status = new()
            {
                ID = reader.GetInt32(reader.GetOrdinal("status_id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Description = reader.GetString(reader.GetOrdinal("description")),
                IsAvailable = reader.GetBoolean(reader.GetOrdinal("is_available"))
            };
            return status;
        }

        public async Task<ReturnResultArr<Status>> GetAll(int page = 1)
        {
            ReturnResultArr<Status> returnResult = new()
            {
                Results = new List<Status>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT * FROM statuses;";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    // fill data
                    while (await reader.ReadAsync())
                    {
                        Status? status = Fill(reader);

                        if (status != null) returnResult.Results.Add(status);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }


        public Task<ReturnResult<Status>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<Status>> Update(Status model)
        {
            throw new NotImplementedException();
        }
    }
}
