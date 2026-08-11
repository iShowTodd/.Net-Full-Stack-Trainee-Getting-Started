
namespace Methods
{
  public class Employee
  {

    public static double TAX = 0.03;

    public string? FName;
    public string? LName;
    public double Wage;
    public double LoggedHours;

    private double Calculate() => Wage * LoggedHours;
    private double CalculateTax() => Calculate() * TAX;
    private double CalculateNet() => Calculate() - CalculateTax();

    public string PrintSlip()
    {
      return
      $"\nFirst Name :{FName}" +
      $"\nLast Name :{LName}" +
      $"\nWage :{Wage}" +
      $"\nLogged Hours :{LoggedHours}" +
      $"\n --------------------" +
      $"\nSalary :{Calculate()}" +
      $"\nDeductable Tax {Employee.TAX * 100}% Amount :${CalculateTax()}" +

      $"\nNet Salary :{CalculateNet()}\n";

    }


  }
}