


namespace AfterDelegate
{
  public class Report
  {
    public delegate bool IsElegible(Employee emp);

    public void ProcessEmployee(Employee[] emps, string title, IsElegible isElegible)
    {
      Console.WriteLine(title);
      Console.WriteLine("------------------------------");
      foreach (Employee e in emps)
      {
        if (isElegible(e))
        {
          Console.WriteLine($"{e.Id} | {e.Name} | {e.Gender} | ${e.TotalSales}");
        }
      }
    }

  }
}