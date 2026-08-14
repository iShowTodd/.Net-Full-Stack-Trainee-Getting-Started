using System.Reflection;

namespace ReflectionAndMetaData
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //  All of this code is under a title called "Obtaining Object"

            Type t1 = DateTime.Now.GetType(); // at RunTime
            Type t2 = typeof(DateTime); // at CompileTime

            Console.WriteLine(t1);
            Console.WriteLine(t2);

            Console.WriteLine($"FullName : {t1.FullName}");
            Console.WriteLine($"Namespace : {t1.Namespace}");
            Console.WriteLine($"Name : {t1.Name}");
            Console.WriteLine($"BaseType : {t1.BaseType}");
            Console.WriteLine($"IsPublic : {t1.IsPublic}");
            Console.WriteLine($"IsAbstract : {t1.IsAbstract}");

            Type t3 = typeof(int[,]);
            Console.WriteLine(t3.Name);

            var nestedTypes = typeof(Employee).GetNestedTypes();

            for (int i = 0; i < nestedTypes.Length; i++)
            {
                Console.WriteLine(nestedTypes[i]);
            }

            Type t4 = typeof(int);

            var interfaces = t4.GetInterfaces();

            foreach (var i in interfaces)
            {
                Console.WriteLine(i);
            }

            // Instantiating Types via Reflection

            //var integer = new Int32();
            var integer = (int)Activator.CreateInstance(typeof(int));
            integer = 3;

            DateTime dt = (DateTime)Activator.CreateInstance(typeof(DateTime), 2021, 1, 1);
            Console.WriteLine(dt);

            Console.WriteLine(new Goon());

            //Console.Write("Enemy (or 'exit'): ");
            //do
            //{
            //    var input = Console.ReadLine();
            //    if (input?.ToLower() == "exit") break;

            //    input = "ReflectionAndMetaData." + input;
            //    object obj = null;

            //    try
            //    {
            //        obj = typeof(Program).Assembly.CreateInstance(input);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //    switch (obj)
            //    {
            //        case Goon g: Console.WriteLine(g); break;
            //        case Agar a: Console.WriteLine(a); break;
            //        case Pixa p: Console.WriteLine(p); break;
            //        default: Console.WriteLine("Unknown Enemy"); break;
            //    }

            //    Console.Write("Enemy (or 'exit'): ");
            //} while (true);

            // Reflecting Members

            BankAccount acc = new BankAccount("A123", "Ahmed Arafa", 1000);
            acc.OnNegativeBalance += Account_OnNegativeBalance;
            acc.Withdraw(1100);

            MemberInfo[] members = typeof(BankAccount).GetMembers(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var member in members)
            {
                Console.WriteLine(member); // All memebers except private fields (I will add them using the flag enums)
            }

            Type type = typeof(BankAccount);

            Console.WriteLine("── Fields ──");
            foreach (var f in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                Console.WriteLine($"  {(f.IsPrivate ? "private" : "public"),-10} {f.FieldType.Name,-15} {f.Name}");

            Console.WriteLine("── Properties ──");
            foreach (var p in type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                Console.WriteLine($"  {p.PropertyType.Name,-15} {p.Name,-20} CanRead: {p.CanRead}  CanWrite: {p.CanWrite}");

            Console.WriteLine("── Methods ──");
            foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly))
                Console.WriteLine($"  {(method.IsPrivate ? "private" : "public"),-10} {method.ReturnType.Name,-15} {method.Name}()");

            Console.WriteLine("── Constructors ──");
            foreach (var c in type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                var parameters = c.GetParameters();
                var paramStr = string.Join(", ", Array.ConvertAll(parameters, p => $"{p.ParameterType.Name} {p.Name}"));
                Console.WriteLine($"  {type.Name}({paramStr})");
            }

            foreach (var e in type.GetEvents(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                Console.WriteLine($"  event {e.EventHandlerType?.Name,-20} {e.Name}");

            // ── Invoke a private method via reflection ────────────────────────────
            Console.WriteLine("── Invoke private method ──");
            var account = new BankAccount("123", "Ahmed", 500);
            MethodInfo? m = type.GetMethod("Withdraw", BindingFlags.Instance | BindingFlags.Public);
            m?.Invoke(acc, new object[] { 100m });
            Console.WriteLine(acc);

            // ── Read & write a private field via reflection ───────────────────────
            Console.WriteLine("── Read/Write private field ──");
            FieldInfo? balanceField = type.GetField("balance", BindingFlags.Instance | BindingFlags.NonPublic);
            Console.WriteLine($"  balance (before) : {balanceField?.GetValue(acc)}");
            balanceField?.SetValue(acc, 9999m);
            Console.WriteLine($"  balance (after)  : {balanceField?.GetValue(acc)}");
        }

        private static void Account_OnNegativeBalance(object? sender, EventArgs e)
        {
            var acc = (BankAccount)sender;
            Console.WriteLine($"[ALERT] {acc.Holder}'s account is negative: ${acc.Balance}");
        }
    }

    public class Goon
    {
        public override string ToString()
        {
            return $"{{ Speed : {20} , HitPower : {13} , Strength : {7} }} ";
        }
    }

    public class Agar
    {
        public override string ToString()
        {
            return $"{{ Speed : {23} , HitPower : {10} , Strength : {12} }} ";
        }
    }

    public class Pixa
    {
        public override string ToString()
        {
            return $"{{ Speed : {25} , HitPower : {11} , Strength : {9} }} ";
        }
    }

    internal class Employee
    {
        public string Name { get; set; } = "";
        public decimal Salary { get; set; }

        // nested types — classes/enums/structs defined INSIDE another class
        public class FullTimeEmployee
        {
            public decimal AnnualSalary { get; set; }
        }

        public class PartTimeEmployee
        {
            public decimal HourlyRate { get; set; }
        }

        public enum EmployeeStatus
        {
            Active,
            Inactive,
            Suspended
        }
    }
}