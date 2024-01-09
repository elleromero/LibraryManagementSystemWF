using Isopoh.Cryptography.Argon2;
using LibraryManagementSystemWF.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.utils
{
    internal class BookGuard
    {
        public static async Task<bool> IsPastDue(string userId)
        {
            bool isNotAllowed = true;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if ((userId == null) && error != null) return;

                string query = $"SELECT due_date FROM loans WHERE user_id = '{userId}' AND is_returned = 0";

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        DateTime dt = reader.GetDateTime(reader.GetOrdinal("due_date"));
                        
                        if (dt.Date < DateTime.Now)
                        {
                            return;
                        }
                    }

                    if (new Config().allowBorrowAfterDue)
                    {
                        return;
                    }

                    isNotAllowed = false;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return isNotAllowed;
        }

        public static async Task<bool> IsLimitReached(string userId)
        {
            bool isNotAllowed = true;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if ((userId == null) && error != null) return;

                string query = $"SELECT COUNT(*) AS row_count FROM loans WHERE user_id = '{userId}' AND is_returned = 0";

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        int rowCount = reader.GetInt32(reader.GetOrdinal("row_count"));

                        if (rowCount >= new Config().maxBorrowedBooks)
                        {
                            return;
                        }
                    }

                    isNotAllowed = false;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return isNotAllowed;
        }
    }
}
