
namespace Methods
{

  internal class Program
  {

    static void Main(string[] args)
    {
      Console.WriteLine("\nFirst Employee");

      Employee[] emp = new Employee[2];

      Console.Write("TAX: ");
      Employee.TAX = Convert.ToDouble(Console.ReadLine());

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

      //   foreach (Employee e in emp)
      //   {
      //       var salary = e.Wage * e.LoggedHours;
      //       var taxAmount = salary * Employee.TAX;
      //       var netSalary = salary - (salary * Employee.TAX);

      //       Console.WriteLine($"-------------");

      //       Console.WriteLine($"\nFirst Name :{e.FName}");
      //       Console.WriteLine($"Last Name :{e.LName}");
      //       Console.WriteLine($"Wage :{e.Wage}");
      //       Console.WriteLine($"Logged Hours :{e.LoggedHours}");
      //       Console.WriteLine("=================");
      //       Console.WriteLine($"Salary :{salary}");
      //       Console.WriteLine($"Deductable Tax {Employee.TAX * 100}% Amount :${taxAmount}");

      //    Console.WriteLine($"Net Salary :{netSalary}\n");
      //  }

      // ======= Refactor salary slip application  ======

      foreach (Employee e in emp)
      {
        Console.WriteLine(e.PrintSlip());
      }
      // ***************************************************************
      //****************************************************************

      Demo d1 = new Demo();


      // Caller
      d1.DoSomething(); // void expression
      var num = d1.DoSomeThing(); // Primary expression

      var age = 18;
      d1.DoSomething(ref age); // ! Must have initial value
      Console.WriteLine(age);

      int age2;
      d1.DoSomething1(out age2);
      Console.WriteLine(age2);

      d1.Promote(100, "Cairo", "Sheraton");

    }
  }
  public class Demo
  {
    // Method Syntax simple
    //<Access Modifier>  <Data Type>/void Method Name <(Parameter List)>
    // Serie of statement

    //Callee
    public void DoSomething()
    {
      Console.WriteLine("Do Something");
    }

    public void DoSomething(ref int age)
    {
      age += 10;
    }
    public void DoSomething1(out int age2)
    {
      age2 = 18;
      age2 += 10;
    }
    public int DoSomeThing()
    {
      return 10;
    }

    //  Method Signiture  ( Name Parameter + Type + Parameter order)
    public void DoSomThing(int x, double y)
    {
      //....
    }
    public void DoSomThing(double y, int x)
    {
      //....
    }


    // Method Overloading (A common way to implementing polymorphism)
    public void Promote(double amount)
    {
      Console.WriteLine($"You got a promotion of {amount}");
    }

    public void Promote(double amount, string trip)
    {
      Console.WriteLine($"You got a promotion of {amount} and a {trip}");
    }

    public void Promote(double amount, string trip, string hotel)
    {
      Console.WriteLine($"You got a promotion of {amount} and a {trip} with {hotel}");
    }


    // Expression bodied method
    public bool IsEven(int n) => n % 2 == 0;

    // Local Method 

    // Local Method 

    public void PrintEven(int[] original)
    {
      foreach (int n in original)
      {
        if (IsEven(n))
          Console.Write(n + " ");

      }

    }

    // Static Methods

    public static void PrintOdd(int[] original)
    {
      foreach (var n in original)
      {
        if (IsOdd(n))
        {
          Console.WriteLine(n);
        }
      }
    }

    public static bool IsOdd(int num) => num % 2 != 0;


  }
}