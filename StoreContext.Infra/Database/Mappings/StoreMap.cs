using FluentNHibernate.Mapping;
using StoreContext.Domain.Entities;

namespace StoreContext.Infra.Database.Mappings
{
    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Table("store");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable().Length(40);
            HasMany(x=>x.Employees).Inverse().Cascade.None().LazyLoad();
        }
    }
}