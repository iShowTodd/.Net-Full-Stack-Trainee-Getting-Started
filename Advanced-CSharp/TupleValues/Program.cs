namespace TupleValues
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Tuple<string, double> t1 = new Tuple<string, double>("Hospital", 2.4);
            Console.WriteLine($"t1: {t1}");

            ValueTuple<string, double> t2 = new ValueTuple<string, double>("Hospital", 2.4);
            Console.WriteLine($"t2: {t2}");

            var t3 = FacilityDistanceCalculator.CalculateFacilityDistance("Hospital");
            Console.WriteLine($"t3: {t3}");

            var t4 = FacilityDistanceCalculator.CalculateFacilityDistanceV2("Hospital");
            Console.WriteLine($"t4: {t4}");
            Console.WriteLine($"FacilityName: {t4.Item1}");

            var t5 = FacilityDistanceCalculator.CalculateFacilityDistanceV3("Hospital");
            Console.WriteLine($"t5: {t5.Name}");
            Console.WriteLine($"t5: {t5.distanceInKm}");

            (string nm, string ds) = t5;

            Console.WriteLine($"name: {nm}");
            Console.WriteLine($"distance: {ds} km");
        }
    }

    public static class FacilityDistanceCalculator
    {
        private static Random random = new Random();

        // ValueTuple.Create
        public static ValueTuple<string, string> CalculateFacilityDistance(string facilityName)
        {
            return ValueTuple.Create(facilityName, $"{random.NextDouble() * 10.0:F2} km");
        }

        // Implicit Names
        public static (string, string) CalculateFacilityDistanceV2(string facilityName)
        {
            return ValueTuple.Create(facilityName, $"{random.NextDouble() * 10.0:F2} km");
        }

        // Explicit Names
        public static (string Name, string distanceInKm) CalculateFacilityDistanceV3(string facilityName)
        {
            return ValueTuple.Create(facilityName, $"{random.NextDouble() * 10.0:F2} km");
        }
    }
}