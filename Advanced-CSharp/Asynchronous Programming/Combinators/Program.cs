namespace Combinators
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var has1000SubscriberTask = Task.Run(() => Has1000Subscriber());
            var Has4000ViewHoursTask = Task.Run(() => Has4000ViewHours());

            Console.WriteLine("Using whenAny");
            Console.WriteLine("-------------");

            var any = await Task.WhenAny(has1000SubscriberTask, Has4000ViewHoursTask);
            Console.WriteLine(any.Result);

            var all = await Task.WhenAll(has1000SubscriberTask, Has4000ViewHoursTask); // Better Performance

            foreach (var t in all)
            {
                Console.WriteLine(t);
            }
            Console.ReadKey();
        }

        private static Task<string> Has1000Subscriber()
        {
            Task.Delay(4000).Wait();
            return Task.FromResult("congratulation !! you have 1000 subscribers");
        }

        private static Task<string> Has4000ViewHours()
        {
            Task.Delay(3000).Wait();
            return Task.FromResult("congratulation !! you have 4000 view hours");
        }
    }
}