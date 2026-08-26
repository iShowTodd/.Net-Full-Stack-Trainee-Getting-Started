namespace ASP.NET_MVC.Models
{
    public class ProductSampleData
    {
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500, Description = "High performance laptop", Image = "laptop.jpg" },
            new Product { Id = 2, Name = "Phone", Price = 800, Description = "Latest smartphone", Image = "phone.jpg" },
            new Product { Id = 3, Name = "Tablet", Price = 600, Description = "Portable tablet", Image = "tablet.jpg" },
            new Product { Id = 4, Name = "Monitor", Price = 400, Description = "4K display monitor", Image = "monitor.jpg" },
            new Product { Id = 5, Name = "Keyboard", Price = 100, Description = "Mechanical keyboard", Image = "keyboard.jpg" },
        };

        public static List<Product> GetAll()
        {
            return Products;
        }

        public static Product GetById(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        public static void Create(Product product)
        {
            product.Id = Products.Max(p => p.Id) + 1;
            Products.Add(product);
        }

        public static void Update(int id, Product updated)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return;
            product.Name = updated.Name;
            product.Price = updated.Price;
            product.Description = updated.Description;
            product.Image = updated.Image;
        }

        public static void Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return;
            Products.Remove(product);
        }
    }
}