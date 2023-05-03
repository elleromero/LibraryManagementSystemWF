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
        public ReturnResult<Role> Create(Role model)
        {
            throw new NotImplementedException();
        }

        public Role? Fill(SqlDataReader reader)
        {
            Role? role = default(Role);

            role = new Role
            {
                ID = reader.GetInt32(reader.GetOrdinal("role_id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                HasAccess = reader.GetBoolean(reader.GetOrdinal("has_access"))
            };

            return role;
        }

        public ReturnResultArr<Role> GetAll(int page = 1)
        {
            ReturnResultArr<Role> returnResult = new ReturnResultArr<Role>();
            returnResult.Results = new List<Role>();
            returnResult.IsSuccess = false;
            returnResult.rowCount = 1;

            string query = "SELECT * FROM roles;";

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        // fill data
                        while (reader.Read())
                        {
                            Role? role = this.Fill(reader);

                            if (role != null) returnResult.Results.Add(role);
                        }

                        reader.Close();
                        returnResult.IsSuccess = true;
                    }
                    catch (Exception e) { Console.WriteLine(e); return; }
                }
            });

            return returnResult;
        }

        public ReturnResult<Role> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string id)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<Role> Update(Role model)
        {
            throw new NotImplementedException();
        }
    }
}
