

namespace Properties
{

  internal class Program
  {
    static void Main(string[] args)
    {
      // Dollar dollar = new Dollar();
      // dollar.Amount = 1.99m;
      // Console.WriteLine(dollar.Amount);

      Dollar dollar = new Dollar(1.99m);
      dollar.Amount = 1m; // set
      Console.WriteLine(dollar.Amount); // get

    }
  }

  public class Dollar
  {
    private decimal amount;

    // <Access Modifier "Public"> <Datatype> <Property Name> { get; set; }
    public decimal Amount
    {
      get
      {
        return amount;
      }
      set
      {
        // if (value <= 0)
        // {
        //   this.amount = 0;
        // }
        this.amount = ProcessValue(value);
      }
    }

    public Dollar(decimal amount)
    {
      // if (amount <= 0)
      // {
      //   this.amount = 0;
      // }
      // this.amount = amount ;
      this.amount = ProcessValue(amount);
    }

    // Read Only Property
    public decimal Rate
    {
      get
      {
        return this.amount;
      }
      // private set
      // {

      // }
    }
    public void SetAmount(decimal amount)
    {
      Amount = amount;
    }

    public bool IsZero => this.amount == 0;

    // Property And Initialization
    public decimal ConversionFactor { get; set; } = 1.99m;
    // ! TO Avoid DRY 
    private decimal ProcessValue(decimal value) => value <= 0 ? 0 : Math.Round(value, 2);
  }
}