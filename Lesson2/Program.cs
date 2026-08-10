namespace Lesson2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 1) Declaration [<Data Type> <Identifier> ;]
            int num;

            // 2) Assignment [<Identifier> = <Value> ;]
            num = 5;

            // 3) Initialization [ <Data Type> <Identifier> = <Initial Value> ; ]
            int num2 = 10;

            // String reference

            string s1 = "Ahmed";
            string s2 = "Arafa";

            // Sring concatination

            string s3 = s1 + ' ' + s2;

            Console.WriteLine(s3);

            // String Interpolation

            string s4 = $"{s1} {s2}";

            Console.WriteLine(s4);

            // The limit for each numerical data type
            Console.WriteLine($"byte    → Min: {byte.MinValue} → Max: {byte.MaxValue}");
            Console.WriteLine($"sbyte   → Min: {sbyte.MinValue} → Max: {sbyte.MaxValue}");
            Console.WriteLine($"short   → Min: {short.MinValue} → Max: {short.MaxValue}");
            Console.WriteLine($"ushort  → Min: {ushort.MinValue} → Max: {ushort.MaxValue}");
            Console.WriteLine($"int     → Min: {int.MinValue} → Max: {int.MaxValue}");
            Console.WriteLine($"uint    → Min: {uint.MinValue} → Max: {uint.MaxValue}");
            Console.WriteLine($"long    → Min: {long.MinValue} → Max: {long.MaxValue}");
            Console.WriteLine($"ulong   → Min: {ulong.MinValue} → Max: {ulong.MaxValue}");
            Console.WriteLine($"float   → Min: {float.MinValue} → Max: {float.MaxValue}");
            Console.WriteLine($"double  → Min: {double.MinValue} → Max: {double.MaxValue}");
            Console.WriteLine($"decimal → Min: {decimal.MinValue} → Max: {decimal.MaxValue}");

            // Var Keyword vs Dynamic Keyword

            // the compiler determines the type at compile time.
            var s5 = "Ahmed";

            // Suffix literal
            var f = 0f; // float
            var m = 0m; // decimal
            var d = 0d; // double
            var u = 0u; // unsigned int
            var l = 0l; // long
            var ul = 0ul; // unsigned long

            // Digit Separator
            int oneMilion = 1_000_000;
            Console.WriteLine(oneMilion);

            var result = 200 / 3.0; // i will evaluate the result on the right and make it defined as an example double on the left
                                    // , it is already determined as double by default
            Console.WriteLine(result);
            // Dynamic
            // Unlike var, dynamic allows the variable to hold different types during runtime.
            dynamic x = 9;
            x = "abc";
            x = 10m;
            Console.WriteLine(x);
        }
    }
}