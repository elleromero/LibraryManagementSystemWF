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
    internal class ProgramDAO : IDAO<models.Program>
    {
        public Task<ReturnResult<models.Program>> Create(models.Program model)
        {
            throw new NotImplementedException();
        }

        public models.Program? Fill(SqlDataReader reader)
        {
            models.Program? program = new models.Program
            {
                ID = reader.GetInt32(reader.GetOrdinal("program_id")),
                Name = reader.GetString(reader.GetOrdinal("program_name")),
                Description = reader.GetString(reader.GetOrdinal("program_description"))
            };

            return program;
        }

        public async Task<ReturnResultArr<models.Program>> GetAll()
        {
            ReturnResultArr<models.Program> returnResult = new()
            {
                Results = new List<models.Program>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT COUNT(*) as row_count FROM programs; " +
                "SELECT * FROM programs;";

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
                        models.Program? program = this.Fill(reader);

                        if (program != null) returnResult.Results.Add(program);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Task<ReturnResultArr<models.Program>> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<models.Program>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResultArr<models.Program>> GetSearchResults(string searchText, int page)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<models.Program>> Update(models.Program model)
        {
            throw new NotImplementedException();
        }
    }
}
