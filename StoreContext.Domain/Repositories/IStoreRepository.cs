using System.Collections.Generic;
using System.Threading.Tasks;
using StoreContext.Domain.Entities;

namespace StoreContext.Domain.Repositories
{
    public interface IStoreRepository
    {
        Task SaveAsync(Store store);
        Task<List<Store>> GetAllAsync();
        Task<Store> GetByIdAsync(int id);
    }
}