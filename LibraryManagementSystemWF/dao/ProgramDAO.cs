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
        public async Task<ReturnResult<models.Program>> Create(models.Program model)
        {
            ReturnResult<models.Program> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "INSERT INTO programs (program_name, program_description) " +
                $"VALUES ('{model.Name}', '{model.Description}'); " +
                "SELECT * FROM programs WHERE program_id = SCOPE_IDENTITY();";

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
                        returnResult.IsSuccess = returnResult.Result != default(models.Program);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
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

        public async Task<ReturnResultArr<models.Program>> GetAll(int page)
        {
            ReturnResultArr<models.Program> returnResult = new()
            {
                Results = new List<models.Program>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT COUNT(*) as row_count FROM programs; " +
                "SELECT * FROM programs " +
                $"ORDER BY (SELECT NULL) OFFSET ({page} - 1) * 10 ROWS FETCH NEXT 10 ROWS ONLY;";

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

        public async Task<ReturnResult<models.Program>> GetById(string id)
        {
            ReturnResult<models.Program> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = $"SELECT * FROM programs WHERE program_id = {id};";

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
                        returnResult.IsSuccess = returnResult.Result != default(models.Program);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Task<ReturnResultArr<models.Program>> GetSearchResults(string searchText, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(string id)
        {
            bool isRemoved = false;

            // remove program
            string query = $"UPDATE members SET program_id = NULL WHERE program_id = ${id};" +
                $"DELETE FROM programs WHERE program_id = ${id};";


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

        public async Task<ReturnResult<models.Program>> Update(models.Program model)
        {
            ReturnResult<models.Program> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "UPDATE programs SET " +
                $"program_name = '{model.Name}', " +
                $"program_description = '{model.Description}' WHERE program_id = {model.ID}; " +
                $"SELECT * FROM programs WHERE program_id = {model.ID};";

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
                        returnResult.IsSuccess = returnResult.Result != default(models.Program);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }
    }
}
