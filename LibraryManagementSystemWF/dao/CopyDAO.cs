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
    internal class CopyDAO : IDAO<Copy>
    {
        public async Task<ReturnResult<Copy>> CreateMany(string bookId, int copies, SourceEnum source, decimal price = 0)
        {
            ReturnResult<Copy> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string declareQuery = "DECLARE @counter int SET @counter = 1; " +
                "DECLARE @copy_id UNIQUEIDENTIFIER;";
            string loopQuery = $"WHILE (@counter <= {copies}) " +
                "BEGIN " +
                "SET @copy_id = NEWID(); " +
                $"INSERT INTO copies (copy_id, book_id, price, source_id, status_id) VALUES (@copy_id, '{bookId}', {price}, {(int)source}, 1); " +
                "SET @counter = @counter + 1; " +
                "END;";
            string selectQuery = "SELECT *, s.name AS status_name, s.description AS status_description, s.is_available AS status_is_available, " +
                "g.name AS genre_name, g.description AS genre_description, " +
                "(SELECT COUNT(*) FROM copies co WHERE book_id = b.book_id AND co.status_id = 1) AS available_copies FROM copies c " +
                "JOIN books b ON b.book_id = c.book_id " +
                "JOIN book_metadata bmd ON bmd.metadata_id = b.metadata_id " +
                "LEFT JOIN genres g ON g.genre_id = bmd.genre_id " +
                "JOIN statuses s ON s.status_id = c.status_id " +
                "WHERE copy_id = @copy_id;";
            string query = $"{declareQuery} {loopQuery} {selectQuery}";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        returnResult.Result = Fill(reader);
                        returnResult.IsSuccess = returnResult.Result != default(Copy);
                    }

                    reader.Close();
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Task<ReturnResult<Copy>> Create(Copy model)
        {
            throw new NotImplementedException();
        }

        public Copy? Fill(SqlDataReader reader)
        {
            Genre genre = new();

            if (!reader.IsDBNull(reader.GetOrdinal("genre_id")))
            {
                genre.ID = reader.GetInt32(reader.GetOrdinal("genre_id"));
                genre.Name = reader.GetString(reader.GetOrdinal("genre_name"));
                genre.Description = reader.GetString(reader.GetOrdinal("genre_description"));
            }

            Book? book = new Book
            {
                ID = reader.GetGuid(reader.GetOrdinal("book_id")),
                AvailableCopies = reader.GetInt32(reader.GetOrdinal("available_copies")),
                BookMetadata = new BookMetadata
                {
                    Title = reader.GetString(reader.GetOrdinal("title")),
                    Sypnosis = reader.GetString(reader.GetOrdinal("sypnosis")),
                    Author = reader.GetString(reader.GetOrdinal("author")),
                    Cover = reader.GetString(reader.GetOrdinal("cover")),
                    Publisher = reader.GetString(reader.GetOrdinal("publisher")),
                    PublicationDate = reader.GetDateTime(reader.GetOrdinal("publication_date")),
                    ISBN = reader.GetString(reader.GetOrdinal("isbn")),
                    AddedOn = reader.GetDateTime(reader.GetOrdinal("added_on")),
                    Genre = genre,
                    Copyright = reader.GetString(reader.GetOrdinal("copyright")),
                    EditionStr = reader.GetString(reader.GetOrdinal("edition_str")),
                    EditionNumber = reader.GetInt32(reader.GetOrdinal("edition_num"))
                }
            };

            Status? status = new Status
            {
                ID = reader.GetInt32(reader.GetOrdinal("status_id")),
                Name = reader.GetString(reader.GetOrdinal("status_name")),
                Description = reader.GetString(reader.GetOrdinal("status_description")),
                IsAvailable = reader.GetBoolean(reader.GetOrdinal("status_is_available"))
            };
            Copy? copy = new Copy
            {
                ID = reader.GetGuid(reader.GetOrdinal("copy_id")),
                Book = book,
                Status = status
            };

            return copy;
        }

        public async Task<ReturnResultArr<Copy>> GetAll(int page)
        {
            ReturnResultArr<Copy> returnResult = new()
            {
                Results = new List<Copy>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT COUNT(*) as row_count FROM copies; " +
                           "SELECT *, s.name AS status_name, s.description AS status_description, s.is_available AS status_is_available, " +
                           "g.name AS genre_name, g.description AS genre_description, " +
                           "(SELECT COUNT(*) FROM copies co WHERE book_id = b.book_id AND co.status_id = 1) AS available_copies FROM copies c " +
                           "JOIN books b ON b.book_id = c.book_id " +
                           "JOIN book_metadata bmd ON bmd.metadata_id = b.metadata_id " +
                           "LEFT JOIN genres g ON g.genre_id = bmd.genre_id " +
                           "JOIN statuses s ON s.status_id = c.status_id " +
                           $"ORDER BY (SELECT NULL) OFFSET ({page} - 1) * 10 ROWS FETCH NEXT 10 ROWS ONLY;";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    // Add row count
                    if (await reader.ReadAsync())
                    {
                        returnResult.rowCount = reader.GetInt32(reader.GetOrdinal("row_count"));
                    }

                    // Fill data
                    await reader.NextResultAsync();
                    while (await reader.ReadAsync())
                    {
                        Copy? copy = Fill(reader);

                        if (copy != null) returnResult.Results.Add(copy);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<ReturnResultArr<Copy>> GetAllWithBooks(string bookId, int page)
        {
            ReturnResultArr<Copy> returnResult = new()
            {
                Results = new List<Copy>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = $"SELECT COUNT(*) as row_count FROM copies WHERE book_id = '{bookId}'; " +
                           "SELECT *, s.name AS status_name, s.description AS status_description, s.is_available AS status_is_available, " +
                           "g.name AS genre_name, g.description AS genre_description," +
                           "(SELECT COUNT(*) FROM copies co WHERE book_id = b.book_id AND co.status_id = 1) AS available_copies FROM copies c " +
                           "JOIN books b ON b.book_id = c.book_id " +
                           "JOIN book_metadata bmd ON bmd.metadata_id = b.metadata_id " +
                           "LEFT JOIN genres g ON g.genre_id = bmd.genre_id " +
                           "JOIN statuses s ON s.status_id = c.status_id " +
                           $"WHERE c.book_id = '{bookId}'" +
                           $"ORDER BY (SELECT NULL) OFFSET ({page} - 1) * 10 ROWS FETCH NEXT 10 ROWS ONLY;";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    // Add row count
                    if (await reader.ReadAsync())
                    {
                        returnResult.rowCount = reader.GetInt32(reader.GetOrdinal("row_count"));
                    }

                    // Fill data
                    await reader.NextResultAsync();
                    while (await reader.ReadAsync())
                    {
                        Copy? copy = Fill(reader);

                        if (copy != null) returnResult.Results.Add(copy);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<ReturnResult<Copy>> GetById(string id)
        {
            ReturnResult<Copy> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "SELECT *, s.name AS status_name, s.description AS status_description, s.is_available AS status_is_available, " +
               "g.name AS genre_name, g.description AS genre_description," +
               "(SELECT COUNT(*) FROM copies co WHERE book_id = b.book_id AND co.status_id = 1) AS available_copies FROM copies c " +
               "JOIN books b ON b.book_id = c.book_id " +
               "JOIN book_metadata bmd ON bmd.metadata_id = b.metadata_id " +
               "LEFT JOIN genres g ON g.genre_id = bmd.genre_id " +
               "JOIN statuses s ON s.status_id = c.status_id " +
               $"WHERE copy_id = '{id}';";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        returnResult.Result = Fill(reader);
                        returnResult.IsSuccess = returnResult.Result != default(Copy);
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

            // remove copy
            string query = $"DELETE FROM copies WHERE copy_id = '{id}';";

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

        public Task<ReturnResult<Copy>> Update(Copy model)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResultArr<Copy>> GetSearchResults(string searchText, int page)
        {
            throw new NotImplementedException();
        }
    }
}
