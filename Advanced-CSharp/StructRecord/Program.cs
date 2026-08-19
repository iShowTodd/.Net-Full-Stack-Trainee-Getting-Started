namespace StructRecord
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var p1 = new Point(2, 3);

            // p1.X = 10; // position readonly struct record are immutable
            Console.WriteLine(p1);

            Console.ReadKey();
        }
    }

    public readonly record struct Point(int X, int Y);

    // Postional Record are mutable
    public record struct PointV2
    {
        public int X;
        public int Y;
    }
}