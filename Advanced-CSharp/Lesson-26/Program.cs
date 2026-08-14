namespace ExtensionMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            DateTime saturday = new DateTime(2025, 3, 1);  // Saturday
            DateTime monday = new DateTime(2025, 3, 3);    // Monday

            // Helpers
            Console.WriteLine($"Today ({today:dddd}): Weekend? {DateTimeHelper.IsWeekEnd(today)}");
            Console.WriteLine($"Saturday: Weekend? {DateTimeHelper.IsWeekEnd(saturday)}");
            Console.WriteLine($"Monday: Weekday? {DateTimeHelper.IsWeekDay(monday)}");

            // Extension Methods

            Console.WriteLine($"Today ({today:dddd}): Weekend? {today.IsWeekEnd()}");
            Console.WriteLine($"Saturday: Weekend? {saturday.IsWeekEnd()}");
            Console.WriteLine($"Monday: Weekday? {monday.IsWeekDay()}");

            // Method chaining

            Pizza p = new Pizza();

            //p = PizzaExtensions.AddDough(PizzaExtensions.AddSauce(PizzaExtensions.AddCheeze(PizzaExtensions.AddToppings(p, "black olives", 3.5m), true)), "thin");

            p.AddDough("thin")
              .AddSauce()
              .AddCheeze(true)
              .AddToppings("black olives", 3.5m);

            Console.WriteLine(p);
        }
    }

    public static class PizzaExtensions
    {
        public static Pizza AddDough(this Pizza value, string type)
        {
            value.Content += $"\n{type} Dough X $4.00";
            value.TotalPrice += 4m;
            return value;
        }

        public static Pizza AddSauce(this Pizza value)
        {
            value.Content += $"\nTomato Sauce X $2.00";
            value.TotalPrice += 2m;
            return value;
        }

        public static Pizza AddCheeze(this Pizza value, bool extra)
        {
            value.Content += $"\n{(extra ? "extra" : "regular")} Cheeze Sauce X ${(extra ? "6.00" : "4.00")}";
            value.TotalPrice += extra ? 6m : 4m;
            return value;
        }

        public static Pizza AddToppings(this Pizza value, string type, decimal price)
        {
            value.Content += $"\n{type} X ${price:#.##}";
            value.TotalPrice += price;
            return value;
        }
    }

    public class Pizza
    {
        public string Content { get; set; }
        public decimal TotalPrice { get; set; }

        public Pizza AddSauce()
        {
            this.Content += $"\nTOMATO SAUCE X $2.00";
            this.TotalPrice += 2m;
            return this;
        }

        public override string ToString()
        {
            return $"{Content}\n-----------------------\nTotal Price: ${TotalPrice:#.##}";
        }
    }
}