namespace XML_Documentation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                Console.Write("First Name: ");
                var fname = Console.ReadLine();

                Console.Write(" Last Name: ");
                var lname = Console.ReadLine();

                Console.Write(" Hire Date: ");
                DateTime? hireDate = null;
                if (DateTime.TryParse(Console.ReadLine(), out DateTime hDate))
                {
                    hireDate = hDate;
                }
                var empId = Generator.GenerateId(fname, lname, hireDate);
                var randomPassword = Generator.GenerateRandomPassword(8);

                Console.WriteLine(
                    $"{{\n Id: {empId},\n FName: {fname},\n LName: {lname},\n hire date: {hireDate.Value:d}, \n Password: {randomPassword}\n}}"
                );
            } while (1 == 1);
        }
    }

    // This is a XML Documentation
    /// <summary>
    ///     This is a Generator class
    /// </summary>
    /// <remarks>
    ///     this class can generate Ids and Passwords
    /// </remarks>
    ///

    /// <include file="Generator.xml" path='docs/members[@name="generator"]/Generator/*'/> // for external memebers

    public class Generator
    {
        /// <value> Value of Last Id sequence</value>
        public static int LastIdSequence { get; private set; } = 1;

        /// <summary>
        /// Generate Employee id by processing  <paramref name="fname"/>  <paramref name="lname"/> <paramref name="hireDate"/>
        /// <list type="bullet">
        /// <item>
        /// <term>II</term>
        /// <description>Employee Initials first letter of <paramref name="fname"/> and first letter of <paramref name="lname"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <code>
        ///       var id = IdGenerator.Generate("John", "Smith", new DateTime(2000, 10, 9, 0, 0, 0));
        ///       Console.WriteLine(id);
        /// </code>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="hireDate"></param>
        /// <returns>
        ///     Employee Id as a string
        /// </returns>
        /// <exception cref="InvalidOperationException"> Thrown when param refs are null</exception>
        ///

        /// <include file="Generator.xml" path='docs/members[@name="generator"]/GenerateId/*'/>

        public static string GenerateId(string fname, string lname, DateTime? hireDate)
        {
            if (fname is null)
                throw new InvalidOperationException($" {nameof(fname)} can not be null");

            if (lname is null)
                throw new InvalidOperationException($" {nameof(lname)} can not be null");

            if (hireDate is null)
            {
                hireDate = DateTime.Now;
            }
            else
            {
                if (hireDate.Value.Date < DateTime.Now.Date) // yyyy-MM-dd hh:mm:ss
                    throw new InvalidOperationException(
                        $" {nameof(hireDate)} can not be in the past"
                    );
            }

            var yy = hireDate.Value.ToString("yy");
            var mm = hireDate.Value.ToString("MM");
            var dd = hireDate.Value.ToString("dd");

            var code =
                $"{lname.ToUpper()[0]}{fname.ToUpper()[0]} {yy} {mm} {dd} {LastIdSequence++.ToString().PadLeft(2, '0')}";

            return code;
        }

        public static string GenerateRandomPassword(int length)
        {
            const string ValidScope =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ0123456789";
            var result = "";
            Random rnd = new Random();

            while (0 < length--)
            {
                result += ValidScope[rnd.Next(ValidScope.Length)];
            }
            return result;
        }
    }
}