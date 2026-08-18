namespace Exception_Propagation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //try
            //{
            //    //ThrowException(); // the main thread will manage the exception via the catch block

            //    var th = new Thread(() => ThrowException()); // At this case it will give you unhandled exception
            //                                                 // because it uses other thread than main thread

            //    th.Start();
            //    th.Join();
            //}
            //catch
            //{
            //    Console.WriteLine("Exception is thrown");
            //}

            //var th = new Thread(ThrowExceptionWithTryCatchBlock);
            //th.Start();
            //th.Join();

            try
            {
                Task.Run(() => ThrowException()).Wait();
            }
            catch
            {
                Console.WriteLine("Exception is thrown");

                throw;
            }

            Console.ReadKey();
        }

        private static void ThrowException()
        {
            throw new NullReferenceException();
        }

        private static void ThrowExceptionWithTryCatchBlock()
        {
            try
            {
                throw new NullReferenceException();
            }
            catch
            {
                Console.WriteLine("Exception is thrown!!");

                throw;
            }
        }
    }
}