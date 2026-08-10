
namespace BooleanTypesAndOperators
{
  internal class Program
  {

    static void Main(string[] args)
    {
      // Logical And Operator &&
      Console.WriteLine("And Operator &&");
      Console.WriteLine(true && true); //true
      Console.WriteLine(true && false); //false
      Console.WriteLine(false && true); //false
      Console.WriteLine(false && false); //false
      Console.WriteLine("\n");
      // Logical Or Operator ||
      Console.WriteLine("Or Operator ||");
      Console.WriteLine(true || true); //true
      Console.WriteLine(true || false); //true
      Console.WriteLine(false || true); //true
      Console.WriteLine(false || false); //false
      Console.WriteLine("\n");
      // XOR Operator ^
      Console.WriteLine("XOR Operator ^");
      Console.WriteLine(true ^ true); //false
      Console.WriteLine(true ^ false); //true
      Console.WriteLine(false ^ true); //true
      Console.WriteLine(false ^ false); //false

      Console.WriteLine("\n");
      // Short circut && @ ||
      /*it sees if the first statement make the whole statement true or false
      if it does it will show the answer without checking the other statement*/

      // true && true    // true
      // true && false   // false
      // false && true   // false → second side skipped
      // false && false  // false → second side skipped

      // true || true    // true → second side skipped
      // true || false   // true → second side skipped
      // false || true   // true
      // false || false  // false

      //this will check the first statement and decides the output
      var short_ = true || Check();

      // Long circut & @ |
      /*will compare the 2 statements and check for both 
      even if the first statement decides the output*/

      //this will print CHeking... because it will check both statements
      var long_ = true | Check();

      // Ternary Operator
      var total = 900;
      var vipdiscount = 1000;
      var isvip = total >= vipdiscount ? true : false;
      Console.WriteLine(isvip);
    }
    static bool Check()
    {
      Console.WriteLine("Checking...");
      return true;
    }

  }

}