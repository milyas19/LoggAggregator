using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.DBWrapper
{
    public interface IDBWrapper<T> where T : class
    {
        Task<T> Add(T log);
        Task<List<T>> GetList();
        Task<T> GetSingle(int id);
    }
}
