using System.Diagnostics;

namespace ProcessAndThread
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Process.GetCurrentProcess().Id);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(Thread.GetCurrentProcessorId());
        }
    }
}