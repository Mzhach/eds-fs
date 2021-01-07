using Infrastructure.Database.Enums;
using System;

namespace Infrastructure.Database.Entities
{
    public class ObjectEvent : BaseEntity, IEntityWithCreatedDate
    {
        public long ObjectId { get; set; }
        public virtual Object Object { get; set; }

        public ObjectEventType Type { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
