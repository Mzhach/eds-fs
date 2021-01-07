using System;

namespace Infrastructure.Database.Entities
{
    public interface IEntityWithCreatedDate
    {
        DateTime CreatedAt { get; set; }
    }
}
