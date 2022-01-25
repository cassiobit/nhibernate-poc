using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using StoreContext.Domain.Entities;
using StoreContext.Domain.Repositories;

namespace StoreContext.Infra.Database.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ISession _session;

        public EmployeeRepository(ISession session)
        {
            _session = session;
        }

        public async Task SaveAsync(Employee store)
        {
            var transaction = _session.BeginTransaction();
            await _session.SaveOrUpdateAsync(store);
            await transaction.CommitAsync();
            transaction.Dispose();
        }


        public async Task<List<Employee>> GetAllAsync()
        {
            var transaction = _session.BeginTransaction();
            var employees = await _session.Query<Employee>().ToListAsync();
            transaction.Dispose();
            return employees;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var transaction = _session.BeginTransaction();
            var employee = await _session.Query<Employee>().Where(e => e.Id == id).FirstOrDefaultAsync();
            transaction.Dispose();
            return employee;
        }
    }
}