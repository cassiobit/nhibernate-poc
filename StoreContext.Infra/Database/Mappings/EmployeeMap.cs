using FluentNHibernate.Mapping;
using StoreContext.Domain.Entities;

namespace StoreContext.Infra.Database.Mappings
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("employee");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable().Length(40);
            References(x=>x.Store);
        }
    }
}