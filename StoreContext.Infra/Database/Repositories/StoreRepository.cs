using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using StoreContext.Domain.Entities;
using StoreContext.Domain.Repositories;

namespace StoreContext.Infra.Database.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private ISession _session;

        public StoreRepository(ISession session)
        {
            _session = session;
        }

        public async Task SaveAsync(Store store)
        {
            var transaction = _session.BeginTransaction();
            await _session.SaveOrUpdateAsync(store);
            await transaction.CommitAsync();
            transaction.Dispose();
        }

        public async Task<List<Store>> GetAllAsync()
        {
            var transaction = _session.BeginTransaction();
            var stores = await _session.Query<Store>().ToListAsync();
            transaction.Dispose();
            return stores;
        }

        public async Task<Store> GetByIdAsync(int id)
        {
            var transaction = _session.BeginTransaction();
            var store = await _session.Query<Store>().Where(s => s.Id == id).FirstOrDefaultAsync();
            transaction.Dispose();
            return store;
        }
    }
}