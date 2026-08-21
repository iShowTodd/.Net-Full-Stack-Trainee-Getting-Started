

namespace LINQ1
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public double Rating { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime AddedDate { get; set; }
    public string Supplier { get; set; }

    public override string ToString() =>
        $"[{Id}] {Name} | {Category} | ${Price:F2} | Stock: {Stock} | Rating: {Rating} | Available: {IsAvailable}";
  }
}