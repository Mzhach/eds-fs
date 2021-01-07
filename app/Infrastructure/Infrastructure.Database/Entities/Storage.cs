using Infrastructure.Database.Enums;
using System;
using System.Collections.Generic;

namespace Infrastructure.Database.Entities
{
    public class Storage : BaseEntity, IEntityWithCreatedDate, IEntityWithUpdatedDate
    {
        public string Name { get; set; }
        public StorageType Type { get; set; }
        public StorageState State { get; set; }
        public int Capacity { get; set; }
        public int CapacityFree { get; set; }
        public string BaseUrl { get; set; }

        public virtual ICollection<ObjectReplica> Objects { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
