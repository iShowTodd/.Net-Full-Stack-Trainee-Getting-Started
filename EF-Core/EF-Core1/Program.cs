using EF_Core1.Models;

namespace EF_Core1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var _context = new ApplicationDbContext();

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
