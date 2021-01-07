using System;

namespace Infrastructure.Database.Entities
{
    public interface IEntityWithUpdatedDate
    {
        DateTime UpdatedAt { get; set; }
    }
}
