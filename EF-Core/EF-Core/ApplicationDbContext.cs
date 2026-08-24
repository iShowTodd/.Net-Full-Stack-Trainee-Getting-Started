// using EF_Core1.Configruations;
// using EF_Core1.Models;
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
            // new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            // modelBuilder.Ignore<Post>(); Fluent API way to exclude property from miagration
            // modelBuilder.Entity<Post>().ToTable("posts");
            // modelBuilder.Entity<Post>().ToTable("Posts", schema: "blogging");
            // modelBuilder.HasDefaultSchema("blogging");
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

            // modelBuilder
            //     .Entity<Blog>()
            //     .Property(b => b.Url)
            //     .HasComment("this is a url comment");

            // modelBuilder.Entity<Book>().HasKey(b => b.BookKey).HasName("BookId"); // set bookkey as PK
            // modelBuilder.Entity<Book>().HasKey(b => new { b.Title, b.Author }); // composite PK

            // modelBuilder.Entity<Blog>().Property(b => b.Rating).HasDefaultValue(2);
            // modelBuilder.Entity<Blog>().Property(b => b.AddedOn).HasDefaultValueSql("GetDate()");

            // modelBuilder
            //     .Entity<Author>()
            //     .Property(a => a.DisplayName)
            //     .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
            //
            // modelBuilder.Entity<Category>().Property(c => c.Id).ValueGeneratedOnAdd();

            // One to one relationship and a FK inside the child BlogImage
            // modelBuilder
            //     .Entity<Blog>()
            //     .HasOne(b => b.BlogImage)
            //     .WithOne(i => i.Blog)
            //     .HasForeignKey<BlogImage>(b => b.BlogForeignKey);

            // One to Many Relationship
            // modelBuilder
            //     .Entity<Blog>()
            //     .HasMany<Post>(b => b.Posts)
            //     .WithOne(p => p.Blog)
            //     .HasForeignKey(p => p.BlogId);
            // .HasConstrainName("FK_New_Name") → to change the FK name
            //
            // modelBuilder
            //     .Entity<Post>()
            //     .HasMany<Tag>(p => p.Tags)
            //     .WithMany(t => t.Posts)
            //     .UsingEntity(j => j.ToTable("PostTageTest"));

            // Many To Many Relationship
            // modelBuilder
            //     .Entity<Post>()
            //     .HasMany<Tag>(p => p.Tags)
            //     .WithMany(t => t.Posts)
            //     .UsingEntity<PostTag>(
            //         j =>
            //             j.HasOne(pt => pt.Tag)
            //                 .WithMany(t => t.PostTags)
            //                 .HasForeignKey(pt => pt.TagId),
            //         j =>
            //             j.HasOne(pt => pt.Post)
            //                 .WithMany(p => p.PostTags)
            //                 .HasForeignKey(pt => pt.PostId),
            //         j =>
            //         {
            //             j.Property(pt => pt.AddedOne).HasDefaultValueSql("GETDATE()");
            //             j.HasKey(t => new { t.PostId, t.TagId });
            //         }
            //     );
            // Indirect many to many relationship
            /*
             modelBuilder.Entity<PostTag>()
                .HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);
    
            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<PostTag>()
                .Property(pt => pt.AddedOn)
                .HasDefaultValueSql("GETDATE()");*/

            // modelBuilder
            //     .Entity<Blog>()
            //     .HasIndex(b => b.Url);

            // modelBuilder
            //     .Entity<Person>()
            //     .HasIndex(p => new { p.FirstName, p.LastName });

            // modelBuilder
            //     .Entity<Person>()
            //     .HasIndex(p => new { p.FirstName, p.LastName })
            //     .HasDatabaseName("person_idx")
            //     .IsUnique();

            // modelBuilder
            //     .Entity<Blog>()
            //     .HasIndex(b => b.Url)
            //     .HasFilter("[URL] IS NOT NULL");

            // Sequences
            // modelBuilder.HasSequence<int>("OrderNumber", schema: "blogging");
            //
            // modelBuilder
            //     .Entity<Order>()
            //     .Property(o => o.OrderNo)
            //     .HasDefaultValueSql("NEXT VALUE FOR blogging.OrderNumber");
            //
            // modelBuilder
            //     .Entity<OrderTest>()
            //     .Property(o => o.OrderNo)
            //     .HasDefaultValueSql("NEXT VALUE FOR blogging.OrderNumber");

            // Data seeding
            // modelBuilder
            //     .Entity<Blog>()
            //     .HasData(
            //         new Blog { Id = 2, Url = "https://devblog.io" },
            //         new Blog { Id = 3, Url = "https://techtalks.net" }
            //     );
            //
            // modelBuilder
            //     .Entity<Post>()
            //     .HasData(
            //         new Post
            //         {
            //             Id = 1,
            //             Title = "EF Core Basics",
            //             Content = "Getting started with EF Core.",
            //             BlogId = 1,
            //         },
            //         new Post
            //         {
            //             Id = 2,
            //             Title = "Migrations Deep Dive",
            //             Content = "How migrations work internally.",
            //             BlogId = 1,
            //         },
            //         new Post
            //         {
            //             Id = 3,
            //             Title = "REST API Tips",
            //             Content = "Best practices for REST APIs.",
            //             BlogId = 2,
            //         }
            //     );
        }

        // public DbSet<Order> Orders { get; set; }
        // public DbSet<OrderTest> OrderTests { get; set; }
        // public DbSet<Person> Persons { get; set; }
        // public DbSet<Blog> Blogs { get; set; }
        //
        // public DbSet<Post> Posts { get; set; }
        //
        // // public DbSet<Tag> Tags { get; set; }
        //
        // // public DbSet<Book> Books { get; set; }
        // public DbSet<Author> Authors { get; set; }
        // public DbSet<Category> Categories { get; set; }
        // public DbSet<BlogImage> BlogImages { get; set; }
    }
}
