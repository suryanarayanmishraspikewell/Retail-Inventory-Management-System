﻿//namespace InventoryManagementAPI.Repositories
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
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
