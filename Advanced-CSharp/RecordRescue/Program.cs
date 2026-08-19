namespace RecordRescue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var p1 = new Point(2, 3);
            var p2 = new Point(2, 3);

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
            Console.WriteLine($"(p1 == p2): {p1 == p2}");
        }
    }

    internal record Point
    {
        // override object equal
        // implement IEquatable <Point>
        // override object GetHashCode
        // override ==, !=
        // override ToString();
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}