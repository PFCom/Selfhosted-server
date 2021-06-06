using Microsoft.EntityFrameworkCore;

namespace PFComSelfhostedServer.Data.Database
{
    /// <summary>
    /// A DbContext for a database.
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public DbSet<UserTable> Users { get; set; }

        public DbSet<LocalUserTable> LocalUsers { get; set; }

        public DbSet<SessionTable> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserTable>()
                .HasIndex(u => u.Nickname)
                .IsUnique(); // Creates an index on the column "Nickname" in table User and the index is unique.
        }
    }
}
