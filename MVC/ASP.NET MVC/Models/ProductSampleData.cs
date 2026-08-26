namespace ASP.NET_MVC.Models
{
    public class ProductSampleData
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500, Description = "High performance laptop", Image = "laptop.jpg" },
            new Product { Id = 2, Name = "Phone", Price = 800, Description = "Latest smartphone", Image = "phone.jpg" },
            new Product { Id = 3, Name = "Tablet", Price = 600, Description = "Portable tablet", Image = "tablet.jpg" },
            new Product { Id = 4, Name = "Monitor", Price = 400, Description = "4K display monitor", Image = "monitor.jpg" },
            new Product { Id = 5, Name = "Keyboard", Price = 100, Description = "Mechanical keyboard", Image = "keyboard.jpg" },
        };
    }
}