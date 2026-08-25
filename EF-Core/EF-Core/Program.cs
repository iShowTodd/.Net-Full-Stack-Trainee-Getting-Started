using Microsoft.EntityFrameworkCore;

namespace EF_Core1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var _context = new ApplicationDbContext();

            var posts = _context.Posts.ToList(); // selecting all items
            var post = _context.Posts.Find(1); // selecting by PK

            var post2 = _context.Posts.Single(p => p.Id == 1); //  Selecting single element using single
            var post3 = _context.Posts.SingleOrDefault(p => p.Id == 1); //  Selecting single element using singleOrDefault

            var post4 = _context.Posts.First();

            var post5 = _context.Posts.OrderBy(p => p.Id).Last(); // you must use orderby before using last
            var post6 = _context.Posts.FirstOrDefault(p => p.Id > 100);
            var post7 = _context.Posts.OrderBy(p => p.Id).LastOrDefault(p => p.Id < 100); // you must use orderby before LastOrDefault
            //Filtering
            var post8 = _context.Posts.Where(p => p.Id < 50); // select all elements < 50

            // Any vs All
            var isExisted = _context.Posts.Any(p => p.Id == 1); // returns true or false
            var AllExisted = _context.Posts.All(p => p.Id > 100); // returns if all (true , false)

            // Min vs Max
            var minValue = _context.Posts.Min(p => p.Content.Length); // min value
            var maxValue = _context.Posts.Max(p => p.Content.Length); // max value

            // orderby
            var content = _context.Posts.OrderBy(p => p.Content).ToList();

            // Select
            // create new form of data
            // var selected = _context.Posts.Select(p => new { });

            // var selected = _context.Posts.Select(p => new { }).Distinct().toList();
            // Pagination using take and skip
            var page = 2;
            var pageSize = 3;

            var paginatedPosts = _context
                .Posts.OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // GroupBy

            var postsByBlog = _context
                .Posts.GroupBy(p => p.BlogId)
                .Select(g => new
                {
                    BlogId = g.Key,
                    Count = g.Count(),
                    Posts = g.ToList(),
                })
                .ToList();
            // inner join
            var res = _context.Posts.Join(
                _context.Blogs,
                post => post.BlogId,
                blog => blog.Id,
                (post, blog) =>
                    new
                    {
                        PostId = post.Id,
                        BlogId = blog.Id,
                        BlogUrl = blog.Url,
                    }
            );

            // Join using LINQ

            var res2 = (
                from p in _context.Posts
                join b in _context.Blogs on p.BlogId equals b.Id
                select new
                {
                    PostId = p.Id,
                    BlogId = b.Id,
                    BlogUrl = b.Url,
                }
            ).ToList();

            // Left Join

            var res3 = _context
                .Blogs.GroupJoin(
                    _context.Posts,
                    blog => blog.Id,
                    post => post.BlogId,
                    (blog, posts) =>
                        new
                        {
                            BlogId = blog.Id,
                            BlogName = blog.Url,
                            Posts = posts.ToList(),
                        }
                )
                .ToList();
            // Tracking vs Non Tracking
            // Tracking (default) — EF watches changes, slower for read-only
            var tracedPost = _context.Posts.First(p => p.Id == 1);
            post.Title = "Updated";
            _context.SaveChanges(); // EF detects change automatically

            // NoTracking — faster for read-only queries
            var nonTracedPosts = _context.Posts.AsNoTracking().ToList();
            // Eager Loading — loads Blog with Posts in one query (Bad Performance)
            var EagerLoaded = _context.Posts.Include(p => p.Blog).ToList();

            // Explicit Loading — load related data on demand
            var ExplicitlyLoaded = _context.Posts.First(p => p.Id == 1);
            _context.Entry(post).Reference(p => p.Blog).Load();

            // Lazy Loading — loads automatically when accessed (needs proxies)
            // Install: Microsoft.EntityFrameworkCore.Proxies
            // options.UseLazyLoadingProxies();
            // Then just access: post.Blog.Name (loads automatically)

            // Split Queries — avoids cartesian explosion on multiple Includes
            var blogs = _context.Blogs.Include(b => b.Posts).AsSplitQuery().ToList();

            /*// Select with raw SQL (Do Not Use it )
                var posts = context.Posts
                    .FromSqlRaw("SELECT * FROM Posts WHERE BlogId = {0}", 1)
                    .ToList();
                
                // With stored procedure
                var posts = context.Posts
                    .FromSqlRaw("EXEC GetPostsByBlog @BlogId = {0}", 1)
                    .ToList();
                
                // Execute non-query (INSERT/UPDATE/DELETE)
                context.Database.ExecuteSqlRaw(
                    "UPDATE Posts SET Title = {0} WHERE Id = {1}", "New Title", 1);*/

            // // Define filter (e.g. soft delete) (Global Query Filter)
            // modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);
            //
            // // All queries now automatically exclude deleted posts
            // var posts = context.Posts.ToList(); // WHERE IsDeleted = 0
            //
            // // Bypass filter when needed
            // var allPosts = context.Posts.IgnoreQueryFilters().ToList();

            /*// Add single
            context.Posts.Add(new Post { Title = "New Post", Content = "...", BlogId = 1 });
            context.SaveChanges();
            
            // Add with related data
            var blog = new Blog
            {
                Name = "New Blog",
                Posts = new List<Post>
                {
                    new Post { Title = "Post 1", Content = "..." },
                    new Post { Title = "Post 2", Content = "..." }
                }
            };
            context.Blogs.Add(blog);
            context.SaveChanges();
            
            // Update
            var post = context.Posts.Find(1);
            post.Title = "Updated Title";
            context.SaveChanges();
            
            // Remove
            var post = context.Posts.Find(1);
            context.Posts.Remove(post);
            context.SaveChanges();
            
            // Delete related data (cascade)
            var blog = context.Blogs.Include(b => b.Posts).First(b => b.Id == 1);
            context.Blogs.Remove(blog); // removes blog + all its posts
            context.SaveChanges();*/

            /* Transactions
             *using var transaction = context.Database.BeginTransaction();
                try
                {
                    context.Posts.Add(new Post { Title = "Post 1", Content = "...", BlogId = 1 });
                    context.SaveChanges();
                
                    context.Posts.Add(new Post { Title = "Post 2", Content = "...", BlogId = 1 });
                    context.SaveChanges();
                
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
             *
             */

            // Bulk Delete
            _context.Posts.Where(p => p.BlogId == 1).ExecuteDelete();

            // Bulk Update
            _context
                .Posts.Where(p => p.BlogId == 1)
                .ExecuteUpdate(s => s.SetProperty(p => p.Title, p => p.Title + " [archived]"));

            // Append and prepend → it is only cliend side not saved in the server
            var pinnedPost = new Post
            {
                Id = 0,
                Title = " Start Here",
                Content = "Welcome!",
                BlogId = 1,
            };

            var feed = _context
                .Posts.Where(p => p.BlogId == 1)
                .OrderBy(p => p.Id)
                .Prepend(pinnedPost) // always first
                .ToList();

            // Count , Average , Some
            int total = _context.Posts.Count(); // number of rows
            // Posts in Blog 1
            int blog1Count = _context.Posts.Count(p => p.BlogId == 1);
            // result: 3

            // Total views across all posts (Sum)
            // int totalViews = _context.Posts.Sum(p => p.Views);

            // Average views across all posts
            // double avgViews = _context.Posts.Average(p => p.Views);

            // _context.Blogs.Add(new Blog() { AddedOn = DateTime.Now, Url = "test.com" });
            // _context.SaveChanges();

            // var order = new Order { Amount = 50 };
            // _context.Orders.Add(order);
            //
            // var order2 = new OrderTest { Amount = 50 };
            // _context.OrderTests.Add(order2);
            // _context.SaveChanges();
        }
    }
}
