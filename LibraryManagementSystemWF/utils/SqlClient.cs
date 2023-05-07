using LibraryManagementSystemWF.services;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.utils
{
    internal class SqlClient : EnvService
    {
        public static async Task ExecuteAsync(Func<Exception?, SqlConnection?, Task> callback, bool useBase = false)
        {
            using (SqlConnection conn = new(useBase ? GetConnBase() : GetConnStr()))
            {
                Exception? error = null;

                try
                {
                    await conn.OpenAsync();
                }
                catch (Exception e)
                {
                    error = e;
                }

                await callback(error, conn);
            }
        }
    }
}
