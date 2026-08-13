


using System.Reflection.Metadata.Ecma335;

namespace GenericDelegate
{

  internal class Program
  {
    // public delegate T2 Filter<in T, out T2>(T n);

    public delegate bool Filter<T>(T value);


    static void Main(string[] args)
    {
      IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

      Console.WriteLine("Even numbers:");
      PrintNumber(numbers, n => n % 2 == 0);

      Console.WriteLine("Numbers greater than 5:");
      PrintNumber(numbers, n => n > 5);

      Console.WriteLine("Odd numbers:");
      PrintNumber(numbers, n => n % 2 != 0);


      //============================================

      Action action = Print;
      action();

      Action<string> action1 = Print;
      action1("Ahmed");

      Func<int, int, int> func = Add; // 2 int for input and one int for output
      Console.WriteLine(func(1, 2));


      Predicate<int> predicate = IsEven;

      Console.WriteLine(predicate(2));


    }

    // static void PrintNumber<T>(IEnumerable<T> numbers, Predicate<T> filter) // yes i can you it here too
    // {
    //   foreach (var n in numbers)
    //   {
    //     if (filter(n))
    //       Console.WriteLine(n);
    //   }
    // }
    static void PrintNumber<T>(IEnumerable<T> numbers, Filter<T> filter)
    {
      foreach (var n in numbers)
      {
        if (filter(n))
          Console.WriteLine(n);
      }
    }
    // static void PrintNumber<T, T2>(IEnumerable<T> numbers, Filter<T, T2> filter)
    // {

    // }


    static void Print() => Console.WriteLine("Print this");
    static void Print(string name) => Console.WriteLine(name);
    static int Add(int num1, int num2) => num1 + num2;

    static bool IsEven(int num) => num % 2 == 0;

  }
}