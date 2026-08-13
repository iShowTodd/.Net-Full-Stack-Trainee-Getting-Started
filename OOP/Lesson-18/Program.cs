

namespace Enums
{

  internal class Program
  {

    static void Main(string[] args)
    {

      Console.WriteLine(Month.APR); // APR
      Console.WriteLine((int)Month.APR); // 4


      var day = (Day.SATURDAY | Day.SUNDAY);
      if (day.HasFlag(Day.WEEKEND))
      {
        Console.WriteLine("Enjoy your Weekend");
      }

      // Enum parsing 

      var day2 = "FEB"; // if feb it will get an exception (case sensitive)

      Console.WriteLine(Enum.Parse(typeof(Month), day2));


      var day3 = "feb";

      if (Enum.TryParse(day3, out Month month))
      {
        Console.WriteLine(month);
      }
      else
      {
        Console.WriteLine("invalid entry");
      }

      if (Enum.IsDefined(typeof(Month), day3))
      {
        Console.WriteLine(Enum.Parse(typeof(Month), day3));
      }
      else
      {
        Console.WriteLine("invalid entry");

      }

      foreach (var m in Enum.GetNames(typeof(Month)))
      {
        Console.WriteLine($"{m} = {(long)Enum.Parse(typeof(Month), m)}");
      }

      foreach (var m in Enum.GetValues(typeof(Month)))
      {
        Console.WriteLine($"{m.ToString()} = {(long)m}");
      }

    }

    enum Month : long // Default : int  (string is not accepted)
    {
      JAN = 1, // 0 → Default
      FEB, // 1 
      MAR, // 2 
      APR,
      MAY,
      JUN,
      JUL,
      AUG,
      SEP,
      OCT,
      NOV,
      DEC
    }


    // Flag Enums (yes, no)
    [Flags]
    enum Day
    {
      NONE = 0b_000_0000, // 0
      MONDAY = 0b_000_0001, // 1 
      TUESDAY = 0b_000_0010, // 2 
      WEDNESDAY = 0b_000_0100, // 4 
      THURSDAY = 0b_000_1000, // 8 
      FRIDAY = 0b_001_0000, // 16
      SATURDAY = 0b_010_0000, // 32
      SUNDAY = 0b_100_0000, // 64 
      WEEKEND = SATURDAY | SUNDAY, //0b_0110_0000 (OR Operation between them)
    }
  }
}