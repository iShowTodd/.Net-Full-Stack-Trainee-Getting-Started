


namespace Interfaces
{


  interface IPayment
  {
    void Pay(decimal amount);
  }

  class Cash
  {
    public void Pay(decimal amount)
    {
      Console.WriteLine($"Cash Payment : {Math.Round(amount, 2):N0} ");
    }
  }

  class Debit : IPayment
  {
    public void Pay(decimal amount)
    {
      Console.WriteLine($"Debit Payment: ${Math.Round(amount, 2):N0}"); //$99,999.99
    }
  }

  class Visa : IPayment
  {
    public void Pay(decimal amount)
    {
      Console.WriteLine($"Visa Payment: ${Math.Round(amount, 2):N0}"); //$99,999.99
    }
  }

  class Mastercard : IPayment
  {
    public void Pay(decimal amount)
    {
      Console.WriteLine($"Mastercard Payment: ${Math.Round(amount, 2):N0}"); //$99,999.99
    }
  }

  class Casheir
  {

    // Loose Coupling
    private IPayment payment;

    public Casheir(IPayment payment)
    {
      this.payment = payment;
    }

    public void checkout(decimal amount)
    {
      payment.Pay(amount);
    }
  }
  internal class Program
  {

    static void Main(string[] args)
    {
      Veichle v = new Honda("Honda", "Civic", 2022);


      ILoader catpilar = new CaterPillar("CatPilar", "XYZ", 2020); // allows only Iloader methods


      var visa = new Visa();

      Casheir casheir = new Casheir(visa); // csn be anything else



    }
  }

  interface IMove
  {
    void Move();
  }
  interface IDisplaceMove
  {
    void Move();
  }

  class Movement : IMove, IDisplaceMove
  {

    // Explicit implementation
    void IDisplaceMove.Move()
    {
      Console.WriteLine("First interface movements");
    }

    void IMove.Move()
    {
      Console.WriteLine("Second interface movements");
    }
  }

  interface IDrivable
  {
    void Move();
    void Stop();
  }
  interface ILoader
  {
    void Load();
    void UnLoad();
  }

  abstract class Veichle
  {
    protected string Brand;
    protected string Model;
    protected int Year;

    public Veichle(string brand, string model, int year)
    {
      Brand = brand;
      Model = model;
      Year = year;
    }
    public virtual void Move()
    {
      Console.WriteLine("Moving............");

    }
    public virtual void Stop()
    {
      Console.WriteLine("Stoping............");

    }

  }


  // concrete type
  class Honda : Veichle
  {
    public Honda(string brand, string model, int year) : base(brand, model, year)
    {

    }

    // Implicit implmentation
    public override void Move()
    {
      base.Move();
    }

    public override void Stop()
    {
      base.Stop();
    }
  }

  class CaterPillar : Veichle, ILoader, IDrivable
  {
    public CaterPillar(string brand, string model, int year) : base(brand, model, year)
    {
    }

    public void Load()
    {
      Console.WriteLine("Loading......");
    }

    public override void Move()
    {
      Console.WriteLine("Moving............");
    }

    public override void Stop()
    {
      Console.WriteLine("Stoping............");
    }

    public void UnLoad()
    {
      Console.WriteLine("Unloadig.......");
    }
  }
}