namespace Lists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var egypt = new Country { ISOCode = "EGY", Name = "Egypt" };
            var jordan = new Country { ISOCode = "JOR", Name = "Jordan" };
            var iraq = new Country { ISOCode = "IRQ", Name = "Iraq" };

            Country[] countriesArray =
            {
                egypt, jordan, iraq
            };

            List<Country> countries = new List<Country>(countriesArray);

            countries.Add(new Country { ISOCode = "BRA", Name = "Brazil" }); // O(1)
            countries.AddRange(countriesArray); // add array O(1)
            countries.Insert(0, new Country { ISOCode = "CAN", Name = "Canada" }); // O(n)
            countries.Insert(1, new Country { ISOCode = "FAR", Name = "France" }); // O(n)
            countries.InsertRange(3, countriesArray); // O(n) but for arrays

            Print(countries);

            countries.RemoveAt(4); // Remove at index
            countries.RemoveAll((country) => country.Name.EndsWith("ce")); // it takes a Predicate (Generic Delegate)
            Print(countries);
        }

        private static void Print(List<Country> countries)
        {
            foreach (var c in countries)
            {
                Console.WriteLine(c);
            }

            // Properties
            Console.WriteLine($"Count: {countries.Count}"); // actual count
            Console.WriteLine($"Capacity: {countries.Capacity}"); // initial capacity for inner data structure
                                                                  // (How much can it hold or in other word it
                                                                  // extend itself to be able to carry more )
                                                                  // it double the number of the count of the pushed elements
        }
    }

    public class Country
    {
        public string ISOCode { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                hash = (hash * 397) + ISOCode.GetHashCode();
                hash = (hash * 397) + Name.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            var country = obj as Country;
            if (country is null) // better than country == null
                return false;
            return this.Name.Equals(country.Name, StringComparison.OrdinalIgnoreCase)
                   && this.ISOCode.Equals(country.ISOCode, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{Name} ({ISOCode})"; // Egypt (EGY)
        }
    }
}