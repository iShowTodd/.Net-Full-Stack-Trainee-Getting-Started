namespace Queue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Queue<PrintingJob> printingJobs = new Queue<PrintingJob>();
            printingJobs.Enqueue(new PrintingJob("documentation.docx", 2));
            printingJobs.Enqueue(new PrintingJob("user-stories.pdf", 6));
            printingJobs.Enqueue(new PrintingJob("report.xlsx", 6));
            printingJobs.Enqueue(new PrintingJob("payroll.report", 5));
            printingJobs.Enqueue(new PrintingJob("budget.xlsx", 4));
            printingJobs.Enqueue(new PrintingJob("algorithm.ppt", 1));
            Console.WriteLine($"Current  Before while Queue Count: {printingJobs.Count}");

            Random rnd = new Random();
            while (printingJobs.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var job = printingJobs.Dequeue();
                Console.WriteLine($"printing ... [{job}]");
                System.Threading.Thread.Sleep(rnd.Next(1, 5) * 1000);
            }

            Console.WriteLine($"Current  After while Queue Count: {printingJobs.Count}");

            Queue<int> numbers = new Queue<int>();

            if (numbers.TryPeek(out int n))
            {
                Console.WriteLine(n);
            }
        }
    }

    internal class PrintingJob
    {
        private readonly string file;
        private readonly int copies;

        public PrintingJob(string file, int copies)
        {
            this.file = file;
            this.copies = copies;
        }

        public override string ToString()
        {
            return $"{file} x #{copies} copies";
        }
    }
}