using System.Text;
using System.Text.Json;

namespace BinarySerialization
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var e1 = new Employee
            {
                Id = 1001,
                Fname = "Ahmed",
                Lname = "Arafa",
                Benefits = { "Pension", "Health Insurance" }
            };

            string binaryContent = SerializeToBase64String(e1);
            Console.WriteLine(binaryContent);

            Employee e2 = DeserializeFromBase64String(binaryContent);
            Console.WriteLine($"\nDeserialized: {e2.Fname} {e2.Lname}, Id={e2.Id}");
            Console.WriteLine($"Benefits: {string.Join(", ", e2.Benefits)}");

            Console.ReadKey();
        }

        private static string SerializeToBase64String(Employee employee)
        {
            string json = JsonSerializer.Serialize(employee);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            return Convert.ToBase64String(bytes);
        }

        private static Employee DeserializeFromBase64String(string base64Content)
        {
            byte[] bytes = Convert.FromBase64String(base64Content);
            string json = Encoding.UTF8.GetString(bytes);
            return JsonSerializer.Deserialize<Employee>(json);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public List<string> Benefits { get; set; } = new List<string>();
    }
}