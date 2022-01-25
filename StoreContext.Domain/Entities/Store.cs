using System.Collections.Generic;

namespace StoreContext.Domain.Entities
{
    public class Store : Entity
    {
        protected Store(){}
        public Store(string name) 
        {
            Name = name;
            Employees = new List<Employee>();
        }

        public virtual string Name { get; protected set; }
        public virtual IList<Employee> Employees { get; protected set; }
    }
}