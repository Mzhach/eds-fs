using ColdStorageApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ColdStorageApi.Data
{
    public sealed class StorageContext : DbContext
    {
        public DbSet<StoredFile> StoredFiles { get; set; }

        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StoredFile>().HasKey(x => x.Id);
            modelBuilder.Entity<StoredFile>().Property(x => x.Path)
                .HasMaxLength(2048)
                .IsRequired();
        }
    }
}
