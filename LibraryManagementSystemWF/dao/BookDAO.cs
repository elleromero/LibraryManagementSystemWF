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
        public async Task<ReturnResult<Book>> Create(Book model, decimal price, int sourceId)
        {
            ReturnResult<Book> returnResult = new()
            {
                Result = null,
                IsSuccess = false
            };

            BookMetadata bookMD = model.BookMetadata; 
            string copies = "";
            for (int i = 0; i < model.AvailableCopies; i++)
            {
                copies += $"(@book_id, 1, {price}, {sourceId}), ";
            }
            copies = copies.Trim();

            string declareQuery = "DECLARE @metadata_id UNIQUEIDENTIFIER; SET @metadata_id = NEWID();" +
                "DECLARE @book_id UNIQUEIDENTIFIER; SET @book_id = NEWID();";
            string insertQuery = "INSERT INTO book_metadata " +
                "(metadata_id, genre_id, " +
                "title, sypnosis, cover, author, " +
                "publication_date, publisher, " +
                "isbn, added_on, " +
                "copyright, edition_str, edition_num) " +
                $"VALUES (@metadata_id, {bookMD.Genre.ID}, '{bookMD.Title}', '{bookMD.Sypnosis}', '{bookMD.Cover}', '{bookMD.Author}', '{bookMD.PublicationDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{bookMD.Publisher}', '{bookMD.ISBN}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}', " +
                $"'{bookMD.Copyright}', '{bookMD.EditionStr}', {bookMD.EditionNumber});";
            string insertBook = "INSERT INTO books (book_id, metadata_id) VALUES (@book_id, @metadata_id);";
            string copyQuery = $"INSERT INTO copies (book_id, status_id, price, source_id) VALUES {copies.Substring(0, copies.Length - 1)};";
            string selectQuery = "SELECT *, (SELECT COUNT(*) FROM copies co WHERE book_id = @book_id AND co.status_id = 1) AS available_copies FROM books b JOIN book_metadata bmd ON bmd.metadata_id = b.metadata_id JOIN genres g ON g.genre_id = bmd.genre_id WHERE book_id = @book_id;";
            string query = $"{declareQuery} {insertQuery} {insertBook} {copyQuery} {selectQuery}";

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
                "SELECT *, (SELECT COUNT(*) FROM copies co WHERE book_id = b.book_id AND co.status_id = 1) AS available_copies FROM books b " +
                "LEFT JOIN book_metadata bmd ON bmd.metadata_id = b.metadata_id " +
                "LEFT JOIN genres g ON g.genre_id = bmd.genre_id " +
                $"ORDER BY added_on DESC, (SELECT NULL) OFFSET ({page} - 1) * 10 ROWS FETCH NEXT 10 ROWS ONLY;";

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

                string query = $"SELECT *, (SELECT COUNT(*) FROM copies co WHERE book_id = b.book_id AND co.status_id = 1) AS available_copies FROM books b JOIN book_metadata bmd ON bmd.metadata_id = b.metadata_id JOIN genres g ON g.genre_id = bmd.genre_id WHERE b.book_id = '{id}';";

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
            string query = $"DELETE FROM books WHERE book_id = '{id}';";

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

            string query = "UPDATE book_metadata SET " +
                           $"genre_id = {model.BookMetadata.Genre.ID}, " +
                           $"title = '{model.BookMetadata.Title}', " +
                           $"sypnosis = '{model.BookMetadata.Sypnosis}', " +
                           $"cover = '{model.BookMetadata.Cover}', " +
                           $"author = '{model.BookMetadata.Author}', " +
                           $"publication_date = '{model.BookMetadata.PublicationDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}', " +
                           $"publisher = '{model.BookMetadata.Publisher}', " +
                           $"isbn = '{model.BookMetadata.ISBN}', " +
                           $"copyright = '{model.BookMetadata.Copyright}', " +
                           $"edition_str = '{model.BookMetadata.EditionStr}', " +
                           $"edition_num = {model.BookMetadata.EditionNumber} " +
                           $"FROM book_metadata " +
                           $"JOIN books ON books.metadata_id = book_metadata.metadata_id " +
                           $"WHERE books.book_id = '{model.ID}'; " +
                           $"SELECT *, (SELECT COUNT(*) FROM copies co WHERE book_id = b.book_id AND co.status_id = 1) AS available_copies FROM books b JOIN book_metadata bmd ON bmd.metadata_id = b.metadata_id JOIN genres g ON g.genre_id = bmd.genre_id WHERE b.book_id = '{model.ID}';";

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

        public async Task<ReturnResultArr<Book>> GetSearchResults(string searchText, int page)
        {
            ReturnResultArr<Book> returnResult = new()
            {
                Results = new List<Book>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = $"SELECT COUNT(*) as row_count FROM books b LEFT JOIN book_metadata bmd ON bmd.metadata_id = b.metadata_id WHERE bmd.title LIKE '%{searchText}%'; " +
                "SELECT *, (SELECT COUNT(*) FROM copies co WHERE book_id = b.book_id AND co.status_id = 1) AS available_copies FROM books b " +
                "LEFT JOIN book_metadata bmd ON bmd.metadata_id = b.metadata_id " +
                "LEFT JOIN genres g ON g.genre_id = bmd.genre_id " +
                $"WHERE bmd.title LIKE '%{searchText}%' " +
                $"ORDER BY added_on DESC, (SELECT NULL) OFFSET ({page} - 1) * 10 ROWS FETCH NEXT 10 ROWS ONLY;";

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

        public Task<ReturnResult<Book>> Create(Book model)
        {
            throw new NotImplementedException();
        }
    }
}
