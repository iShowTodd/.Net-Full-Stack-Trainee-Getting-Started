

namespace Expressions
{

  internal class Program
  {

    static void Main(string[] args)
    {
      // Expression Types
      //1. Primary Expression

      var amount = Math.Cos(30) + 1;
      Console.WriteLine(amount);  // 1,154251449887584

      //2. Void Expression

      Console.WriteLine("Issam");

      //3. Assignment statement
      var x = 2;
      var y = 5;

      // Binary Operators and precedence

      x = x + 10;            // 12
      var z = 8 / 4 / 2;     // 1
      var k = 8 / (4 / 2);   // 4
      Console.WriteLine($"{0} {1}", k, z);

      Console.WriteLine($"x + y = {x + y}");
      Console.WriteLine($"x - y = {x - y}");
      Console.WriteLine($"x / y = {x / y}");
      Console.WriteLine($"x * y = {x * y}");
      Console.WriteLine($"x % y = {x % y}");

      var s1 = "";
      var s2 = "";
      var s3 = s1 = s2 = "Issam";

      // Null Coalscing
      var s4 = s1 ?? "Ahmed";
      var s5 = s2 ?? "Arafa";

      // Null Conditional

      var s6 = s5.ToUpper();
      Console.WriteLine(s5);


      Console.WriteLine("hi");    // Statement
      {                            // Statement block
        Console.WriteLine("hi");
        Console.WriteLine("hi");
      }

      // Declaration Statement 
      int a;

      //--- Expression Statement
      var name = "Issam";

      //1. change state

      name = name + "A";

      //2. call something that change the state

      name = name.ToUpper();

      //3. Assignment

      name = name + "A";

      //4. Increment / decrement

      var totalFriends = 150;
      ++totalFriends;   // 151

      --totalFriends;   // 150

      var x1 = 2;
      Console.WriteLine(x1++);  // 2;
      Console.WriteLine(x1);  // 3;

      // 5. Object instansiation

      object o = new object();

      // if 

      var mark = 90;
      if (mark >= 85) Console.WriteLine("Excellenet");

      if (mark >= 60)
      {
        Console.WriteLine("Pass");
      }
      else
      {
        Console.WriteLine("Fail");
      }
    }

  }
}