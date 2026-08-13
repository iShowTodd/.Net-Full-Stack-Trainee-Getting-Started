namespace Debugging
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // 1. Syntax Error

            // int x = 0;

            // while (x <= 10)
            // {
            //     Console.WriteLine(x);
            //     x++;
            // }

            // 2. Runtime Error → Solved with Try / Catch or tryparse in term of casting

            int amount = 1000;
            int members = 4;

            // members becomes 0
            members -= 2;

            // Runtime error:
            // System.DivideByZeroException
            Console.WriteLine(Distribute(amount, members));

            // RunTime Error
            var f = ConvertCelsiusToFehrenhite(0);
            Console.WriteLine($"{0}C = {f}F");

            var c = ConvertFehrenhiteToCelsius(32);
            Console.WriteLine($"{32}F = {c}C");
        }

        public static int Distribute(int amount, int members)
        {
            try
            {
                return amount / members;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("This is finally");
            }
            return 0;
        }

        private static decimal ConvertCelsiusToFehrenhite(decimal celsius)
        {
            var fehrenhite = 0m;
            fehrenhite = (celsius * 9 / 5) + 32;
            return fehrenhite;
        }

        private static decimal ConvertFehrenhiteToCelsius(decimal fehrenhite)
        {
            var celsius = 0m;
            // celsius = fehrenhite - 32 * 5 / 9;  // via step into (Go inside) // Step out means go out of block
            // Now it is fixed
            celsius = (fehrenhite - 32) * 5 / 9;
            return celsius;
        }
    }
}