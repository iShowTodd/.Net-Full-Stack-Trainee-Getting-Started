

namespace Arrays
{

  internal class Program
  {

    private static void Main(string[] args)
    {

      // Declaration
      string[] friends = new string[5];
      friends[0] = "Ahmed";
      friends[1] = "Ali";
      friends[2] = "Khaled";
      friends[3] = "Muhammad";
      friends[4] = "Reem";

      friends.Print();

      // Initialization
      string[] friends2 = new string[5]
      {
        "Ahmed",
        "Ali",
        "Khaled",
        "Reem",
        "Muhammad"
      };

      friends2.Print();

      string[] friends3 =
      {
        "Ahmed",
        "Ali",
        "Khaled",
        "Reem",
        "Muhammad"
      };

      friends3.Print();

      var friends4 = new string[5]
      {
        "Ahmed",
        "Ali",
        "Khaled",
        "Reem",
        "Muhammad"
      };

      friends4.Print();


      // ! Error
      // !var friends5 =
      //! {
      //!   "Ahmed",
      //!   "Ali",
      //!   "Khaled",
      //!   "Reem",
      //!   "Muhammad"
      //! };


      //2. Multi Dim. Array (rectangular array)
      int[,] suduko =
      {
                {9,6,2,1,4,7,3,7,8 },
                {1,8,5,6,7,3,4,2,9 },
                {3,7,4,2,9,8,5,6,1 },
                {5,3,1,7,6,2,9,8,4 },
                {6,9,4,3,8,1,2,5,7 },
                {8,2,7,4,5,9,6,1,3 },
                {4,9,6,5,1,7,8,3,2 },
                {2,1,8,9,3,6,7,4,5 },
                {7,5,3,8,2,4,1,9,6 }

      };



      // Jagged Array a type of multi-dimensional but better perforamnce
      var jagged = new int[][]
      {
        new int [] {1 , 2 ,3},
        new int [] {4 , 5 , 6 },
      };


      // indices and ranges
      var slice1 = friends[..2];
      var slice2 = friends[..2];
      var slice3 = friends[2..3];
      var slice4 = friends[2..^2];

      slice1.Print();
      slice2.Print();
      slice3.Print();
      slice4.Print();

      var sliceRange = 2..^2;
      var slice5 = friends[sliceRange];
      slice5.Print();
    }

  }

  public static class Extensions
  {
    public static void Print<T>(this T[] source)
    {
      if (!source.Any())
      {
        Console.WriteLine("{}");
        return;
      }
      Console.Write("{");
      for (var i = 0; i < source.Length; i++)
      {
        Console.Write($"{source[i]}");
        Console.Write(i < source.Length - 1 ? "," : "");
      }
      Console.WriteLine("}");
    }
  }
}