namespace RefrencingVsDerefrencing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // string is a reference type
            string str1 = default; // default in string is null
            string str2 = "Ahmed"; // Refrencing

            // Derefrencing : follow the refrence pointer  to access the underlying object
            Console.WriteLine(str2.Length);
            Console.WriteLine(str1.Length); // Null Refrence Exception

            // value type
            DateTime datetime = default; // default is '0001/01/01 00:00 AM'
            Console.WriteLine(datetime.Month);
        }
    }
}