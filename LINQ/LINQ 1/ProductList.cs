

namespace LINQ1
{
  public static class ProductList
  {
    public static List<Product> GetProducts() =>
    [
        new() { Id = 1,  Name = "Laptop Pro 15",       Category = "Electronics",  Price = 1299.99m, Stock = 15,  Rating = 4.7, IsAvailable = true,  AddedDate = new(2024, 1, 10),  Supplier = "TechCorp"    },
        new() { Id = 2,  Name = "Wireless Mouse",       Category = "Electronics",  Price = 29.99m,   Stock = 120, Rating = 4.2, IsAvailable = true,  AddedDate = new(2024, 2, 5),   Supplier = "TechCorp"    },
        new() { Id = 3,  Name = "USB-C Hub",            Category = "Electronics",  Price = 49.99m,   Stock = 0,   Rating = 3.8, IsAvailable = false, AddedDate = new(2024, 3, 20),  Supplier = "GadgetWorld" },
        new() { Id = 4,  Name = "Mechanical Keyboard",  Category = "Electronics",  Price = 149.99m,  Stock = 30,  Rating = 4.9, IsAvailable = true,  AddedDate = new(2024, 1, 25),  Supplier = "GadgetWorld" },
        new() { Id = 5,  Name = "4K Monitor",           Category = "Electronics",  Price = 599.99m,  Stock = 8,   Rating = 4.6, IsAvailable = true,  AddedDate = new(2023, 11, 15), Supplier = "TechCorp"    },

        new() { Id = 6,  Name = "C# in Depth",          Category = "Books",        Price = 39.99m,   Stock = 50,  Rating = 4.8, IsAvailable = true,  AddedDate = new(2024, 4, 1),   Supplier = "BookHub"     },
        new() { Id = 7,  Name = "Clean Code",           Category = "Books",        Price = 34.99m,   Stock = 75,  Rating = 4.7, IsAvailable = true,  AddedDate = new(2023, 9, 10),  Supplier = "BookHub"     },
        new() { Id = 8,  Name = "Design Patterns",      Category = "Books",        Price = 44.99m,   Stock = 0,   Rating = 4.5, IsAvailable = false, AddedDate = new(2023, 8, 22),  Supplier = "BookHub"     },
        new() { Id = 9,  Name = "The Pragmatic Programmer", Category = "Books",    Price = 37.99m,   Stock = 40,  Rating = 4.6, IsAvailable = true,  AddedDate = new(2024, 2, 14),  Supplier = "ReadMore"    },
        new() { Id = 10, Name = "Algorithms Unlocked",  Category = "Books",        Price = 29.99m,   Stock = 20,  Rating = 4.1, IsAvailable = true,  AddedDate = new(2024, 5, 3),   Supplier = "ReadMore"    },

        new() { Id = 11, Name = "Standing Desk",        Category = "Furniture",    Price = 449.99m,  Stock = 5,   Rating = 4.4, IsAvailable = true,  AddedDate = new(2024, 3, 7),   Supplier = "OfficePlus"  },
        new() { Id = 12, Name = "Ergonomic Chair",      Category = "Furniture",    Price = 299.99m,  Stock = 12,  Rating = 4.3, IsAvailable = true,  AddedDate = new(2024, 1, 18),  Supplier = "OfficePlus"  },
        new() { Id = 13, Name = "Monitor Arm",          Category = "Furniture",    Price = 79.99m,   Stock = 0,   Rating = 4.0, IsAvailable = false, AddedDate = new(2023, 12, 1),  Supplier = "OfficePlus"  },
        new() { Id = 14, Name = "Cable Management Box", Category = "Furniture",    Price = 24.99m,   Stock = 60,  Rating = 3.6, IsAvailable = true,  AddedDate = new(2024, 4, 15),  Supplier = "DeskGear"    },

        new() { Id = 15, Name = "Protein Powder 2kg",   Category = "Health",       Price = 54.99m,   Stock = 90,  Rating = 4.3, IsAvailable = true,  AddedDate = new(2024, 2, 28),  Supplier = "FitLife"     },
        new() { Id = 16, Name = "Resistance Bands Set", Category = "Health",       Price = 19.99m,   Stock = 200, Rating = 4.5, IsAvailable = true,  AddedDate = new(2024, 3, 12),  Supplier = "FitLife"     },
        new() { Id = 17, Name = "Yoga Mat",             Category = "Health",       Price = 34.99m,   Stock = 45,  Rating = 4.2, IsAvailable = true,  AddedDate = new(2023, 10, 5),  Supplier = "ZenGear"     },
        new() { Id = 18, Name = "Smart Scale",          Category = "Health",       Price = 69.99m,   Stock = 0,   Rating = 3.9, IsAvailable = false, AddedDate = new(2024, 1, 30),  Supplier = "FitLife"     },

        new() { Id = 19, Name = "Coffee Maker Pro",     Category = "Kitchen",      Price = 89.99m,   Stock = 25,  Rating = 4.6, IsAvailable = true,  AddedDate = new(2024, 4, 10),  Supplier = "HomeEssentials" },
        new() { Id = 20, Name = "Air Fryer XL",         Category = "Kitchen",      Price = 119.99m,  Stock = 18,  Rating = 4.7, IsAvailable = true,  AddedDate = new(2023, 11, 20), Supplier = "HomeEssentials" },
        new() { Id = 21, Name = "Blender Max",          Category = "Kitchen",      Price = 74.99m,   Stock = 0,   Rating = 4.0, IsAvailable = false, AddedDate = new(2024, 2, 2),   Supplier = "ChefTools"   },
        new() { Id = 22, Name = "Electric Kettle",      Category = "Kitchen",      Price = 44.99m,   Stock = 70,  Rating = 4.4, IsAvailable = true,  AddedDate = new(2024, 5, 1),   Supplier = "ChefTools"   },
    ];
  }
}