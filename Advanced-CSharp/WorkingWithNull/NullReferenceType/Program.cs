namespace NullReferenceType
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string? name = null;

            string decision = IsLongName(name) ? "Long" : "Short";

            Console.WriteLine($"{name} is {decision}");
            Console.ReadKey();
        }

        private static bool IsLongName(string? name)
        {
            // avoiding null
            if (name is null)
                return false;

            return name.Length > 10; // assumption of name is not null
        }
    }
}