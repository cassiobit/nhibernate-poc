using System;

namespace StoreContext.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public virtual int Id { get;  set; }

        public virtual bool Equals(Entity other)
        {
            return Id.Equals(other.Id);
        }
    }
}