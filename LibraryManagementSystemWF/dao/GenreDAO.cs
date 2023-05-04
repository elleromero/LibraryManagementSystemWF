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
        public ReturnResult<Genre> Create(Genre model)
        {
            ReturnResult<Genre> returnResult = new ReturnResult<Genre>();
            returnResult.Result = default(Genre);
            returnResult.IsSuccess = false;

            string query = "INSERT INTO genres (name, description) " +
                $"VALUES ('{model.Name}', '{model.Description}'); " +
                "SELECT * FROM genres WHERE genre_id = SCOPE_IDENTITY();";

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
                            returnResult.IsSuccess = returnResult.Result != default(Genre);
                        }

                        reader.Close();
                    }
                    else return;
                }
                catch { return; }
            });

            return returnResult;
        }

        public Genre? Fill(SqlDataReader reader)
        {
            Genre? genre = default(Genre);

            genre = new Genre
            {
                ID = reader.GetInt32(reader.GetOrdinal("genre_id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Description = reader.GetString(reader.GetOrdinal("description"))
            };

            return genre;
        }

        public ReturnResultArr<Genre> GetAll(int page)
        {
            ReturnResultArr<Genre> returnResult = new ReturnResultArr<Genre>();
            returnResult.Results = new List<Genre>();
            returnResult.IsSuccess = false;
            returnResult.rowCount = 1;

            string countQuery = "SELECT COUNT(*) as row_count FROM genres;";
            string query = "SELECT * FROM genres " +
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
                            Genre? genre = this.Fill(reader);

                            if (genre != null) returnResult.Results.Add(genre);
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

        public ReturnResult<Genre> GetById(string id)
        {
            ReturnResult<Genre> returnResult = new ReturnResult<Genre>();
            returnResult.Result = default(Genre);
            returnResult.IsSuccess = false;

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    string query = $"SELECT * FROM genres WHERE genre_id = {id};";

                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            returnResult.Result = this.Fill(reader);
                        }
                        reader.Close();
                        returnResult.IsSuccess = returnResult.Result != default(Genre);
                    }
                    catch { return; }
                }
            });

            return returnResult;
        }

        public bool Remove(string id)
        {
            bool isRemoved = false;

            // remove genre
            string query = $"DELETE FROM genres WHERE genre_id = ${id}; " +
                $"UPDATE books SET genre_id = NULL WHERE genre_id = ${id};";

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        command.ExecuteNonQuery();

                        isRemoved = true;
                    }
                    catch (Exception e) { Console.WriteLine(e); return; }
                }
            });

            return isRemoved;
        }

        public ReturnResult<Genre> Update(Genre model)
        {
            ReturnResult<Genre> returnResult = new ReturnResult<Genre>();
            returnResult.Result = default(Genre);
            returnResult.IsSuccess = false;

            string query = "UPDATE genres SET " +
                $"name = '{model.Name}', " +
                $"description = '{model.Description}' WHERE genre_id = {model.ID}; " +
                $"SELECT * FROM genres WHERE genre_id = {model.ID};";

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
                        returnResult.IsSuccess = returnResult.Result != default(Genre);
                    }
                    catch { return; }
                }
            });

            return returnResult;
        }
    }
}
