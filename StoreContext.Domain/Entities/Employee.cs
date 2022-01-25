
namespace StoreContext.Domain.Entities
{
    public class Employee : Entity
    {
        protected Employee(){}
        public Employee(string name, Store store)
        {
            Name = name;
            Store = store;
        }

        public virtual string Name { get; protected set; }
      
        public virtual Store Store { get; protected set; }
    }
}