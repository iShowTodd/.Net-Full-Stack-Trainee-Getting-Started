using Ahmed.Sales;
using CRAC = Continent.Region.Area.Country;
using EGY = Continent.Region.Area.Country.Egypt;

namespace Namespaces
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Metigator");
            Ahmed.HR.Employee emp = new Ahmed.HR.Employee();
            Customer customer = new Customer();
            CRAC.Egypt egy = new CRAC.Egypt();
            EGY egy1 = new EGY();
            Console.WriteLine(System.Math.Cos(45));
            Console.WriteLine(Cos(45));
            Console.ReadKey();
        }
    }
}