


namespace AfterDelegate
{

  internal class Program
  {
    static void Main(string[] args)
    {
      var emps = new Employee[]
               {
                new Employee { Id = 1, Name = "Issam A", TotalSales = 65000m, Gender = "M"} ,
                new Employee { Id = 2, Name = "Reem S", TotalSales = 50000m, Gender = "F"} ,
                new Employee { Id = 3, Name = "Suzan B", TotalSales = 65000m, Gender = "F"} ,
                new Employee { Id = 4, Name = "Sara A", TotalSales = 40000m, Gender = "F"} ,
                new Employee { Id = 5, Name = "Salah S", TotalSales = 42000m, Gender = "M"} ,
                new Employee { Id = 6, Name = "Rateb A", TotalSales = 30000m, Gender = "M"} ,
                new Employee { Id = 7, Name = "Abeer C", TotalSales = 16000m, Gender = "F"} ,
                new Employee { Id = 8, Name = "Marwan M", TotalSales = 15000m, Gender = "M"} ,

               };

      // After Using  delegate

      Report report = new Report();


      Console.WriteLine("\n================ After Using Delegate ================\n");


      report.ProcessEmployee(emps, "Employees with Sales $60,000+ ", IsGreaterThanOrEqual60000);
      report.ProcessEmployee(emps, "Employees With Sales Between $30000 And $59999", IsBetween60000And30000);
      report.ProcessEmployee(emps, "Employees With Sales less than $30000  ", IsLessThan30000);

      Console.WriteLine("\n================ Using Annonymous Delegate ================\n");

      report.ProcessEmployee(emps, "Employees with Sales $60,000+ ", delegate (Employee e) { return e.TotalSales >= 60000; });

      report.ProcessEmployee(emps, "Employees With Sales Between $30000 And $59999", delegate (Employee e) { return e.TotalSales < 60000 && e.TotalSales >= 30000; });

      report.ProcessEmployee(emps, "Employees With Sales less than $30000  ", delegate (Employee e) { return e.TotalSales < 30000; });

      Console.WriteLine("\n================ Using Lambda Expression ================\n");
      report.ProcessEmployee(emps, "Employees with Sales $60,000+ ", (Employee e) => e.TotalSales >= 60000);
      report.ProcessEmployee(emps, "Employees With Sales Between $30000 And $59999", (Employee e) => e.TotalSales < 60000 && e.TotalSales >= 30000);
      report.ProcessEmployee(emps, "Employees With Sales less than $30000  ", e => e.TotalSales < 30000);


    }
    static bool IsGreaterThanOrEqual60000(Employee e) => e.TotalSales >= 60000;
    static bool IsBetween60000And30000(Employee e) => e.TotalSales < 60000 && e.TotalSales >= 30000;
    static bool IsLessThan30000(Employee e) => e.TotalSales < 30000;
  }
}