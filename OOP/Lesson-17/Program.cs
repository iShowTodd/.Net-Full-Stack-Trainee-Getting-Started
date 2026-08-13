namespace Structs
{
  internal class Program
  {
    static void Main(string[] args)
    {
      DigitalSize ds = new DigitalSize(60000);

      Console.WriteLine(ds.Bit);
      Console.WriteLine(ds.Byte);
      Console.WriteLine(ds.KB);
      Console.WriteLine(ds.MB);
      Console.WriteLine(ds.GB);
      Console.WriteLine(ds.TB);

      DigitalSize ds2 = ds.AddBit(8);
      DigitalSize ds3 = ds.AddByte(1);
      DigitalSize ds4 = ds.AddKB(1);
      DigitalSize ds5 = ds.AddMB(1);
      DigitalSize ds6 = ds.AddGB(1);
      DigitalSize ds7 = ds.AddTB(1);


      Point p1 = new Point(3, 4);
      Point p2 = new Point(6, 8);

      Console.WriteLine(p1.ToString());
      Console.WriteLine(p1.DistanceTo(p2));

      // Date Time is an example of a readonly struct
      DateTime dt = new DateTime(2021, 05, 01, 08, 30, 00);

      dt = dt.AddDays(10);
    }
  }



  // Imutable Data type
  public struct DigitalSize
  {
    private long bit;

    private const long bitsInBit = 1;
    private const long bitsInByte = 8;
    private const long bitsInKB = bitsInByte * 1024;
    private const long bitsInMB = bitsInKB * 1024;
    private const long bitsInGB = bitsInMB * 1024;
    private const long bitsInTB = bitsInGB * 1024;

    public string Bit => $"{(bit / bitsInBit):N0} Bit";
    public string Byte => $"{(bit / bitsInByte):N0} Byte";
    public string KB => $"{(bit / bitsInKB):N0} KB";
    public string MB => $"{(bit / bitsInMB):N0} MB";
    public string GB => $"{(bit / bitsInGB):N0} GB";
    public string TB => $"{(bit / bitsInTB):N0} TB";

    public DigitalSize(long intialValue)
    {
      this.bit = intialValue;
    }

    public DigitalSize AddBit(long bit)
    {
      return Add(bit, bitsInBit);
    }

    public DigitalSize AddByte(long bit)
    {
      return Add(bit, bitsInByte);
    }

    public DigitalSize AddKB(long value)
    {
      return Add(value, bitsInKB);
    }

    public DigitalSize AddMB(long value)
    {
      return Add(value, bitsInMB);
    }

    public DigitalSize AddGB(long value)
    {
      return Add(value, bitsInGB);
    }

    public DigitalSize AddTB(long value)
    {
      return Add(value, bitsInTB);
    }

    // it is Immuatable
    public DigitalSize Add(long value, long scale)
    {
      // this.bit = bit ; // Wrong as it is immutable 
      return new DigitalSize(value * scale);
    }
  }


  // readonly Struct 

  public readonly struct Point
  {
    private readonly double x;
    private readonly double y;

    public double X => x;
    public double Y => y;

    public Point(double x, double y)
    {
      this.x = x;
      this.y = y;
    }

    public double DistanceTo(Point other)
    {
      double dx = other.x - this.x;
      double dy = other.y - this.y;
      return Math.Sqrt(dx * dx + dy * dy);
    }

    public Point Translate(double dx, double dy)
    {
      return new Point(x + dx, y + dy);
    }

    public override string ToString()
    {
      return $"Point({x}, {y})";
    }
  }
}