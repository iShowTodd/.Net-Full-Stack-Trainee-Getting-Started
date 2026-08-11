
namespace Methods
{
  public class Employee
  {

    public static double TAX = 0.03;

    public string? FName;
    public string? LName;
    public double Wage;
    public double LoggedHours;

    public double Calculate() => Wage * LoggedHours;
    public double CalculateTax() => Calculate() * TAX;
    public double CalculateNet() => Calculate() - CalculateTax();

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