namespace NullableValueTypes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int mark1 = 15;
            int mark2 = default; // 0

            Nullable<int> mark3 = default; // Default here is null

            if (mark3 is null)
            {
                Console.WriteLine("Mark is not available");
            }
            else
            {
                Console.WriteLine($"mark3 = {mark3}");
            }

            int? mark4 = default; // Null similar to Nullable<int>

            if (!mark4.HasValue)
            {
                Console.WriteLine("Mark is not available");
            }
            else
            {
                Console.WriteLine($"mark4 = {mark4}");
            }

            Nullable<int> mark5 = default; // null
            Console.WriteLine($"mark5 = {(mark5.HasValue ? mark5 : "null")}");

            Nullable<int> mark6 = new Nullable<int>(); // null
            Console.WriteLine($"mark6 = {(mark6.HasValue ? mark6 : "null")}");

            int? mark7 = default(int?); // null
            Console.WriteLine($"mark7 = {(mark7.HasValue ? mark7 : "null")}");

            Nullable<int> mark8 = new(); // 0
            Console.WriteLine($"mark8 = {(mark8.HasValue ? mark8 : "null")}");
        }
    }
}