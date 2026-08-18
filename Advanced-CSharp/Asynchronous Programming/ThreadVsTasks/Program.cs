namespace ThreadVsTasks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var th = new Thread(() => Display("3ruuf is on the run"));
            th.Start();
            th.Join();

            Task.Run(() => Display("Metigator using task !!!")).Wait();
        }

        private static void Display(string message)
        {
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine(message);
        }

        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}