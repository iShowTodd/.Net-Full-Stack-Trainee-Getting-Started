namespace TaskReturnsValue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task<DateTime> task = Task.Run(() => DateTime.Now);
            Console.WriteLine(task.Result); // Blocks the Thread until result is ready

            Console.WriteLine(task.GetAwaiter().GetResult());
        }

        private static DateTime GetCurrentDateTime() => DateTime.Now;
    }
}