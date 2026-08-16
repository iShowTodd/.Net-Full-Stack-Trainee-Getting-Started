namespace Todd.NumberSystem.Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var d = new DecimalSystem("10");
            var binary = d.To(NumberBase.BINARY);
            var ocatal = d.To(NumberBase.OCTAL);
            var hexa = d.To(NumberBase.HEXADECIAML);

            Console.WriteLine($"{d} , {binary} , {ocatal} , {hexa}");
        }
    }
}