namespace MulticastDelegate
{
  public delegate void RecDelegate(decimal width, decimal height);

  internal class Program
  {

    static void Main(string[] args)
    {

      var helper = new RectangleHelper();
      helper.GetArea(10, 10);
      helper.GetPerimeter(10, 10);

      // After Delegate

      RecDelegate rect;

      rect = helper.GetArea;
      rect += helper.GetPerimeter; // Subscribe
      rect(10, 10); // it will execute both functions



      rect -= helper.GetArea;  // unsubscribing 

      Console.WriteLine("After unsbuscribing rect.Area");

      // rect(10, 10);
      // this is better null safety 
      rect?.Invoke(10, 10);


    }
  }


  public class RectangleHelper
  {
    public void GetArea(decimal width, decimal height)
    {
      var result = width * height;
      Console.WriteLine($" Area = {width} x {height} = {result}");
    }

    public void GetPerimeter(decimal width, decimal height)
    {
      var result = 2 * (width + height);
      Console.WriteLine($" Perimeter = 2 x ({width} + {height}) = {result}");
    }
  }
}