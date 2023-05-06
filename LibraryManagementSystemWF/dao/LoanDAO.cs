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
        public ReturnResult<Loan> Create(Loan model)
        {
            ReturnResult<Loan> returnResult = new ReturnResult<Loan>();
            returnResult.Result = default(Loan);
            returnResult.IsSuccess = false;

            string findCopyQuery = $"SELECT copy_id FROM copies WHERE book_id = '{model.Copy.Book.ID}' AND status_id = 1; ";

            SqlClient.Execute((error, conn) =>
            {
                try
                {
                    if (error == null)
                    {
                        SqlCommand copyCommand = new SqlCommand(findCopyQuery, conn);

                        SqlDataReader copyReader = copyCommand.ExecuteReader();

                        if (copyReader.Read())
                        {
                            Guid copyId = copyReader.GetGuid(copyReader.GetOrdinal("copy_id"));

                            string query = "INSERT INTO loans (user_id, copy_id, date_borrowed, due_date, is_returned) " +
                                $"VALUES ('{model.User.ID}', '{copyId}', '{model.DateBorrowed.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{model.DateDue.ToString("yyyy-MM-dd HH:mm:ss.fff")}', 0); " +
                                $"UPDATE copies SET is_available = 2 WHERE copy_id = '{copyId}'; " +
                                "SELECT *, s.name AS sname, s.description AS sdescription, " +
                                "g.name AS gname, g.description AS gdescription FROM loans l " +
                                "JOIN users u ON u.user_id = l.user_id " +
                                "JOIN copies c ON c.copy_id = l.copy_id " +
                                "JOIN books b ON c.book_id = b.book_id " +
                                "JOIN users u ON l.user_id = u.user_id " +
                                "JOIN roles r ON u.role_id = r.role_id " +
                                "JOIN members m ON u.member_id = m.member_id" +
                                "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
                                "JOIN statuses s ON c.status_id = s.status_id " +
                                "WHERE loan_id = SCOPE_IDENTITY();";
                            SqlCommand command = new SqlCommand(query, conn);
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                returnResult.Result = this.Fill(reader);
                                returnResult.IsSuccess = returnResult.Result != default(Loan);
                            }

                            reader.Close();
                        }

                        copyReader.Close();
                    }
                    else return;
                }
                catch { return; }
            });

            return returnResult;
        }

        public Loan? Fill(SqlDataReader reader)
        {
            Copy? copy = default(Copy);
            Genre genre = new Genre();
            Book? book = default(Book);
            Status? status = default(Status);
            User? user = default(User);

            if (!reader.IsDBNull(reader.GetOrdinal("genre_id")))
            {
                genre.ID = reader.GetInt32(reader.GetOrdinal("genre_id"));
                genre.Name = reader.GetString(reader.GetOrdinal("gname"));
                genre.Description = reader.GetString(reader.GetOrdinal("gdescription"));
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
                Name = reader.GetString(reader.GetOrdinal("sname")),
                Description = reader.GetString(reader.GetOrdinal("sdescription")),
                IsAvailable = reader.GetBoolean(reader.GetOrdinal("savailable"))
            };

            copy = new Copy
            {
                ID = reader.GetGuid(reader.GetOrdinal("copy_id")),
                Book = book,
                Status = status
            };

            user = new User
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

        public ReturnResultArr<Loan> GetAll(int page)
        {
            ReturnResultArr<Loan> returnResult = new ReturnResultArr<Loan>();
            returnResult.Results = new List<Loan>();
            returnResult.IsSuccess = false;
            returnResult.rowCount = 1;

            string countQuery = "SELECT COUNT(*) as row_count FROM loans;";
            string query = "SELECT *, s.name AS sname, s.description AS sdescription, " +
                                "g.name AS gname, g.description AS gdescription FROM loans l " +
                                "JOIN users u ON u.user_id = l.user_id " +
                                "JOIN copies c ON c.copy_id = l.copy_id " +
                                "JOIN books b ON c.book_id = b.book_id " +
                                "JOIN users u ON l.user_id = u.user_id " +
                                "JOIN roles r ON u.role_id = r.role_id " +
                                "JOIN members m ON u.member_id = m.member_id" +
                                "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
                                "JOIN statuses s ON c.status_id = s.status_id " +
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
                            Loan? loan = this.Fill(reader);

                            if (loan != null) returnResult.Results.Add(loan);
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

        public ReturnResult<Loan> GetById(string id)
        {
            ReturnResult<Loan> returnResult = new ReturnResult<Loan>();
            returnResult.Result = default(Loan);
            returnResult.IsSuccess = false;

            string query = "SELECT *, s.name AS sname, s.description AS sdescription, " +
                                "g.name AS gname, g.description AS gdescription FROM loans l " +
                                "JOIN users u ON u.user_id = l.user_id " +
                                "JOIN copies c ON c.copy_id = l.copy_id " +
                                "JOIN books b ON c.book_id = b.book_id " +
                                "JOIN users u ON l.user_id = u.user_id " +
                                "JOIN roles r ON u.role_id = r.role_id " +
                                "JOIN members m ON u.member_id = m.member_id" +
                                "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
                                "JOIN statuses s ON c.status_id = s.status_id " +
                                $"WHERE loan_id = {id};";

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            returnResult.Result = this.Fill(reader);
                        }
                        reader.Close();
                        returnResult.IsSuccess = returnResult.Result != default(Loan);
                    }
                    catch { return; }
                }
            });

            return returnResult;
        }

        public bool Remove(string id)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<Loan> Update(Loan model)
        {
            ReturnResult<Loan> returnResult = new ReturnResult<Loan>();
            returnResult.Result = default(Loan);
            returnResult.IsSuccess = false;

            string query = "DECLARE @copy table (copy_id UNIQUEIDENTIFIER); " +
                "UPDATE loans SET is_returned = 1 " +
                "OUTPUT inserted.copy_id INTO @copy " +
                $"WHERE user_id = '{model.User.ID}' AND loan_id = '{model.ID}'; " +
                "UPDATE copies SET status_id = 1 " +
                "WHERE copy_id = (SELECT TOP 1 copy_id FROM @copy); " +
                "SELECT *, s.name AS sname, s.description AS sdescription, " +
                "g.name AS gname, g.description AS gdescription FROM loans l " +
                "JOIN users u ON u.user_id = l.user_id " +
                "JOIN copies c ON c.copy_id = l.copy_id " +
                "JOIN books b ON c.book_id = b.book_id " +
                "JOIN users u ON l.user_id = u.user_id " +
                "JOIN roles r ON u.role_id = r.role_id " +
                "JOIN members m ON u.member_id = m.member_id" +
                "LEFT JOIN genres g ON g.genre_id = b.genre_id " +
                "JOIN statuses s ON c.status_id = s.status_id " +
                $"WHERE loan_id = {model.ID};";

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            returnResult.Result = this.Fill(reader);
                        }
                        reader.Close();
                        returnResult.IsSuccess = returnResult.Result != default(Loan);
                    }
                    catch { return; }
                }
            });

            return returnResult;
        }
    }
}
