
namespace BoxingAndTypes
{

  internal class Program
  {

    static void Main(string[] args)
    {
      Int32 x; // same with int x 
      Int16 s; // same with short s 
      Int64 l;// same with long l
      UInt16 ush; // same with unsigned short

      //!Error
      //! int num = 3;
      //! string s = "10";
      //! int num = s;


      // Implicit Casting

      int numberInt = 100;
      long numberLong = numberInt; // ? NOT VICE VERSA 

      // Explicit Casting

      long nL = 100;

      if (nL < Int32.MaxValue)
      {
        int nI = (int)nL;
      }

      // ? Boxing : convering from data type value to data type reference

      int num = 10;
      object obj;
      obj = num; // ? Boxing
      int num2 = (int)obj; // ? UnBoxing

      // ? Converting from string to int

      /*
      ? int.parse
      ? double.parse
      ? etc.parse

      ?? Convert.toInt32 .. etc
      */

      //The Convert Class (Best for Cross-Type Conversion


      //-------------------

      //decimal       ToDecimal(string)
      //float         ToSingle(string)
      //double        ToDouble(string)
      //short         ToInt16(string)
      //int           ToInt32(string)
      //long          ToInt64(string)
      //ushort        ToUInt16(string)
      //uint          ToUInt32(string)
      //ulong         ToUInt64(string)

      //-------------------------------

      string stringValue = "123";
      int intValue = Convert.ToInt32(stringValue); // Result: 123

      string nullValue = null;
      int defaultValue = Convert.ToInt32(nullValue); // Result: 0 (No exception)


      //Parse and TryParse (Best for String-to-Numeric Parsing)

      // Using Parse (Throws exception if it fails)
      int age = int.Parse("25");

      // Using TryParse (Safe, no exceptions)
      string input = "abc";
      if (int.TryParse(input, out int result))
      {
        Console.WriteLine($"Success: {result}");
      }
      else
      {
        Console.WriteLine("Conversion failed."); // This code path runs
      }

      // Bit Converter
      var number = 10;
      var bytes = BitConverter.GetBytes(number); // arry of 4 32 bit = 4 bytes (int)

      foreach (var b in bytes)
      {
        var Binary = Convert.ToString(b, 2).PadLeft(8, '0');
        Console.WriteLine(b); // 00001010
      }


      var name = "Ahmed";
      char[] letter = name.ToCharArray();

      foreach (var c in letter)
      {
        int ascii = Convert.ToInt32(c);
        var output = $"{c} →  ASCII = {ascii}, Binary = {Convert.ToString(ascii, 2).PadLeft(8, '0')} , HEX : : {ascii:x}";
        Console.WriteLine(output);
      }

      // convert hexadecimal to string

      string[] hexValue = { "49", "73", "73", "61", "6d" };

      //..1
      foreach (var hex in hexValue)
      {
        int value = Convert.ToInt32(hex, 16);
        stringValue = Char.ConvertFromUtf32(value);//  convert integer value to charecter 
        Console.WriteLine(stringValue);

      }
      Console.WriteLine("-----");
      //..2
      foreach (var hex in hexValue)
      {
        int value = Convert.ToInt32(hex, 16);
        var ch = (char)value;
        Console.WriteLine(ch);

      }

      // convert hexadecimal to integer
      var hexa = "8E2";
      number = Int32.Parse(hexa, System.Globalization.NumberStyles.HexNumber);

      Console.WriteLine(number);    //2274

    }
  }
}