using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations
{
    public class ObjectReplicaConfiguration : IEntityTypeConfiguration<ObjectReplica>
    {
        public void Configure(EntityTypeBuilder<ObjectReplica> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");


            builder.Property(x => x.ObjectId).HasColumnName("object_id");
            builder.Property(x => x.StorageId).HasColumnName("storage_id");
        }
    }
}
