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
        public ReturnResult<Copy> CreateMany(string bookId, int copies)
        {
            ReturnResult<Copy> returnResult = new ReturnResult<Copy>();
            returnResult.Result = default(Copy);
            returnResult.IsSuccess = false;

            string declareQuery = "DECLARE @counter int SET @counter = 1; " +
                "DECLARE @copy_id UNIQUEIDENTIFIER;";
            string loopQuery = $"WHILE (@counter <= 10) " +
                "BEGIN " +
                "SET @copy_id = NEWID(); " +
                $"INSERT INTO copies (copy_id, book_id, status_id) VALUES (@copy_id, '{bookId}', 1); " +
                "SET @counter = @counter + 1; " +
                "END;";
            string selectQuery = "SELECT *, s.name AS status_name, s.description AS status_description, s.is_available AS status_is_available FROM copies c " +
                "JOIN books b ON b.book_id = c.book_id " +
                "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
                "JOIN statuses s ON s.status_id = c.status_id " +
                "WHERE copy_id = @copy_id;";
            string query = $"{declareQuery} {loopQuery} {selectQuery}";

            SqlClient.Execute((error, conn) =>
            {
                try
                {
                    if (error == null)
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            returnResult.Result = this.Fill(reader);
                            returnResult.IsSuccess = returnResult.Result != default(Copy);
                        }

                        reader.Close();
                    }
                    else return;
                }
                catch (Exception e) { Console.WriteLine(e); return; }
            });

            return returnResult;

        }

        public ReturnResult<Copy> Create(Copy model)
        {
            throw new NotImplementedException();
        }

        public Copy? Fill(SqlDataReader reader)
        {
            Copy? copy = default(Copy);
            Genre genre = new Genre();
            Book? book = default(Book);
            Status? status = default(Status);

            if (!reader.IsDBNull(reader.GetOrdinal("genre_id")))
            {
                genre.ID = reader.GetInt32(reader.GetOrdinal("genre_id"));
                genre.Name = reader.GetString(reader.GetOrdinal("genres.name"));
                genre.Description = reader.GetString(reader.GetOrdinal("genres.description"));
            }

            book = new Book
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
            
            status = new Status
            {
                ID = reader.GetInt32(reader.GetOrdinal("status_id")),
                Name = reader.GetString(reader.GetOrdinal("status_name")),
                Description = reader.GetString(reader.GetOrdinal("status_description")),
                IsAvailable = reader.GetBoolean(reader.GetOrdinal("status_is_available"))
            };
            
            copy = new Copy
            {
                ID = reader.GetGuid(reader.GetOrdinal("copy_id")),
                Book = book,
                Status = status
            };

            return copy;
        }

        public ReturnResultArr<Copy> GetAll(int page)
        {
            ReturnResultArr<Copy> returnResult = new ReturnResultArr<Copy>();
            returnResult.Results = new List<Copy>();
            returnResult.IsSuccess = false;
            returnResult.rowCount = 1;

            string countQuery = "SELECT COUNT(*) as row_count FROM copies;";
            string query = "SELECT * FROM copies " +
                $"ORDER BY (SELECT NULL) OFFSET ({page} - 1) * 10 ROWS FETCH NEXT 10 ROWS ONLY;";

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlCommand countCommand = new SqlCommand(countQuery, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        // fill data
                        while (reader.Read())
                        {
                            Copy? copy = this.Fill(reader);

                            if (copy != null) returnResult.Results.Add(copy);
                        }

                        reader.Close();

                        // add row count
                        SqlDataReader countReader = countCommand.ExecuteReader();
                        if (countReader.Read())
                        {
                            returnResult.rowCount = countReader.GetInt32(countReader.GetOrdinal("row_count"));
                        }

                        countReader.Close();
                        returnResult.IsSuccess = true;
                    }
                    catch (Exception e) { Console.WriteLine(e); return; }
                }
            });

            return returnResult;
        }

        public ReturnResult<Copy> GetById(string id)
        {
            ReturnResult<Copy> returnResult = new ReturnResult<Copy>();
            returnResult.Result = default(Copy);
            returnResult.IsSuccess = false;

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    string query = "SELECT * FROM copies c " +
                       "JOIN books b ON b.book_id = c.book_id " +
                       "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
                       "JOIN statuses s ON s.status_id = c.status_id " +
                       $"WHERE copy_id = '{id}';";

                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            returnResult.Result = this.Fill(reader);
                        }
                        reader.Close();
                        returnResult.IsSuccess = returnResult.Result != default(Copy);
                    }
                    catch { return; }
                }
            });

            return returnResult;

            throw new NotImplementedException();
        }

        public bool Remove(string id)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<Copy> Update(Copy model)
        {
            throw new NotImplementedException();
        }
    }
}
