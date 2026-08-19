namespace NullableAndGenerics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        private static T? DoSomething<T>(T source)
        {
            return source;
        }
    }
}