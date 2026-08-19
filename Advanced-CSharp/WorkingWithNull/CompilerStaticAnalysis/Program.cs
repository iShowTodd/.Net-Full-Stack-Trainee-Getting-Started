namespace CompilerStaticAnalysis
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        private static string? GetName()
        {
            return null;
        }

        #region Non-null

        private static bool Scenario1()
        {
            string name = string.Empty; // Assignment of non null value
            return name.Length > 10;
        }

        private static bool Scenario2()
        {
            string? name = GetName();
            if (name == null) // checked against null
                return false;
            return name.Length > 10; // name shouldn't be null
        }

        #endregion Non-null

        #region Maybe-null

        private static bool MaybeNullScenario()
        {
            string? name = GetName();
            return name.Length > 10; // maybe null
        }

        #endregion Maybe-null

    }
}