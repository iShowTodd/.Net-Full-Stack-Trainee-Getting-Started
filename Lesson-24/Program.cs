
using System.Collections;

namespace EnumeratorsAndIterators
{

  class FiveIntegers : IEnumerable
  {
    int[] values;

    public FiveIntegers(int n1, int n2, int n3, int n4, int n5)
    {
      values = new int[] { n1, n2, n3, n4, n5 };
    }

    public IEnumerator GetEnumerator() => new Enumerator(this);

    /*

        the new way
        public IEnumerator GetEnumerator() {
          foreach(var item in values){
              yield return item;
          }
        
        }

    */

    private class Enumerator : IEnumerator
    {
      private int currentIndex = -1;
      private FiveIntegers fiveIntegers;

      public Enumerator(FiveIntegers fiveIntegers)
      {
        this.fiveIntegers = fiveIntegers;
      }

      public object Current
      {
        set
        {

        }
        get
        {
          if (currentIndex == -1) throw new InvalidOperationException("Enumeration not started");
          if (currentIndex == fiveIntegers.values.Length) throw new InvalidOperationException("Enumeration has ended");
          return fiveIntegers.values[currentIndex];
        }
      }

      public bool MoveNext()
      {
        if (currentIndex > fiveIntegers.values.Length - 1)
        {
          return false;
        }

        return ++currentIndex < fiveIntegers.values.Length;
      }

      public void Reset()
      {
        currentIndex = -1;
      }
    }
  }


  internal class Program
  {
    static void Main(string[] args)
    {

      Employee e = new Employee
      {
        Id = 1,
        Name = "Ahmed",
        Salary = 4000m,
        Department = "CS"
      };

      Employee e2 = new Employee
      {
        Id = 1,
        Name = "Ahmed",
        Salary = 4000m,
        Department = "CS"
      };
      Employee e3 = e;
      Console.WriteLine(e == e2); // False due to different refrences 
      Console.WriteLine(e3 == e); // True

      // To compare content instead of reference 

      Console.WriteLine(e.Equals(e2)); // Equals by default compare references SO WE NEED TO OVERRIDE IT 

      var ints = new FiveIntegers(1, 2, 3, 4, 5);

      foreach (int i in ints) // Must be a type of IEnumerable
      {
        Console.WriteLine(i);
      }

    }



  }

  class Employee
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Salary { get; set; }
    public string? Department { get; set; }

    public override bool Equals(Object obj)
    {
      if (obj == null || !(obj is not Employee))
      {
        return false;
      }
      var emp = obj as Employee;
      return this.Id == emp.Id && this.Name == emp.Name && this.Department == emp.Department && this.Salary == emp.Salary;
    }

    public override int GetHashCode()
    {
      int hash = 13;
      hash = (hash * 7) + Id.GetHashCode();
      hash = (hash * 7) + (Name?.GetHashCode() ?? 0);
      hash = (hash * 7) + (Department?.GetHashCode() ?? 0);
      hash = (hash * 7) + Salary.GetHashCode();
      return hash;
    }

    public static bool operator ==(Employee left, Employee right)
    {
      if (left is null && right is null) return true;
      if (left is null || right is null) return false;
      return left.Equals(right);
    }

    public static bool operator !=(Employee left, Employee right)
    {
      return !(left == right);
    }
  }

}