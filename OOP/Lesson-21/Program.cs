

namespace Generics
{


  internal class Program
  {

    static void Main(string[] args)
    {
      // var collection = new Any<int>();
      var collection = new Any<Person>();


      // collection.Add(10);
      // collection.Add(20);
      // collection.Add(30);
      // collection.Add(40);
      // collection.Add(50);

      // Console.WriteLine($"Count: {collection.Count}");
      // collection.Display();

      // collection.RemoveAt(2);
      // collection.Display();
    }

    // Generic Method
    static void Print<T>(T value)
    {

    }
  }

  // Generic Class
  class Any<T> where T : class // Generic constrains
  {
    private T[] items;

    public void Add(T item)
    {
      if (items is null)
      {
        items = new T[] { item };
      }
      else
      {
        var length = items.Length;
        var dest = new T[length + 1];
        for (int i = 0; i < items.Length; ++i)
        {
          dest[i] = items[i];
        }
        dest[dest.Length - 1] = item;
        items = dest;
      }

    }
    public void RemoveAt(int position)
    {
      if (items is null || position < 0 || position >= items.Length)
        throw new IndexOutOfRangeException($"Position {position} is out of range.");

      var dest = new T[items.Length - 1];

      for (int i = 0, j = 0; i < items.Length; i++)
      {
        if (i != position)
          dest[j++] = items[i];
      }

      items = dest;
    }

    public bool IsEmpty => items is null || items.Length == 0;
    public int Count => items is null ? 0 : items.Length;

    public void Display()
    {
      if (IsEmpty)
      {
        Console.WriteLine("Collection is empty.");
        return;
      }

      for (int i = 0; i < items.Length; i++)
        Console.WriteLine($"[{i}] {items[i]}");
    }
  }

  public class Person
  {
    private string fname;
    private string lname;

    public Person(string fname, string lname)
    {
      this.fname = fname;
      this.lname = lname;
    }
    public override string ToString()
    {
      return $"'{fname} {lname}'";
    }

  }
}