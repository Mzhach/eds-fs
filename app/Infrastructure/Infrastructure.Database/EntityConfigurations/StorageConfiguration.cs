using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

            builder.HasMany(x => x.Objects).WithOne(x => x.Storage).HasForeignKey(x => x.StorageId);

            builder.Property(x => x.Name).HasMaxLength(1024).HasColumnName("name");
            builder.Property(x => x.Type).HasColumnName("type");
            builder.Property(x => x.State).HasColumnName("state");
            builder.Property(x => x.Capacity).HasColumnName("capacity");
            builder.Property(x => x.CapacityFree).HasColumnName("capacity_free");
            builder.Property(x => x.BaseUrl).HasMaxLength(1024).HasColumnName("base_url");
        }
    }
}
