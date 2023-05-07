using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.dao
{
    internal class BookDAO : IDAO<Book>
    {
        public async Task<ReturnResult<Book>> Create(Book model)
        {
            ReturnResult<Book> returnResult = new()
            {
                Result = null,
                IsSuccess = false
            };

            string declareQuery = "DECLARE @book_id UNIQUEIDENTIFIER; SET @book_id = NEWID();";
            string insertQuery = "INSERT INTO books (book_id, genre_id, title, sypnosis, cover, author, publication_date, publisher, isbn) " +
                $"VALUES (@book_id, {model.Genre.ID}, '{model.Title}', '{model.Sypnosis}', '{model.Cover}', '{model.Author}', '{model.PublicationDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{model.Publisher}', '{model.ISBN}');";
            string copyQuery = "INSERT INTO copies (book_id, status_id) VALUES (@book_id, 1);";
            string selectQuery = "SELECT * FROM books b JOIN genres g ON g.genre_id = b.genre_id WHERE book_id = @book_id;";
            string query = $"{declareQuery} {insertQuery} {copyQuery} {selectQuery}";

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
                        returnResult.IsSuccess = returnResult.Result != null;
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Book? Fill(SqlDataReader reader)
        {
            Genre genre = new();

            if (!reader.IsDBNull(reader.GetOrdinal("genre_id")))
            {
                genre.ID = reader.GetInt32(reader.GetOrdinal("genre_id"));
                genre.Name = reader.GetString(reader.GetOrdinal("name"));
                genre.Description = reader.GetString(reader.GetOrdinal("description"));
            }

            Book? book = new()
            {
                ID = reader.GetGuid(reader.GetOrdinal("book_id")),
                Title = reader.GetString(reader.GetOrdinal("title")),
                Sypnosis = reader.GetString(reader.GetOrdinal("sypnosis")),
                Author = reader.GetString(reader.GetOrdinal("author")),
                Cover = reader.GetString(reader.GetOrdinal("cover")),
                Publisher = reader.GetString(reader.GetOrdinal("publisher")),
                PublicationDate = reader.GetDateTime(reader.GetOrdinal("publication_date")),
                ISBN = reader.GetString(reader.GetOrdinal("isbn")),
                Genre = genre
            };

            return book;
        }

        public async Task<ReturnResultArr<Book>> GetAll(int page)
        {
            ReturnResultArr<Book> returnResult = new()
            {
                Results = new List<Book>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT COUNT(*) as row_count FROM books; " +
                "SELECT * FROM books b " +
                "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
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
                    while (await reader.ReadAsync())
                    {
                        Book? book = Fill(reader);

                        if (book != null) returnResult.Results.Add(book);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<ReturnResult<Book>> GetById(string id)
        {
            ReturnResult<Book> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                string query = $"SELECT * FROM books b JOIN genres g ON g.genre_id = b.genre_id WHERE b.book_id = '{id}';";

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        returnResult.Result = Fill(reader);
                        returnResult.IsSuccess = returnResult.Result != default(Book);
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

            // remove book
            string query = $"DELETE FROM copies WHERE book_id = '{id}'; " +
                           $"DELETE FROM books WHERE book_id = '{id}'; ";

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

        public async Task<ReturnResult<Book>> Update(Book model)
        {
            ReturnResult<Book> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "UPDATE books SET " +
                           $"genre_id = {model.Genre.ID}, " +
                           $"title = '{model.Title}', " +
                           $"sypnosis = '{model.Sypnosis}', " +
                           $"cover = '{model.Cover}', " +
                           $"author = '{model.Author}', " +
                           $"publication_date = '{model.PublicationDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}', " +
                           $"publisher = '{model.Publisher}', " +
                           $"isbn = '{model.ISBN}' WHERE book_id = '{model.ID}'; " +
                           $"SELECT * FROM books b JOIN genres g ON g.genre_id = b.genre_id WHERE b.book_id = '{model.ID}';";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    if (reader.Read())
                    {
                        returnResult.Result = this.Fill(reader);
                        returnResult.IsSuccess = returnResult.Result != default(Book);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

    }
}
