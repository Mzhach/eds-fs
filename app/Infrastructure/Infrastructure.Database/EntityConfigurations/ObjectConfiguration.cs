using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations
{
    public class ObjectConfiguration : IEntityTypeConfiguration<Object>
    {
        public void Configure(EntityTypeBuilder<Object> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted");

            builder.HasMany(x => x.Replicas).WithOne(x => x.Object).HasForeignKey(x => x.ObjectId);
            builder.HasMany(x => x.Metadata).WithOne(x => x.Object).HasForeignKey(x => x.ObjectId);
            builder.HasMany(x => x.Events).WithOne(x => x.Object).HasForeignKey(x => x.ObjectId);
        }
    }
}
