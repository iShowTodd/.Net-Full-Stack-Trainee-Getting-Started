

namespace Finalizer
{


  internal class Program
  {
    static void MakeSomeGarabge()
    {
      Version v;

      for (int i = 0; i < 1000; i++)
      {
        v = new Version();
      }
    }

    static void Main(string[] args)
    {
      var person = new Person();
      person.Name = "Ahmed";

      MakeSomeGarabge();
      Console.WriteLine($"memory used before allocation {GC.GetTotalMemory(false):N0} ");

      GC.Collect();
      Console.WriteLine($"memory used After allocation {GC.GetTotalMemory(true):N0} ");




    }
  }


  public class Person
  {
    public string Name { get; set; }

    public Person()
    {
      Console.WriteLine("This is the constructor person");
    }

    ~Person()
    {
      Console.WriteLine("This is the person finalizer");
    }
  }
}