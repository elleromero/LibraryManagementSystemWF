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
    internal class StatsDAO : IDAO<Stats>
    {
        public Task<ReturnResult<Stats>> Create(Stats model)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnResult<Stats>> Get()
        {
            ReturnResult<Stats> returnResult = new()
            {
                IsSuccess = false,
                Result = default
            };

            string query = "SELECT " +
                "(SELECT COUNT(*) FROM books) AS total_books, " +
                "(SELECT COUNT(*) FROM loans WHERE is_returned = 0) AS borrowed_books, " +
                "(SELECT COUNT(*) FROM loans WHERE is_returned = 1) AS returned_books, " +
                "(SELECT COUNT(*) FROM copies c JOIN statuses s ON s.status_id = c.status_id WHERE s.is_available = 1) AS available_copies";

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
                        returnResult.IsSuccess = returnResult.Result != default(Stats);
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Stats? Fill(SqlDataReader reader)
        {
            Stats? stats = new()
            {
                TotalBooks = reader.GetInt32(reader.GetOrdinal("total_books")),
                TotalBorrowedBooks = reader.GetInt32(reader.GetOrdinal("borrowed_books")),
                TotalReturnedBooks = reader.GetInt32(reader.GetOrdinal("returned_books")),
                TotalAvailableCopies = reader.GetInt32(reader.GetOrdinal("available_copies"))
            };

            return stats;
        }

        public Task<ReturnResultArr<Stats>> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<Stats>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<Stats>> Update(Stats model)
        {
            throw new NotImplementedException();
        }
    }
}
