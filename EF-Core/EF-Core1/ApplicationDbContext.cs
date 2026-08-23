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
            // modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>().ToTable("Posts", schema: "blogging");
            modelBuilder.HasDefaultSchema("blogging");
            // modelBuilder.Entity<Blog>().Ignore(b => b.AddedOn);
            // modelBuilder.Entity<Blog>().Property(b => b.Url).HasColumnName("BlogUrl");
            // modelBuilder.Entity<Blog>().Property(b => b.Url).HasColumnType("varchar(200)");
            // modelBuilder.Entity<Blog>(eb =>
            // {
            // A way of changing multiple properties at once
            //     eb.Property(b => b.Url).HasMaxLength(200);
            //     eb.Property(b => b.AddedOn).HasColumnType("datetime");
            // });

            // modelBuilder.Entity<Blog>().Property(b => b.Url).HasMaxLength(200);

            modelBuilder
                .Entity<Blog>()
                .Property(b => b.Url)
                .HasComment("this is a url comment");
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
