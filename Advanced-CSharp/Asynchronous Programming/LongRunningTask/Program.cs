namespace LongRunningTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // How to Run a Long Running Task
            var task = Task.Factory.StartNew(() => RunLongTask(), TaskCreationOptions.LongRunning); // it is not Pooled as
                                                                                                    // thread pool wants to manage short tasks

            Console.ReadKey();
        }

        private static void RunLongTask()
        {
            Thread.Sleep(3000);
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine("Completed");
        }

        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}