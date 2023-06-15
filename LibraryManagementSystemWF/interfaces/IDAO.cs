using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.interfaces
{
    internal interface IDAO<T>
    {
        Task<ReturnResult<T>> GetById(string id);
        Task<ReturnResultArr<T>> GetAll(int page);
        Task<ReturnResult<T>> Update(T model);
        Task<ReturnResult<T>> Create(T model);
        Task<ReturnResultArr<T>> GetSearchResults(string searchText, int page);
        Task<bool> Remove(string id);
        T? Fill(SqlDataReader reader);
    }
}
