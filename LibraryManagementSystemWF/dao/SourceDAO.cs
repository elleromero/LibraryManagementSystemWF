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
    internal class SourceDAO : IDAO<Source>
    {
        public Task<ReturnResult<Source>> Create(Source model)
        {
            throw new NotImplementedException();
        }

        public Source? Fill(SqlDataReader reader)
        {
            Source? source = new Source
            {
                ID = reader.GetInt32(reader.GetOrdinal("source_id")),
                Name = reader.GetString(reader.GetOrdinal("source_name"))
            };

            return source;
        }

        public async Task<ReturnResultArr<Source>> GetAll()
        {
            ReturnResultArr<Source> returnResult = new()
            {
                Results = new List<Source>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT COUNT(*) as row_count FROM genres; " +
                "SELECT * FROM sources;";

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
                        Source? source = this.Fill(reader);

                        if (source != null) returnResult.Results.Add(source);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Task<ReturnResultArr<Source>> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<Source>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResultArr<Source>> GetSearchResults(string searchText, int page)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<Source>> Update(Source model)
        {
            throw new NotImplementedException();
        }
    }
}
