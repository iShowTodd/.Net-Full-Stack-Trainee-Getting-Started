namespace RaceCondtion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var wallet = new Wallet("Ahmed", 50);

            wallet.Debit(40);
            wallet.Debit(30);
            Console.WriteLine(wallet);

            var t1 = new Thread(() => wallet.Debit(40));
            var t2 = new Thread(() => wallet.Debit(40));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
    }

    internal class Wallet
    {
        private readonly object bitCoinsLock = new object();

        public Wallet(string name, int bitcoins)
        {
            Name = name;
            Bitcoins = bitcoins;
        }

        public string Name { get; private set; }
        public int Bitcoins { get; private set; }

        public void Debit(int amount)
        {
            lock (bitCoinsLock)
            {
                if (Bitcoins >= amount)
                {
                    Thread.Sleep(1000);

                    Bitcoins -= amount;
                }
            }
        }

        public void Credit(int amount)
        {
            Thread.Sleep(1000);
            Bitcoins += amount;
        }

        public void RunRandomTransactions()
        {
            int[] amounts = { 10, 20, 30, -20, 10, -10, 30, -10, 40, -20 }; // 80

            foreach (var amount in amounts)
            {
                var absValue = Math.Abs(amount);
                if (amount < 0)
                    Debit(absValue);
                else
                    Credit(absValue);
            }
        }

        public override string ToString()
        {
            return $"[{Name} -> {Bitcoins} Bitcoins]";
        }
    }
}