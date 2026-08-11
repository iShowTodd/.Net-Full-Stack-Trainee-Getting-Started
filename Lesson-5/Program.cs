

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


      var mark1 = 55;
      if (mark1 >= 60)
      {
        Console.WriteLine("pass");
      }
      else if (mark1 >= 55)
      {
        Console.WriteLine("you have a chance in a make up exam");
      }
      else
      {
        Console.WriteLine("fail");
      }

      var amountJOD = 100;
      var currType = "USD";
      var output = 0d;

      var JODTOUSD = 1.41d;
      var JODTOEUR = 1.19d;
      var JODTOCAD = 1.78d;

      switch (currType)
      {
        case "USD":
          output = amountJOD * JODTOUSD;
          Console.WriteLine($"{amountJOD} JOD  = {output} USD");
          break;
        case "CAD":
          output = amountJOD * JODTOCAD;
          Console.WriteLine($"{amountJOD} JOD  = {output} CAD");
          break;
        case "EUR":
          output = amountJOD * JODTOEUR;
          Console.WriteLine($"{amountJOD} JOD  = {output} EUR");
          break;
        default:
          Console.WriteLine("UNKNOWN CURRENCY TYPE");
          break;
      }

      var num = 3;
      switch (num)
      {
        case 1:
        case 3:
        case 5:
        case 7:
          Console.WriteLine("odd");
          break;
        case 2:
        case 4:
        case 6:
        case 8:
          Console.WriteLine("even");
          break;
      }

      object o1 = 3;
      switch (o1)
      {
        case int i:
          Console.WriteLine($"this {i} is int");
          break;
        case string i:
          Console.WriteLine($"this {i} is string");
          break;
      }

      bool isVIP = true;
      switch (isVIP)
      {
        case bool i when i == true:
          Console.WriteLine("yes");
          break;

        case bool i:
          Console.WriteLine("no");
          break;
      }

      // .net8 switch
      var cardNo = 13;
      var cardName = cardNo switch
      {
        1 => "ACE",
        13 => "KING",
        12 => "QUEEN",
        11 => "JACK",
        _ => cardNo.ToString()
      };
      Console.WriteLine(cardName);

      //Iterations while, do while, for, foreach
      //1. while
      var counter = 0;
      while (counter < 10)
      {
        Console.Write(counter + " ");
        ++counter;
      }
      counter = 0;
      Console.WriteLine();
      //2.do while

      do
      {
        Console.Write(counter + " ");
        ++counter;
      } while (counter < 10);

      Console.WriteLine();
      //3. for

      for (var count = 0; count < 10; count++)
      {
        Console.Write(count + " ");
      }

      Console.WriteLine();

      //Fibonacci [0,1,1,2,3,5,8,13,21,34]

      for (int count = 0, prev = 0, current = 1; count < 10; ++count)
      {
        Console.Write(prev + " ");
        int newFib = prev + current;
        prev = current;
        current = newFib;
      }

      // for(; ; )     // infinite loop      
      //  {
      //    Console.WriteLine("");
      //  }
      Console.WriteLine();

      //4. foreach

      foreach (char c in "Full stack Devoloper course")
      {
        Console.Write(c + " ");
      }

      Console.WriteLine();

      var arr = new int[] { 1, 2, 3 };
      foreach (int i in arr)
      {
        Console.Write(i + " ");
      }

      // =
      Console.WriteLine();
      for (int i = 0; i < arr.Length; i++)
      {
        Console.Write(arr[i] + " ");
      }
      Console.WriteLine();

      // Jump statement [break, continue, goto, return]

      //1. break

      var j = 0;
      while (j < 10)
      {
        if (j > 5)
          break;
        Console.Write(j + " ");
        ++j;
      }
      Console.WriteLine();
      //2. continue

      for (int i = 0; i < 10; ++i)
      {
        if (i % 2 == 0)
          continue;
        Console.Write(i + " ");
      }

      Console.WriteLine();
      //3. goto

      var u = 0;
    start:
      if (u < 5)
      {
        Console.Write(u + " ");
        ++u;
        goto start;
      }

      Console.WriteLine();

      //4. return

      var input = .44m;
      var result = AsPercentage(input);
      Console.WriteLine(result);

    }
    static decimal AsPercentage(decimal amount)
    {
      return amount * 100;
    }
  }
}