namespace Stack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stack<Command> undo = new Stack<Command>();
            Stack<Command> redo = new Stack<Command>();

            string line;
            while (true)
            {
                Console.Write("URL (Exit to quit)");
                line = Console.ReadLine().ToLower();
                if (line == "exit")
                {
                    break;
                }
                else if (line == "back")
                {
                    if (undo.Count > 0)
                    {
                        var item = undo.Pop();
                        redo.Push(item);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (line == "Forward")
                {
                    if (redo.Count > 0)
                    {
                        var item = redo.Pop();
                        undo.Push(item);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    // add url to undo list
                    undo.Push(new Command(line));
                }

                Console.Clear();

                Print("Back", undo);
                Print("Forward", redo);
            }

            Stack<int> numbers = new Stack<int>(new List<int> { 1, 2, 3 });

            while (numbers.Count > 0)
            {
                var n = numbers.Peek();

                Console.WriteLine(n);
                numbers.Pop();
            }
        }

        private static void Print(string name, Stack<Command> commands)
        {
            Console.WriteLine($"{name} history");
            Console.BackgroundColor = name.ToLower() == "back" ? ConsoleColor.DarkGreen : ConsoleColor.DarkBlue;
            foreach (var u in commands)
            {
                Console.WriteLine($"\t{u}");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }

    public class Command
    {
        private readonly DateTime createdAt;
        private readonly string url;

        public Command(string url)
        {
            this.createdAt = DateTime.Now;
            this.url = url;
        }

        public override string ToString()
        {
            return $"[{this.createdAt:yyyy-MM-dd hh:mm}] {this.url}";
        }
    }
}