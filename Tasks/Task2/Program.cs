

namespace StructAndArrayTask
{


  internal class Program
  {
    static void Main(string[] args)
    {
      Employee[]? emps = new Employee[3];

      for (int i = 0; i < emps.Length; ++i)
      {
        emps[i].Id = i + 1;

        string? name = Console.ReadLine();
        if (name is not null)
        {
          emps[i].Name = name;
        }
      }

      foreach (var emp in emps)
      {
        Console.WriteLine($" Employee # {emp.Id} : id :  {emp.Id} , Name : {emp.Name}");
      }

    }
  }

  struct Employee
  {
    public int? Id { get; set; }
    public string? Name { get; set; }
  }
}