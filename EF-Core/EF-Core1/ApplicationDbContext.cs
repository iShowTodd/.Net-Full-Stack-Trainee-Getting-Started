using EF_Core1.Configruations;
using EF_Core1.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core1
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF-Core;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"
            );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            // modelBuilder.Ignore<Post>(); Fluent API way to exclude property from miagration
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
