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
    internal class LoanDAO : IDAO<Loan>
    {
        public async Task<ReturnResult<Loan>> Create(Loan model)
        {
            ReturnResult<Loan> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "DECLARE @copy_id UNIQUEIDENTIFIER; " +
                "SELECT TOP 1 @copy_id = copy_id " +
                "FROM copies " +
                $"WHERE book_id = '{model.Copy.Book.ID}' AND status_id = 1; " +
                "IF @copy_id IS NOT NULL " +
                "BEGIN " +
                "INSERT INTO loans (user_id, copy_id, date_borrowed, due_date, is_returned) " +
                $"VALUES ('{model.User.ID}', @copy_id, '{model.DateBorrowed:yyyy-MM-dd HH:mm:ss.fff}', '{model.DateDue:yyyy-MM-dd HH:mm:ss.fff}', 0); " +
                "UPDATE copies SET status_id = 2 WHERE copy_id = @copy_id; " +
                "SELECT *, s.name AS sname, s.description AS sdescription, s.is_available AS savailable, " +
                "g.name AS gname, g.description AS gdescription " +
                "FROM loans l " +
                "JOIN users u ON u.user_id = l.user_id " +
                "JOIN copies c ON c.copy_id = l.copy_id " +
                "JOIN books b ON c.book_id = b.book_id " +
                "JOIN roles r ON u.role_id = r.role_id " +
                "JOIN members m ON u.member_id = m.member_id " +
                "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
                "JOIN statuses s ON c.status_id = s.status_id " +
                "WHERE l.copy_id = @copy_id; " +
                "END";

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
                        returnResult.IsSuccess = returnResult.Result != default(Loan);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Loan? Fill(SqlDataReader reader)
        {
            Genre genre = new();

            if (!reader.IsDBNull(reader.GetOrdinal("genre_id")))
            {
                genre.ID = reader.GetInt32(reader.GetOrdinal("genre_id"));
                genre.Name = reader.GetString(reader.GetOrdinal("gname"));
                genre.Description = reader.GetString(reader.GetOrdinal("gdescription"));
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

            Status? status = new()
            {
                ID = reader.GetInt32(reader.GetOrdinal("status_id")),
                Name = reader.GetString(reader.GetOrdinal("sname")),
                Description = reader.GetString(reader.GetOrdinal("sdescription")),
                IsAvailable = reader.GetBoolean(reader.GetOrdinal("savailable"))
            };

            Copy? copy = new()
            {
                ID = reader.GetGuid(reader.GetOrdinal("copy_id")),
                Book = book,
                Status = status
            };

            User? user = new()
            {
                ID = reader.GetGuid(reader.GetOrdinal("user_id")),
                Username = reader.GetString(reader.GetOrdinal("username")),
                Role = new Role
                {
                    ID = reader.GetInt32(reader.GetOrdinal("role_id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    HasAccess = reader.GetBoolean(reader.GetOrdinal("has_access"))
                },
                Member = new Member
                {
                    ID = reader.GetGuid(reader.GetOrdinal("member_id")),
                    FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                    LastName = reader.GetString(reader.GetOrdinal("last_name")),
                    Phone = reader.GetString(reader.GetOrdinal("phone")),
                    Email = reader.GetString(reader.GetOrdinal("email")),
                    Address = reader.GetString(reader.GetOrdinal("address")),
                }
            };
            return new Loan
            {
                ID = reader.GetGuid(reader.GetOrdinal("loan_id")),
                User = user,
                Copy = copy,
                DateBorrowed = reader.GetDateTime(reader.GetOrdinal("date_borrowed")),
                DateDue = reader.GetDateTime(reader.GetOrdinal("due_date")),
                IsReturned = reader.GetBoolean(reader.GetOrdinal("is_returned"))
            };
        }

        public async Task<ReturnResultArr<Loan>> GetAllLoans(int page, Loan model)
        {
            ReturnResultArr<Loan> returnResult = new()
            {
                Results = new List<Loan>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT COUNT(*) as row_count FROM loans; " +
                "SELECT *, s.name AS sname, s.description AS sdescription, s.is_available AS savailable, " +
                "g.name AS gname, g.description AS gdescription " +
                "FROM loans l " +
                "JOIN users u ON u.user_id = l.user_id " +
                "JOIN copies c ON c.copy_id = l.copy_id " +
                "JOIN books b ON c.book_id = b.book_id " +
                "JOIN roles r ON u.role_id = r.role_id " +
                "JOIN members m ON u.member_id = m.member_id " +
                "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
                "JOIN statuses s ON c.status_id = s.status_id " +
                $"WHERE l.user_id = '{model.User.ID}' " +
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
                        Loan? loan = Fill(reader);

                        if (loan != null) returnResult.Results.Add(loan);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Task<ReturnResultArr<Loan>> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnResult<Loan>> GetById(string id)
        {
            ReturnResult<Loan> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "SELECT *, s.name AS sname, s.description AS sdescription, s.is_available AS savailable, " +
                "g.name AS gname, g.description AS gdescription " +
                "FROM loans l " +
                "JOIN users u ON u.user_id = l.user_id " +
                "JOIN copies c ON c.copy_id = l.copy_id " +
                "JOIN books b ON c.book_id = b.book_id " +
                "JOIN roles r ON u.role_id = r.role_id " +
                "JOIN members m ON u.member_id = m.member_id " +
                "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
                "JOIN statuses s ON c.status_id = s.status_id " +
                $"WHERE loan_id = '{id}';";

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
                    }

                    returnResult.IsSuccess = returnResult.Result != default(Loan);
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }

            });

            return returnResult;
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnResult<Loan>> Update(Loan model)
        {
            ReturnResult<Loan> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = "DECLARE @copy table (copy_id UNIQUEIDENTIFIER); " +
                           "UPDATE loans SET is_returned = 1 " +
                           "OUTPUT inserted.copy_id INTO @copy " +
                           $"WHERE user_id = '{model.User.ID}' AND loan_id = '{model.ID}'; " +
                           "UPDATE copies SET status_id = 1 " +
                           "WHERE copy_id = (SELECT TOP 1 copy_id FROM @copy); " +
                           "SELECT *, s.name AS sname, s.description AS sdescription, s.is_available AS savailable, " +
                           "g.name AS gname, g.description AS gdescription " +
                           "FROM loans l " +
                           "JOIN users u ON u.user_id = l.user_id " +
                           "JOIN copies c ON c.copy_id = l.copy_id " +
                           "JOIN books b ON c.book_id = b.book_id " +
                           "JOIN roles r ON u.role_id = r.role_id " +
                           "JOIN members m ON u.member_id = m.member_id " +
                           "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
                           "JOIN statuses s ON c.status_id = s.status_id " +
                           $"WHERE loan_id = '{model.ID}';";

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
                        returnResult.IsSuccess = returnResult.Result != default(Loan);
                    }
                }
                catch {  return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

    }
}
