

namespace LINQ1
{


  internal class Program
  {

    static void Main(string[] args)
    {

      #region Where And Deferred Exectution
      List<int> l1 = new List<int> { 10, 20, 30, 40, 50 };
      var result = Enumerable.Where(l1, (x) => x > 20 && x <= 50);
      //  Where (IEnumerable<T> , Predicate)
      foreach (var value in result)
      {
        Console.WriteLine(value);
      }

      // LINQ → Deferred Exectuion + Immediate Execution
      // Another way of applying where
      var res = l1.Where(x => x > 20 && x <= 50); //LINQ is Deferred Execution means its only run with the foreach btw this signature called fluent Syntax

      var res2 = l1.Where(x => x > 20 && x <= 50).ToList(); // it will run without 100 (immediate Execution)
      res2.Add(100);

      foreach (var value in res)
      {
        Console.WriteLine(value);
      }

      var res3 = from p in l1
                 where p >= 20 && p <= 50
                 select p; // This is called Query Expression

      foreach (var value in res3)
      {
        Console.WriteLine(value);
      }

      #endregion




    }
  }
}