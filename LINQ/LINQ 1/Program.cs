

namespace LINQ1
{


  internal class Program
  {

    static void Main(string[] args)
    {

      #region Where
      List<int> l1 = new List<int> { 10, 20, 30, 40, 50 };
      var result = Enumerable.Where(l1, (x) => x > 20 && x <= 50);
      //  Where (IEnumerable<T> , Predicate)
      foreach (var value in result)
      {
        Console.WriteLine(value);
      }

      // LINQ → Deferred Exectuion + Immediate Execution
      // Another way of applying where
      var res = l1.Where(x => x > 20 && x <= 50); //LINQ is Deferred Execution means its only run with the foreach

      var res2 = l1.Where(x => x > 20 && x <= 50).ToList(); // it will run without 100 (immediate Execution)
      res2.Add(100);

      foreach (var value in res)
      {
        Console.WriteLine(value);
      }


      #endregion


    }
  }
}