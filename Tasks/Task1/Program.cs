

namespace EnumTask
{

  internal class Program
  {
    enum DayEnum
    {
      SAT = 1,
      SUN = 2,
      MON = 3,
      TUES = 4,
      WED = 5,
      THURS = 6,
      FRI = 7
    }

    static string GetDayName(DayEnum day)
    {
      string dayName = day switch
      {
        DayEnum.SAT => "Satruday",
        DayEnum.SUN => "Sunday",
        DayEnum.MON => "Monday",
        DayEnum.TUES => "Tuesday",
        DayEnum.WED => "Wednesday",
        DayEnum.THURS => "Thursday",
        DayEnum.FRI => "Friday",
        _ => "This is an unknown info"
      };
      return dayName;
    }


    static void Main(string[] args)
    {

      foreach (var day in Enum.GetValues<DayEnum>())
      {
        Console.WriteLine(GetDayName(day));
      }

    }
  }
}