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
