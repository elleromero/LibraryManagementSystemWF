using LibraryManagementSystemWF.interfaces;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.dao
{
    internal class AuthDAO : IDAO<User>
    {
        public async Task<ReturnResult<User>> Create(User model)
        {
            ReturnResult<User> returnResult = new()
            {
                Result = null,
                IsSuccess = false
            };

            string declareQuery = "DECLARE @member_id UNIQUEIDENTIFIER; SET @member_id = NEWID();";
            string memberQuery = "INSERT INTO members (first_name, last_name, address, phone, email, member_id) " +
                $"VALUES ('{model.Member.FirstName}', '{model.Member.LastName}', '{model.Member.Address}', '{model.Member.Phone}', '{model.Member.Email}', @member_id);";
            string userQuery = "INSERT INTO users (member_id, role_id, username, password_hash) " +
                $"VALUES (@member_id, {model.Role.ID}, '{model.Username}', '{model.PasswordHash}');";
            string selectQuery = "SELECT * FROM members m JOIN users u ON m.member_id = u.member_id JOIN roles r ON r.role_id = u.role_id WHERE u.member_id = @member_id;";
            string query = $"{declareQuery} {memberQuery} {userQuery} {selectQuery}";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    if (reader.Read())
                    {
                        returnResult.Result = Fill(reader);
                    }

                    returnResult.IsSuccess = returnResult.Result != null;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public async Task<ReturnResult<User>> GetByUsername(string username)
        {
            ReturnResult<User> returnResult = new()
            {
                Result = default,
                IsSuccess = false
            };

            string query = $"SELECT * FROM users u JOIN members m ON m.member_id = u.member_id JOIN roles r ON r.role_id = u.role_id WHERE u.username = '{username}';";

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

        public Task<ReturnResultArr<User>> GetAll(int page)
        {
            throw new NotImplementedException();
        }
        public Task<ReturnResult<User>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<User>> Update(User model)
        {
            throw new NotImplementedException();
        }

        public User? Fill(SqlDataReader reader)
        {
            User? user = new()
            {
                ID = reader.GetGuid(reader.GetOrdinal("user_id")),
                Username = reader.GetString(reader.GetOrdinal("username")),
                PasswordHash = reader.GetString(reader.GetOrdinal("password_hash")),
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
            return user;
        }
    }
}
