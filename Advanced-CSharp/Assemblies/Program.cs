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

            // ==============================

            //  Every type belongs to an assembly
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Assembly mscore = typeof(int).Assembly;      // System.Private.CoreLib
            Assembly linqAssembly = typeof(Enumerable).Assembly; // System.Linq

            Console.WriteLine(currentAssembly.FullName);  // AssembliesDemo, Version=1.0.0.0
            Console.WriteLine(mscore.FullName);           // System.Private.CoreLib, Version=8.0.0.0
            Console.WriteLine(linqAssembly.FullName);     // System.Linq, Version=8.0.0.0

            // Inspect all public types in the current assembly
            foreach (Type exportedType in currentAssembly.GetExportedTypes())
                Console.WriteLine($"Public type: {exportedType.FullName}");

            //  Load an assembly dynamically at runtime (plugin pattern)
            // This is how plugin systems / DI containers / ORMs work internally
            Assembly loaded = Assembly.LoadFrom("MathLibrary.dll");
            Type? calcType = loaded.GetType("MathLibrary.Calculator");
            object? calc = Activator.CreateInstance(calcType!);

            // call Add(10, 5) purely via reflection — no compile-time reference needed
            MethodInfo? addMethod = calcType!.GetMethod("Add");
            object? result = addMethod!.Invoke(calc, new object[] { 10, 5 });
            Console.WriteLine($"Reflected Add(10,5) = {result}"); // 15

            // Access an internal type via reflection (bypasses access modifiers)
            // Senior knowledge: reflection ignores internal/private — a security consideration
            Type? internalType = loaded.GetType("MathLibrary.InternalHelper");
            MethodInfo? secret = internalType!.GetMethod(
                "Secret",
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public
            );
            Console.WriteLine(secret!.Invoke(null, null)); // "You can't call me from ConsoleApp!"

            //Assembly metadata — versioning matters in production
            AssemblyName name = currentAssembly.GetName();
            Console.WriteLine($"Name    : {name.Name}");
            Console.WriteLine($"Version : {name.Version}");       // Major.Minor.Build.Revision
            Console.WriteLine($"Location: {currentAssembly.Location}");

            // Check if an assembly is already loaded (avoid double-loading)
            // Double-loading the same dll = two separate type identities = cast failures
            Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            bool alreadyLoaded = loadedAssemblies.Any(a => a.GetName().Name == "System.Linq");
            Console.WriteLine($"System.Linq already loaded: {alreadyLoaded}"); // True

            // Weak reference pattern — let the GC unload if memory is tight
            // Full unloading requires AssemblyLoadContext (see note below)
            var weakRef = new WeakReference(loaded);
            Console.WriteLine($"Assembly alive: {weakRef.IsAlive}");

            // AssemblyLoadContext — the production way to unload assemblies
            // Default context never unloads. Use a custom context for hot-reload / plugins.

            // var ctx    = new AssemblyLoadContext("PluginContext", isCollectible: true);
            // Assembly a = ctx.LoadFromAssemblyPath("/path/plugin.dll");
            // ctx.Unload(); // now the assembly CAN be GC'd — not possible with LoadFrom()

            // typeof vs GetType vs is — all hit the assembly's type table
            Type t1 = typeof(int);             // compile-time, no object needed
            Type t2 = 42.GetType();          // runtime, needs an instance
            bool same = t1 == t2;              // true — same Type object from same assembly
            Console.WriteLine($"typeof(int) == (42).GetType(): {same}");

            // The cost of reflection — cache MethodInfo, never call GetMethod in loops
            // BAD  (in a loop): type.GetMethod("Add").Invoke(...)   // allocates every iteration
            // GOOD (cache it) :
            MethodInfo cachedAdd = calcType.GetMethod("Add")!;
            for (int i = 0; i < 3; i++)
                Console.WriteLine(cachedAdd.Invoke(calc, new object[] { i, i * 2 }));

            var stream = assembly.GetManifestResourceStream(type, "data.countries.json");
            var data = new BinaryReader(stream).ReadBytes((int)stream.Length);
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write((char)data[i]);
                System.Threading.Thread.Sleep(300);
            }
            stream.Close();
        }
    }
}