namespace StructAndArrayNullables
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Print(default);

            string[] names = new string[10];
            var firstValue = names[0];
            Console.WriteLine(firstValue.ToUpper());
            Console.ReadLine();
        }

        private static void Print(Student student)
        {
            Console.WriteLine($"First Name: {student.FirstName.ToUpper()}");
            Console.WriteLine($"Middle Name: {student.FirstName?.ToUpper()}");
            Console.WriteLine($"Last Name: {student.LastName.ToUpper()}");
        }
    }

    public struct Student
    {
        public string FirstName;
        public string? MiddleName;
        public string LastName;
    }
}