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
    internal class GenreDAO : IDAO<Genre>
    {
        public async Task<ReturnResult<Genre>> Create(Genre model)
        {
            ReturnResult<Genre> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "INSERT INTO genres (name, description) " +
                $"VALUES ('{model.Name}', '{model.Description}'); " +
                "SELECT * FROM genres WHERE genre_id = SCOPE_IDENTITY();";

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
                        returnResult.IsSuccess = returnResult.Result != default(Genre);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Genre? Fill(SqlDataReader reader)
        {
            Genre? genre = new()
            {
                ID = reader.GetInt32(reader.GetOrdinal("genre_id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Description = reader.GetString(reader.GetOrdinal("description"))
            };
            return genre;
        }

        public async Task<ReturnResultArr<Genre>> GetAll(int page)
        {
            ReturnResultArr<Genre> returnResult = new()
            {
                Results = new List<Genre>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT COUNT(*) as row_count FROM genres; " +
                "SELECT * FROM genres " +
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
                        Genre? genre = this.Fill(reader);

                        if (genre != null) returnResult.Results.Add(genre);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<ReturnResultArr<Genre>> GetAll()
        {
            ReturnResultArr<Genre> returnResult = new()
            {
                Results = new List<Genre>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT COUNT(*) as row_count FROM genres; " +
                "SELECT * FROM genres;";

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
                        Genre? genre = this.Fill(reader);

                        if (genre != null) returnResult.Results.Add(genre);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<ReturnResult<Genre>> GetById(string id)
        {
            ReturnResult<Genre> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = $"SELECT * FROM genres WHERE genre_id = {id};";

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
                        returnResult.IsSuccess = returnResult.Result != default(Genre);
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

            // remove genre
            string query = $"DELETE FROM genres WHERE genre_id = ${id}; " +
                $"UPDATE books SET genre_id = NULL WHERE genre_id = ${id};";

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

        public async Task<ReturnResult<Genre>> Update(Genre model)
        {
            ReturnResult<Genre> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "UPDATE genres SET " +
                $"name = '{model.Name}', " +
                $"description = '{model.Description}' WHERE genre_id = {model.ID}; " +
                $"SELECT * FROM genres WHERE genre_id = {model.ID};";

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
                        returnResult.IsSuccess = returnResult.Result != default(Genre);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Task<ReturnResultArr<Genre>> GetSearchResults(string searchText, int page)
        {
            throw new NotImplementedException();
        }
    }
}
