// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
//
// namespace EF_Core1;
//
// public partial class EfCoreContext : DbContext
// {
//     public EfCoreContext()
//     {
//     }
//
//     public EfCoreContext(DbContextOptions<EfCoreContext> options)
//         : base(options)
//     {
//     }
//
//     public virtual DbSet<Author> Authors { get; set; }
//
//     public virtual DbSet<Blog> Blogs { get; set; }
//
//     public virtual DbSet<BlogImage> BlogImages { get; set; }
//
//     public virtual DbSet<Category> Categories { get; set; }
//
//     public virtual DbSet<Person> Persons { get; set; }
//
//     public virtual DbSet<Post> Posts { get; set; }
//
//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF-Core;Integrated Security=True");
//
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Author>(entity =>
//         {
//             entity.ToTable("Authors", "blogging");
//
//             entity.Property(e => e.DisplayName)
//                 .HasMaxLength(102)
//                 .HasComputedColumnSql("(([LastName]+', ')+[FirstName])", false);
//             entity.Property(e => e.FirstName).HasMaxLength(50);
//             entity.Property(e => e.LastName).HasMaxLength(50);
//         });
//
//         modelBuilder.Entity<Blog>(entity =>
//         {
//             entity.ToTable("Blogs", "blogging");
//         });
//
//         modelBuilder.Entity<BlogImage>(entity =>
//         {
//             entity.ToTable("BlogImages", "blogging");
//
//             entity.HasIndex(e => e.BlogId, "IX_BlogImages_BlogId");
//
//             entity.Property(e => e.Caption).HasMaxLength(250);
//
//             entity.HasOne(d => d.Blog).WithMany(p => p.BlogImages).HasForeignKey(d => d.BlogId);
//         });
//
//         modelBuilder.Entity<Category>(entity =>
//         {
//             entity.ToTable("Categories", "blogging");
//
//             entity.Property(e => e.Id).ValueGeneratedOnAdd();
//             entity.Property(e => e.Name).HasMaxLength(50);
//         });
//
//         modelBuilder.Entity<Person>(entity =>
//         {
//             entity.ToTable("Persons", "blogging");
//         });
//
//         modelBuilder.Entity<Post>(entity =>
//         {
//             entity.ToTable("Posts", "blogging");
//
//             entity.HasIndex(e => e.BlogId, "IX_Posts_BlogId");
//
//             entity.HasOne(d => d.Blog).WithMany(p => p.Posts).HasForeignKey(d => d.BlogId);
//         });
//
//         OnModelCreatingPartial(modelBuilder);
//     }
//
//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
// }
