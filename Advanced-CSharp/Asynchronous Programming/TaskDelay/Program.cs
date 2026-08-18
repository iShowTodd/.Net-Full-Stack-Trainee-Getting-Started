namespace TaskDelay
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DelayUsingTask(5000);
            Console.ReadKey();
        }

        private static void DelayUsingTask(int ms)
        {
            Task.Delay(ms).GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine($"Completed after Task.Delay({ms})");
            });
        }

        private static void SleepUsingThread(int ms)
        {
            Thread.Sleep(ms);
            Console.WriteLine($"Completed After Thread.Sleep({ms})");
        }
    }
}