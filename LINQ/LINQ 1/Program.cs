

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

      #region WhereWithSelect
      var products1 = ProductList.GetProducts().Where(a => a.Stock > 0);

      var products2 = ProductList.GetProducts().Where(a => a.Stock > 0).Select(p => p.Name);

      var products3 = ProductList.GetProducts().Where(a => a.Stock > 0).Select(p => new { p.Id, p.Name, p.Category });

      var products4 = ProductList.GetProducts()
          .Where(a => a.Stock > 0)
          .Select(p => new { data = p.Id + ":" + p.Price.ToString() });

      foreach (var item in products1)
      {
        Console.WriteLine(item);
      }

      foreach (var item in products2)
      {
        Console.WriteLine(item);
      }

      foreach (var item in products3)
      {
        Console.WriteLine(item);
      }

      var products5 = from p in ProductList.GetProducts()
                      where p.Stock > 0
                      select new { p.Id, p.Name, p.Price };

      foreach (var item in products5)
      {
        Console.WriteLine(item);
      }
      #endregion

      #region  OrderBy
      var products6 = ProductList.GetProducts().Where(a => a.Stock > 0).OrderBy(a => a.Price);

      foreach (var item in products6)
      {
        Console.WriteLine(item);
      }

      var products7 = ProductList.GetProducts().Where(a => a.Stock > 0).OrderBy(a => a.Price).ThenBy(a => a.Id).Select(a => new { a.Id, a.Name, a.Price });

      foreach (var item in products7)
      {
        Console.WriteLine(item);
      }

      var products8 = from p in ProductList.GetProducts()
                      where p.Stock > 0
                      orderby p.Price descending
                      select new { p.Id, p.Name, p.Price };

      foreach (var item in products8)
      {
        Console.WriteLine(item);
      }
      #endregion

      # region IndexedWhere (can not use it in query expression) 
      var prods = ProductList.GetProducts().Where((p, i) => p.Stock > 0 && i > 10);

      foreach (var item in prods)
      {
        Console.WriteLine(item);
      }
      #endregion

      #region  IndexedSelect

      var products = ProductList.GetProducts()
      .Select((p, i) => new { Index = i, p.Name, p.Price });
      #endregion

    }
  }
}