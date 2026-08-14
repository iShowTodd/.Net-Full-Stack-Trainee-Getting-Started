using DemoLib;
using System.Reflection;

namespace Assemblies
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var type = typeof(Program);
            var assembly = type.Assembly;
            Console.WriteLine(assembly);
            Demo.Trace();

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Assembly mscore = typeof(int).Assembly;
            Assembly linqAssembly = typeof(Enumerable).Assembly;

            Console.WriteLine(currentAssembly.FullName);
            Console.WriteLine(mscore.FullName);
            Console.WriteLine(linqAssembly.FullName);

            foreach (Type exportedType in currentAssembly.GetExportedTypes())
                Console.WriteLine($"Public type: {exportedType.FullName}");

            // Assembly loaded   = Assembly.LoadFrom("MathLibrary.dll");
            // Type? calcType    = loaded.GetType("MathLibrary.Calculator");
            // object? calc      = Activator.CreateInstance(calcType!);
            // MethodInfo? addMethod = calcType!.GetMethod("Add");
            // object? result    = addMethod!.Invoke(calc, new object[] { 10, 5 });
            // Console.WriteLine($"Reflected Add(10,5) = {result}");

            // Type? internalType = loaded.GetType("MathLibrary.InternalHelper");
            // MethodInfo? secret = internalType!.GetMethod(
            //     "Secret",
            //     BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public
            // );
            // Console.WriteLine(secret!.Invoke(null, null));

            AssemblyName name = currentAssembly.GetName();
            Console.WriteLine($"Name    : {name.Name}");
            Console.WriteLine($"Version : {name.Version}");
            Console.WriteLine($"Location: {currentAssembly.Location}");

            Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            bool alreadyLoaded = loadedAssemblies.Any(a => a.GetName().Name == "System.Linq");
            Console.WriteLine($"System.Linq already loaded: {alreadyLoaded}");

            Type t1 = typeof(int);
            Type t2 = 42.GetType();
            bool same = t1 == t2;
            Console.WriteLine($"typeof(int) == (42).GetType(): {same}");

            foreach (var resName in assembly.GetManifestResourceNames())
                Console.WriteLine($"Found: {resName}");

            var stream = assembly.GetManifestResourceStream("Assemblies.countries.json")
                ?? throw new Exception("Resource not found");

            var data = new BinaryReader(stream).ReadBytes((int)stream.Length);
            stream.Close();

            for (int i = 0; i < data.Length; i++)
            {
                Console.Write((char)data[i]);
                Console.Out.Flush();
                Thread.Sleep(300);
            }
        }
    }
}