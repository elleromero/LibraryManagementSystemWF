using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.services
{
    internal class SeederService : EnvService
    {
        // This class inserts and creates initial data to the database
        public static async Task<bool> CreateInitialTables()
        {
            bool areTablesCreated = false;

            // check if the the database exists and has no tables
            if (await IsDatabaseExist(GetDBName()))
            {
                if (!await AreTablesExist(GetDBName()))
                {
                    await SqlClient.ExecuteAsync(async (error, conn) =>
                    {
                        if (error != null) return;
                        
                        try
                        {
                            string script = File.ReadAllText("../../../resources/queries/setupSQL.sql");
                            SqlCommand command = new(script, conn);

                            await command.ExecuteScalarAsync();
                            areTablesCreated = true;
                        } catch { return; }
                    });
                }
            }

            return areTablesCreated;
        }

        public static async Task<bool> CreateDatabase() {
            bool isDBCreated = false;

            // check if database already exists
            if (!await IsDatabaseExist(GetDBName()))
            {
                string query = $"CREATE DATABASE {GetDBName()};";

                await SqlClient.ExecuteAsync(async (error, conn) =>
                {
                    SqlCommand command = new(query, conn);

                    if (error != null) return;
                    
                    try
                    {
                        await command.ExecuteScalarAsync();
                        isDBCreated = true;
                    }
                    catch { return; }

                }, true);
            }
            return isDBCreated;
        }

        private static async Task<bool> IsDatabaseExist(string dbName)
        {
            bool isExists = false;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;
                
                string query = $"SELECT DB_ID('{dbName}') AS db_id;";
                SqlCommand command = new(query, conn);

                try
                {
                    object? dbId = await command.ExecuteScalarAsync();

                    isExists = dbId != DBNull.Value;
                }
                catch { return; }

            }, true);

            return isExists;
        }

        private static async Task<bool> AreTablesExist(string dbName)
        {
            bool isExists = false;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                string query = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_catalog = '{dbName}';";
                SqlCommand command = new(query, conn);

                try
                {
                    int count = 0;
                    object? v = await command.ExecuteScalarAsync();
                    if (v != null) count = (int)v;

                    isExists = count > 0;
                }
                catch { return; }
                
            }, true);

            return isExists;
        }

        public static async Task<bool> SeedUsers()
        {
            bool isSuccess = false;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                try
                {
                    string script = File.ReadAllText("../../../resources/queries/defaultUsers.sql");
                    SqlCommand command = new(script, conn);

                    await command.ExecuteScalarAsync();
                    isSuccess = true;
                }
                catch { return; }
            });

            return isSuccess;
        }

        public static async Task<bool> SeedBooks()
        {
            bool isSuccess = false;

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                try
                {
                    string script = File.ReadAllText("../../../resources/queries/defaultBooks.sql");
                    SqlCommand command = new(script, conn);

                    await command.ExecuteScalarAsync();
                    isSuccess = true;
                }
                catch { return; }
            });

            return isSuccess;
        }
    }
}
