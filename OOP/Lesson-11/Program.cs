
using Microsoft.VisualBasic;

namespace Indexers
{


  internal class Program
  {

    static void Main(string[] args)
    {
      var ip = new IP("199.255.255.1");

      var ip2 = new IP(199, 255, 255, 1);

      var firstSegment = ip[0];
      Console.WriteLine(firstSegment);


      var grades = new Grade();
      grades["Math"] = 95;
      grades["English"] = 88;

      Console.WriteLine(grades["Math"]);
      Console.WriteLine(grades["English"]);


      int[,] input =
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


      var suduko = new Sudoko(input);

      System.Console.WriteLine(suduko[5, 5]);
    }
  }

  public class IP
  {
    private int[] segments = new int[4];

    public string Address => string.Join('.', segments);

    // Indexer 

    public int this[int index]
    {
      get
      {
        return this.segments[index];
      }
      set
      {
        this.segments[index] = value;
      }
    }

    public IP(string IPAddress)
    {
      string[] segs = IPAddress.Split('.');

      for (int i = 0; i < segs.Length; ++i)
      {
        segments[i] = int.Parse(segs[i]);
      }
    }
    public IP(int segment1, int segment2, int segment3, int segment4)
    {
      segments[0] = segment1;
      segments[1] = segment2;
      segments[2] = segment3;
      segments[3] = segment4;
    }


  }

  public class Grade
  {
    Dictionary<string, int> grades = new Dictionary<string, int>();

    public int this[string subject]
    {
      get => this.grades[subject];
      set => this.grades[subject] = value;
    }

  }

  public class Sudoko
  {
    private int[,] matrix;

    public Sudoko(int[,] matrix)
    {
      this.matrix = matrix;
    }
    public int this[int row, int column]
    {
      get
      {
        if (row < 0 || row >= matrix.GetLength(0))
          throw new IndexOutOfRangeException($"Row {row} is out of range.");

        if (column < 0 || column >= matrix.GetLength(1))
          throw new IndexOutOfRangeException($"Column {column} is out of range.");

        return matrix[row, column];
      }
      set
      {
        if (row < 0 || row >= matrix.GetLength(0))
          throw new IndexOutOfRangeException($"Row {row} is out of range.");

        if (column < 0 || column >= matrix.GetLength(1))
          throw new IndexOutOfRangeException($"Column {column} is out of range.");

        matrix[row, column] = value;
      }
    }

    // Note : Indexers can be readonly
  }
}