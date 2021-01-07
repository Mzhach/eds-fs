using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations
{
    public class ObjectMetadataConfiguration : IEntityTypeConfiguration<ObjectMetadata>
    {
        public void Configure(EntityTypeBuilder<ObjectMetadata> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.ObjectId).HasColumnName("object_id");
            builder.Property(x => x.Name).HasMaxLength(1024).HasColumnName("name");
            builder.Property(x => x.Value).HasMaxLength(1024).HasColumnName("value");
        }
    }
}
