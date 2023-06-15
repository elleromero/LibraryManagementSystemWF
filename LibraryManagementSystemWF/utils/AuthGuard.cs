﻿using Isopoh.Cryptography.Argon2;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.utils
{
    internal class AuthGuard
    {

        public static async Task<bool> HavePermission(string roleName, bool isStrict = false, string password = "")
        {
            bool isAllowed = false;
            string? userId = AuthService.getSignedUser()?.ID.ToString();

            string query = "SELECT * FROM users u JOIN roles r ON u.role_id = r.role_id " +
                $"WHERE u.user_id = '{userId}'";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (string.IsNullOrWhiteSpace(userId) && error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        if (isStrict)
                        {
                            string passwordHash = reader.GetString(reader.GetOrdinal("password_hash"));
                            isAllowed = Argon2.Verify(passwordHash, password);
                        }
                        else
                        {
                            string roleNameDB = reader.GetString(reader.GetOrdinal("name"));
                            isAllowed = roleNameDB.ToUpper() == roleName.ToUpper();
                        }
                    }
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return isAllowed;
        }

        public static bool IsLoggedIn(string id)
        {
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                return user.ID.ToString() == id;
            }

            return false;
        }
    }
}
