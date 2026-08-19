namespace NullableContext
{
    public class Student : Person
    {
        public string Major { get; set; }

        public List<string> CompletedCourses { get; set; }

        public Student(string firstName, string lastName, string major)
            : base(firstName, lastName)
        {
            SetMajor(major);
        }

        public Student(string firstName, string lastName) :
            base(firstName, lastName)
        {
            SetMajor();
        }

        public void SetMajor(string major = default)
        {
            Major = major ?? "Undeclared";
        }
    }
}