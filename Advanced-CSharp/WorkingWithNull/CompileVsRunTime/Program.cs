namespace CompileVsRunTime
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input = "123A";
            //int num1 = input; // CS0029 Can not convert string to int (Error at Compile time)
            // Compile Time : building source code and convert it to IL
            // Finding any error at this phase is easy

            // Run Time : when you execute the code "click the run button"
            int num2 = int.Parse(input); // RunTime Error
        }
    }
}