

using System.IO.Compression;

namespace DelegateAndListTask
{



  internal class Program
  {
    static void Main(string[] args)
    {
      var employeeManager = new GenericListManager<Employee>();

      employeeManager.Add(new Employee { Id = 1, Name = "Ahmed", Salary = 8000 });
      employeeManager.Add(new Employee { Id = 2, Name = "Sara", Salary = 12000 });

      Employee? employee = employeeManager.Find(e => e.Id == 1);
      List<Employee> highSalaryEmployees = employeeManager.Where(e => e.Salary > 10000);

      employeeManager.Edit(
          e => e.Id == 1,
          new Employee { Id = 1, Name = "Ahmed Ali", Salary = 9000 }
      );

      employeeManager.Delete(e => e.Id == 2);

      Console.WriteLine(employeeManager.GetCount());
      Console.WriteLine(employeeManager.GetLastCreatedAt());
      Console.WriteLine(employeeManager.GetLastSearchAt());
    }
  }



}
