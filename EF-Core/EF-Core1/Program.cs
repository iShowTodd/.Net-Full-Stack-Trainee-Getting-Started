namespace EF_Core1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var _context = new ApplicationDbContext();
            var emp = new Employee { Name = "Employee1" };
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }
    }
}