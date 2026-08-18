namespace AsyncFunctions
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var task = Task.Run(() => ReadContent("www.google.com"));

            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult));

            Console.WriteLine(await ReadContentAsync("https://www.youtube.com/c/Metigator"));

            Console.ReadKey();
        }

        private static Task<string> ReadContent(string url)
        {
            var client = new HttpClient();

            var task = client.GetStringAsync(url);

            return task;
        }

        private static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();

            var content = await client.GetStringAsync(url);

            return content;
        }
    }
}