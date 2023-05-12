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
    internal class RoleDAO : IDAO<Role>
    {
        public Task<ReturnResult<Role>> Create(Role model)
        {
            throw new NotImplementedException();
        }

        public Role? Fill(SqlDataReader reader)
        {
            Role? role = new()
            {
                ID = reader.GetInt32(reader.GetOrdinal("role_id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                HasAccess = reader.GetBoolean(reader.GetOrdinal("has_access"))
            };
            return role;
        }

        public async Task<ReturnResultArr<Role>> GetAll(int page = 1)
        {
            ReturnResultArr<Role> returnResult = new()
            {
                Results = new List<Role>(),
                IsSuccess = false,
                rowCount = 1
            };

            string query = "SELECT * FROM roles;";

            await SqlClient.ExecuteAsync(async (error, conn) =>
            {
                if (error != null) return;

                SqlDataReader? reader = null;

                try
                {
                    SqlCommand command = new(query, conn);
                    reader = await command.ExecuteReaderAsync();

                    // fill data
                    while (await reader.ReadAsync())
                    {
                        Role? role = Fill(reader);

                        if (role != null) returnResult.Results.Add(role);
                    }

                    returnResult.IsSuccess = true;
                }
                catch { return; }
                finally { if (reader != null) await reader.CloseAsync(); }
            });

            return returnResult;
        }

        public Task<ReturnResult<Role>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnResult<Role>> Update(Role model)
        {
            throw new NotImplementedException();
        }
    }
}
