using System.Collections.Generic;
using System.Threading.Tasks;
using StoreContext.Domain.Entities;

namespace StoreContext.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task SaveAsync(Employee store);
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
    }
}