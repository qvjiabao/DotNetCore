using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jabo.MongoDB.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string id);
        Task Add(T item);
        Task<bool> Remove(string id);
        Task<bool> Update(string id, string body);
    }
}
