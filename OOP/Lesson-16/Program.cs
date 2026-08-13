

using CustomLibrary;

namespace NestedTypes
{

  internal class Program
  {


    static void Main(string[] args)
    {
      Person p = new Person();
      // InternalPerson internalPerson = new InternalPerson(); Works only within the same assembly


      Employee e1 = new Employee();
      Console.WriteLine(e1.EmployeeInsurance.CompanyName);
      Console.ReadKey();
    }
  }


  // class A
  // {
  //   private int x;

  //   class B
  //   {
  //     void method()
  //     {
  //       A a = new A();
  //       // a.x  this is accessible 
  //     }
  //   }
  // }

  public class Employee
  {
    public int Id { set; get; }
    public string? Name { set; get; }

    public Employee() => EmployeeInsurance = new Insurance { PolicyId = -1, CompanyName = "N/A" };
    // Composition
    public Insurance EmployeeInsurance { get; set; }

    public class Insurance
    {
      public int PolicyId { get; set; }
      public string? CompanyName { get; set; }


    }

  }




  class Department
  {
    public int Id { set; get; }
    public string? Name { set; get; }
  }
}