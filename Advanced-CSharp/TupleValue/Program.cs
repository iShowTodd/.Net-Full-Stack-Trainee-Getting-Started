namespace TupleValue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Reference Tuple
            Tuple<string, double> t1 = new Tuple<string, double>("Hospital", 2.4);
            Console.WriteLine($"t1: {t1}");

            // Value Tuple
            ValueTuple<string, double> t2 = new ValueTuple<string, double>("Hospital", 2.4);
            Console.WriteLine($"t2: {t2}");

            // Tuple<string, string> - formatted distance
            var t3 = FacilityDistanceCalculator.CalculateFacilityDistance("Hospital");
            Console.WriteLine($"t3: {t3}");

            // ValueTuple - implicit Item1/Item2 access
            var t4 = FacilityDistanceCalculator.CalculateFacilityDistanceV2("Hospital");
            Console.WriteLine($"t4: {t4}");
            Console.WriteLine($"FacilityName: {t4.Item1}");
            Console.WriteLine($"Distance: {t4.Item2}");

            // Named ValueTuple - explicit named access
            var t5 = FacilityDistanceCalculator.CalculateFacilityDistanceV3("Hospital");
            Console.WriteLine($"t5 Name: {t5.Name}");
            Console.WriteLine($"t5 distanceInKm: {t5.distanceInKm}");

            // Deconstruction
            (string nm, double ds) = t5;
            Console.WriteLine($"name: {nm}");
            Console.WriteLine($"distance: {ds:F2} km");
        }

        public static class FacilityDistanceCalculator
        {
            private static Random random = new Random();

            // Reference Tuple with formatted string distance
            public static Tuple<string, string> CalculateFacilityDistance(string facilityName)
            {
                return Tuple.Create(facilityName, $"{random.NextDouble() * 10.0:F2} km");
            }

            // ValueTuple - implicit names (Item1, Item2)
            public static (string, double) CalculateFacilityDistanceV2(string facilityName)
            {
                return (facilityName, random.NextDouble() * 10.0);
            }

            // Named ValueTuple - explicit names
            public static (string Name, double distanceInKm) CalculateFacilityDistanceV3(string facilityName)
            {
                return (facilityName, random.NextDouble() * 10.0);
            }
        }
    }
}