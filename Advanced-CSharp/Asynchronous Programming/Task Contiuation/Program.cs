namespace Task_Contiuation
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //Console.WriteLine(CountPrimeNumberInARange(2, 2_000_000));

            Task<int> task = Task.Run(() => CountPrimeNumberInARange(2, 3_000_000));
            Console.WriteLine(task.Result); // Bad : it Blocks the thread

            Console.WriteLine("using awaiter, onComplete");

            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(awaiter.GetResult());  // block the thread but task is completed
            });

            Console.WriteLine("using task continuewith");

            task.ContinueWith((x) => Console.WriteLine(x.Result));

            Console.WriteLine("3ruuuuuuf on the run");
            Console.ReadKey();
        }

        private static int CountPrimeNumberInARange(int lowerBound, int upperBound)
        {
            var count = 0;
            for (int i = lowerBound; i < upperBound; i++)
            {
                var j = lowerBound;
                var isPrime = true;
                while (j < (int)Math.Sqrt(i))
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    ++j;
                }
                if (isPrime)
                {
                    count++;
                }
            }
            return count;
        }
    }
}