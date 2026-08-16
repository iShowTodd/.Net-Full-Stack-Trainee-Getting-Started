namespace ThreadPools
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Methodlogy 1
            ThreadPool.QueueUserWorkItem(new WaitCallback(Print));

            // Methodlogy 2
            Task.Run(Print);

            var employee = new Employee { TotalHours = 40, Rate = 10 };

            ThreadPool.QueueUserWorkItem(new WaitCallback(calculateSalary), employee);

            Console.ReadLine(); // keeps the main thread alive
        }

        private static void calculateSalary(object employee)
        {
            var emp = employee as Employee;
            if (emp is null)
            {
                return;
            }
            emp.TotalSalary = emp.TotalHours * emp.Rate;
            Console.WriteLine(emp.TotalSalary.ToString("C"));
        }

        private static void Print()
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Thread Name: {Thread.CurrentThread.Name}");
            Console.WriteLine($"Is Pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"Background: {Thread.CurrentThread.IsBackground}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Cycle {i + 1}");
            }
        }

        private static void Print(object state)
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Thread Name: {Thread.CurrentThread.Name}");
            Console.WriteLine($"Is Pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"Background: {Thread.CurrentThread.IsBackground}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Cycle {i + 1}");
            }
        }
    }

    internal class Employee
    {
        public decimal TotalHours { get; set; }
        public decimal Rate { get; set; }

        public decimal TotalSalary { get; set; }
    }
}