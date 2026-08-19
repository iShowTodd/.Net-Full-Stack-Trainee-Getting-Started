namespace NullableValueAnnotaion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string fname = null!; // nullable value annotation
            string lname = null!;

            var person = new Person(fname, lname);

            Console.WriteLine(person.FirstName!.Length);

            Student st1 = new Student();

            Student? st2 = new Student();

            var st3 = new Student();

            Console.ReadKey();
        }
    }

    internal class Student
    { }

    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            if (firstName is null)
            {
                FirstName = "Annonymous";
            }
            else
            {
                FirstName = firstName;
            }
            if (lastName is null)
            {
                LastName = "Annonymous";
            }
            else
            {
                LastName = lastName;
            }
        }
    }
}