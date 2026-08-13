

namespace Exceptions
{

  internal class Program
  {

    static void Main(string[] args)
    {
      try
      {
        BadMethod(5, 0);
      }
      catch
      {
        Console.WriteLine("You can not devide by zero");
      }
      finally
      {
        Console.WriteLine("End");
      }


      //  Multiple catches

      try
      {
        BadMethod(5, 5);
      }
      catch (DivideByZeroException e) when (e.Source == "Exceptions")
      {
        Console.WriteLine(e.Message);
      }
      catch (ArgumentNullException e)
      {
        Console.WriteLine(e.Message);

      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);

      }
      finally
      {

      }
      var delivery = new Delivery { Id = 1, CustomerName = "Issam A.", Address = "123 Street" };
      var service = new DeliveryService();

      try
      {
        service.Start(delivery);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      Console.WriteLine(delivery);


    }

    static void BadMethod(int x, int y)
    {
      Console.WriteLine(x / y);
    }
  }
}