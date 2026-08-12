
namespace Constructors
{
  public class Employee
  {
    private static double TAX;

    private string fName;
    private string lName;
    private double wage;
    private double loggedHours;

    // Runs once before first use of Employee class
    static Employee()
    {
      TAX = 0.03;
    }

    public Employee()
    {
      fName = "Ahmed";
      lName = "Arafa";
      wage = 0;
      loggedHours = 0;
    }

    // public Employee(string fName, string lName, double wage, double loggedHours)
    // {
    //   this.fName = fName;
    //   this.lName = lName;
    //   this.wage = wage;
    //   this.loggedHours = loggedHours;
    // }


    // Private Constructor
    private Employee(string fName, string lName, double wage, double loggedHours)
    {
      this.fName = fName;
      this.lName = lName;
      this.wage = wage;
      this.loggedHours = loggedHours;
    }

    public static Employee Create(string fName, string lName, double wage, double loggedHours)
    {
      return new Employee(fName, lName, wage, loggedHours);
    }


    // Overloaded Constructor
    // Name only — wage and hours default to 0
    public Employee(string fName, string lName)
    {
      this.fName = fName;
      this.lName = lName;
      this.wage = 0;
      this.loggedHours = 0;
    }

    // Constructor Chaining 
    // Wage provided — hours default to 0, delegates to full constructor
    public Employee(string fName, string lName, double wage)
        : this(fName, lName, wage, 0)
    {
    }

    // Copy Constructor
    public Employee(Employee other)
    {
      this.fName = other.fName;
      this.lName = other.lName;
      this.wage = other.wage;
      this.loggedHours = other.loggedHours;
    }

    public string PrintSlip()
    {
      double salary = wage * loggedHours;
      double taxAmount = salary * TAX;
      double netSalary = salary - taxAmount;
      return $"Name: {fName} {lName} | Wage: {wage} | Hours: {loggedHours} | Tax: {taxAmount:F2} | Net: {netSalary:F2}";
    }
  }

  internal class Program
  {
    static void Main(string[] args)
    {
      Employee e1 = new Employee();
      // Console.WriteLine($"{e1.fName} {e1.lName}, Wage: {e1.wage}");



      // Private
      Employee e2 = Employee.Create("Ahmed", "Arafa", 50.0, 160);
      Console.WriteLine(e2.PrintSlip());



      // Overloaded
      Employee e3 = new Employee("Sara", "Ali");
      // Console.WriteLine($"{e3.FName} {e3.LName}, Wage: {e3.Wage}, Hours: {e3.LoggedHours}");





      //Chaining 
      Employee e4 = new Employee("Omar", "Hassan", 40.0);
      // Console.WriteLine($"{e4.FName} {e4.LName}, Wage: {e4.Wage}, Hours: {e4.LoggedHours}");




      // Static
      // Console.WriteLine($"TAX rate (shared): {Employee.TAX * 100}%");
      // Employee.TAX = 0.05;
      // Console.WriteLine($"TAX updated to: {Employee.TAX * 100}%");
      // Console.WriteLine(e2.PrintSlip());






      //Copy
      // Employee e5 = new Employee(e2);
      // e5.FName = "Khaled";
      // e5.Wage = 70.0;
      // Console.WriteLine($"Original → {e2.FName}, Wage: {e2.Wage}");
      // Console.WriteLine($"Copy     → {e5.FName}, Wage: {e5.Wage}");

      Console.ReadKey();
    }
  }
}