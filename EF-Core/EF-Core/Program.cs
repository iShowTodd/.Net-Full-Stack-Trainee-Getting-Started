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
