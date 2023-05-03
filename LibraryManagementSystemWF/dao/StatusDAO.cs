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
    internal class StatusDAO : IDAO<Status>
    {
        public ReturnResult<Status> Create(Status model)
        {
            throw new NotImplementedException();
        }

        public Status? Fill(SqlDataReader reader)
        {
            Status? status = default(Status);

            status = new Status
            {
                ID = reader.GetInt32(reader.GetOrdinal("status_id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Description = reader.GetString(reader.GetOrdinal("description")),
                IsAvailable = reader.GetBoolean(reader.GetOrdinal("is_available"))
            };

            return status;
        }

        public ReturnResultArr<Status> GetAll(int page = 1)
        {
            ReturnResultArr<Status> returnResult = new ReturnResultArr<Status>();
            returnResult.Results = new List<Status>();
            returnResult.IsSuccess = false;
            returnResult.rowCount = 1;

            string query = "SELECT * FROM statuses;";

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
                            Status? status = this.Fill(reader);

                            if (status != null) returnResult.Results.Add(status);
                        }

                        reader.Close();
                        returnResult.IsSuccess = true;
                    }
                    catch (Exception e) { Console.WriteLine(e); return; }
                }
            });

            return returnResult;
        }

        public ReturnResult<Status> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string id)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<Status> Update(Status model)
        {
            throw new NotImplementedException();
        }
    }
}
