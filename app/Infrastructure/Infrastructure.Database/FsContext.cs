using System.Reflection;
using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class FsContext : DbContext
    {
        public FsContext(DbContextOptions<FsContext> options) : base(options) { }

        public DbSet<Object> Objects { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<ObjectReplica> ObjectReplicas { get; set; }
        public DbSet<ObjectMetadata> ObjectMetadata { get; set; }
        public DbSet<ObjectEvent> ObjectEvents { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=eds-fs;Username=postgres;Password=password");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
