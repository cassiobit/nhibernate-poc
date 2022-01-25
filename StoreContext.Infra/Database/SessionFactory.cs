using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StoreContext.Infra.Database.Mappings;

namespace StoreContext.Infra.Database
{
    public static class SessionFactory
    {
        public static ISessionFactory Create(string connectionString)
        {
            return Fluently.Configure()
              .Database(MySQLConfiguration
                .Standard
                .ConnectionString(connectionString)
#if DEBUG 
                .ShowSql()
#endif
              )
              .Mappings(m =>
                  m.FluentMappings
                  .AddFromAssemblyOf<StoreMap>())
              .BuildSessionFactory();
        }
    }
}