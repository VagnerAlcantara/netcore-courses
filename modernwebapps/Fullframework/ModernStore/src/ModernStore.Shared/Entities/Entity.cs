using System;

namespace ModernStore.Shared.Entities
{
    public abstract class Entity : Notification
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        
    }
}
