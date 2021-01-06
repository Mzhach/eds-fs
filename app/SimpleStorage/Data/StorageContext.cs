using Microsoft.EntityFrameworkCore;

namespace SimpleStorage.Data
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
            modelBuilder.Entity<StoredFile>().HasKey(x => x.Id);
            modelBuilder.Entity<StoredFile>().Property(x => x.Path).HasMaxLength(1024);
            modelBuilder.Entity<StoredFile>().Property(x => x.Filename).HasMaxLength(1024);
        }
    }
}
