namespace SyncVsAsync
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ShowThreadInfo(Thread.CurrentThread, 7);
            CallSynchronous();

            ShowThreadInfo(Thread.CurrentThread, 10);
            CallAsynchronous();

            ShowThreadInfo(Thread.CurrentThread, 13);
            Console.ReadKey();
        }

        private static void CallSynchronous()
        {
            Thread.Sleep(4000);
            ShowThreadInfo(Thread.CurrentThread, 20);
            Task.Run(() => Console.WriteLine("++++++++++ Synchronous +++++++++++")).Wait();
        }

        private static void CallAsynchronous()
        {
            ShowThreadInfo(Thread.CurrentThread, 26);
            Task.Delay(4000).GetAwaiter().OnCompleted(() =>
            {
                ShowThreadInfo(Thread.CurrentThread, 29);
                Console.WriteLine("++++++++++ Asynchronous +++++++++++");
            });
        }

        private static void ShowThreadInfo(Thread th, int line)
        {
            Console.WriteLine($"Line#: {line}, TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}