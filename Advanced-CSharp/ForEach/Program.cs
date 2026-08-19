namespace ForEach
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("\n\n Using For");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($" {numbers[i]}");
            }

            Console.WriteLine("\n\n Using Foreach");
            foreach (var n in numbers)
            {
                Console.Write($" {n}");
            }

            ForEach(numbers);
        }

        private static void ForEach<T>(IEnumerable<T> source)
        {
            IEnumerator<T> enumerator = source.GetEnumerator();
            IDisposable disposable;
            try
            {
                T item;
                while (enumerator.MoveNext())
                {
                    item = enumerator.Current;
                    Console.Write($" {item}");
                }
            }
            finally
            {
                disposable = enumerator;
                disposable.Dispose();
            }
        }
    }
}