using System;

namespace Infrastructure.Database.Entities
{
    public class ObjectReplica : BaseEntity, IDeleteableEntity, IEntityWithCreatedDate, IEntityWithUpdatedDate
    {
        public long ObjectId { get; set; }
        public virtual Object Object { get; set; }

        public long StorageId { get; set; }
        public virtual Storage Storage { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
