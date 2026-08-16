using System.Diagnostics;

namespace Sequancial
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var wallet = new Wallet("Issam", 80);

            wallet.RunRandomTransactions();
            Console.WriteLine("----------------");
            Console.WriteLine($"{wallet}\n");

            wallet.RunRandomTransactions();
            Console.WriteLine("----------------");
            Console.WriteLine($"{wallet}\n");
        }
    }

    internal class Wallet
    {
        public Wallet(string name, int bitCoins)
        {
            Name = name;
            BitCoins = bitCoins;
        }

        public string Name { get; set; }
        public int BitCoins { get; set; }

        public void Debit(int amount)
        {
            BitCoins -= amount;
        }

        public void Credit(int amount)
        {
            BitCoins += amount;
        }

        public void RunRandomTransactions()
        {
            int[] amounts = { 10, 20, 30, -20, -10, 30, -10, 40, -10 };

            foreach (var amount in amounts)
            {
                var absValue = Math.Abs(amount);
                if (amount < 0)
                {
                    Debit(amount);
                }
                else
                {
                    Credit(amount);
                }
                Console.WriteLine($"[Thread] : {Thread.CurrentThread.ManagedThreadId} , [Process] :{Process.GetCurrentProcess().Id} ");
            }
        }

        public override string ToString()
        {
            return $"[{Name} -> {BitCoins} Bitcoins]";
        }
    }
}