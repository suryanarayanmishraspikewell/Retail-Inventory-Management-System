//namespace InventoryManagementAPI.Repositories
//{
//    public class IRepository
//    {
//    }
//}


using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
    }
}
