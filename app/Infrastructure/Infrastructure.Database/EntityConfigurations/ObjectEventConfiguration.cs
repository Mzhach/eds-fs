using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations
{
    public class ObjectEventConfiguration : IEntityTypeConfiguration<ObjectEvent>
    {
        public void Configure(EntityTypeBuilder<ObjectEvent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");

            builder.Property(x => x.ObjectId).HasColumnName("object_id");
            builder.Property(x => x.Type).HasColumnName("type");
        }
    }
}
