

namespace FieldAndConstant
{

  internal class Program
  {

    static void Main(string[] args)
    {

      const double TAX = 0.03;


      //!! This is the old school way

      // First Employee
      Console.Write("First name : ");
      var fName = Console.ReadLine();

      Console.Write("Last name : ");
      var lName = Console.ReadLine();

      Console.Write("Wage : ");
      var wage = Double.Parse(Console.ReadLine());

      Console.Write("Logged Hour : ");
      var loggedHours = Double.Parse(Console.ReadLine());

      var netSalary = loggedHours * wage - (wage * loggedHours * TAX);

      Console.WriteLine($"First Name : {fName}");
      Console.WriteLine($"Last Name : {lName}");
      Console.WriteLine($"Wage : {wage}");
      Console.WriteLine($"Logged Hours : {loggedHours}");
      Console.WriteLine($"Net Salary : {netSalary}");


      // Second Employee
      Console.WriteLine("\n--- Second Employee ---");

      Console.Write("First name : ");
      var fName2 = Console.ReadLine();

      Console.Write("Last name : ");
      var lName2 = Console.ReadLine();

      Console.Write("Wage : ");
      var wage2 = Double.Parse(Console.ReadLine());

      Console.Write("Logged Hour : ");
      var loggedHours2 = Double.Parse(Console.ReadLine());

      var netSalary2 = loggedHours2 * wage2 - (wage2 * loggedHours2 * TAX);

      Console.WriteLine($"First Name : {fName2}");
      Console.WriteLine($"Last Name : {lName2}");
      Console.WriteLine($"Wage : {wage2}");
      Console.WriteLine($"Logged Hours : {loggedHours2}");
      Console.WriteLine($"Net Salary : {netSalary2}");


      // The Second way 

      // Object (instance) Syntax
      // Declaration <Type> <ObjectName>
      // Assignment <ObjectName> = new <Type>();
      // Initialization <Type> <ObjectName> = new <Type>();

      //----- First Employee

      Console.WriteLine("\n*********************** ");

      Console.WriteLine("\nFirst Employee");

      Employee[] emp = new Employee[2];

      Employee e1 = new Employee();
      Console.Write("First Name: ");
      e1.FName = Console.ReadLine();

      Console.Write("Last Name: ");
      e1.LName = Console.ReadLine();

      Console.Write("Wage: ");
      e1.Wage = Convert.ToDouble(Console.ReadLine());

      Console.Write("LoggedHours: ");
      e1.LoggedHours = Convert.ToDouble(Console.ReadLine());
      emp[0] = e1;

      //----- Second Employee

      Console.WriteLine("\nSecond Employee");

      Employee e2 = new Employee();
      Console.Write("First Name: ");
      e2.FName = Console.ReadLine();

      Console.Write("Last Name: ");
      e2.LName = Console.ReadLine();

      Console.Write("Wage: ");
      e2.Wage = Convert.ToDouble(Console.ReadLine());

      Console.Write("LoggedHours: ");
      e2.LoggedHours = Convert.ToDouble(Console.ReadLine());
      emp[1] = e2;

      foreach (var e in emp)
      {
        var employeeNetSalary = e.Wage * e.LoggedHours - (e.Wage * e.LoggedHours * Employee.TAX);
        Console.WriteLine($"-------------");

        Console.WriteLine($"First Name :{e.FName}");
        Console.WriteLine($"Last Name :{e.LName}");
        Console.WriteLine($"Wage :{e.Wage}");
        Console.WriteLine($"Logged Hours :{e.LoggedHours}");
        Console.WriteLine($"Net Salary :{employeeNetSalary}");
        Console.WriteLine($"-------------");
      }


    }
  }
}