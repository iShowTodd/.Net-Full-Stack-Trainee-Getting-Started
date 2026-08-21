

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

      #region Partitioning
      var prods3 = ProductList.GetProducts().Take(5); // return first 5 elements 
      /*
          .Skip(5)                         // skip first 5
          .Take(5)                         // take only 5
          .Skip(5).Take(5)                 // paging — page 2 with page size 5
          .SkipWhile(p => p.Price < 100)   // skip while condition is true, then take the rest
          .TakeWhile(p => p.Price < 100)   // take while condition is true, stop at first false
      */
      #endregion

      #region Aggregation
      int size = ProductList.GetProducts().Count();

      /*.Count()
      .Sum(p => p.Price)
      .Min(p => p.Price)
      .Max(p => p.Price)
      .Average(p => p.Price)*/
      #endregion

      #region Single Element Operators

      var i1 = ProductList.GetProducts().First(); // can take any predicate as an argument
      var i2 = ProductList.GetProducts().Last();
      var i3 = ProductList.GetProducts().FirstOrDefault();
      var i4 = ProductList.GetProducts().Single((p => p.Rating > 4.5));

      /*
      .First(p => p.Rating > 4.5)      // throws exception if none found
      .FirstOrDefault(p => p.Rating > 4.5)  // returns null if none found
      .Single(p => p.Id == 5)          // throws if 0 or more than 1 match
      .SingleOrDefault(p => p.Id == 5)
      .Last(p => p.Stock > 0)
      */
      #endregion

      #region Set Operators
      List<string> list1 = ["TechCorp", "BookHub", "FitLife", "OfficePlus"];
      List<string> list2 = ["TechCorp", "FitLife", "ChefTools", "ReadMore"];

      // Distinct
      var distinct = ProductList.GetProducts()
          .Select(p => p.Supplier)
          .Distinct();

      // Union
      var union = list1.Union(list2);

      // Intersect
      var intersect = list1.Intersect(list2);

      // Except
      var except = list1.Except(list2);

      // Concat
      var concat = list1.Concat(list2);
      #endregion

      #region Quantifiers
      var prods2 = ProductList.GetProducts();

      // Any
      bool hasOutOfStock = prods2.Any(p => p.Stock == 0);   // true if at least one matches
      bool hasExpensive = prods2.Any(p => p.Price > 1000);  // true if at least one matches

      // All
      bool allAvailable = prods2.All(p => p.IsAvailable);   // true if every element matches
      bool allRatedAbove3 = prods2.All(p => p.Rating > 3);  // true if every element matches

      // Contains
      Product target = prods2.First(p => p.Id == 5);
      bool containsProduct = prods2.Contains(target);        // reference/value equality check
      #endregion
    }
  }
}