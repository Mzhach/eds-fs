using System.Collections.Generic;

namespace Infrastructure.Database.Entities
{
    public class Object : BaseEntity, IDeleteableEntity
    {
        public virtual ICollection<ObjectReplica> Replicas { get; set; }
        public virtual ICollection<ObjectMetadata> Metadata { get; set; }
        public virtual ICollection<ObjectEvent> Events { get; set; }

        public bool IsDeleted { get; set; }
    }
}
