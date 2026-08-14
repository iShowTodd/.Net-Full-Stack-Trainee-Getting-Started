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

            // Assembly loaded      = Assembly.LoadFrom("MathLibrary.dll");
            // Type? calcType       = loaded.GetType("MathLibrary.Calculator");
            // object? calc         = Activator.CreateInstance(calcType!);
            // MethodInfo? addMethod = calcType!.GetMethod("Add");
            // object? result       = addMethod!.Invoke(calc, new object[] { 10, 5 });
            // Console.WriteLine($"Reflected Add(10,5) = {result}");

            // Type? internalType = loaded.GetType("MathLibrary.InternalHelper");
            // MethodInfo? secret = internalType!.GetMethod(
            //     "Secret",
            //     BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public
            // );
            // Console.WriteLine(secret!.Invoke(null, null));

            AssemblyName name = currentAssembly.GetName();
            Console.WriteLine($"Name         : {name.Name}");
            Console.WriteLine($"Version      : {name.Version}");
            Console.WriteLine($"Location     : {currentAssembly.Location}");
            Console.WriteLine($"Culture      : {name.CultureInfo?.Name ?? "neutral"}");

            byte[]? token = name.GetPublicKeyToken();
            string tokenStr = token != null && token.Length > 0
                ? BitConverter.ToString(token).Replace("-", "").ToLower()
                : "not strong-named";
            Console.WriteLine($"PublicKeyToken: {tokenStr}");
            Console.WriteLine($"Architecture : {name.ProcessorArchitecture}");

            var product = currentAssembly.GetCustomAttribute<AssemblyProductAttribute>();
            var company = currentAssembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            var copyright = currentAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>();
            var config = currentAssembly.GetCustomAttribute<AssemblyConfigurationAttribute>();
            var fileVersion = currentAssembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            var infoVersion = currentAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

            Console.WriteLine($"Product      : {product?.Product ?? "not set"}");
            Console.WriteLine($"Company      : {company?.Company ?? "not set"}");
            Console.WriteLine($"Copyright    : {copyright?.Copyright ?? "not set"}");
            Console.WriteLine($"Config       : {config?.Configuration ?? "not set"}");
            Console.WriteLine($"File Version : {fileVersion?.Version ?? "not set"}");
            Console.WriteLine($"Info Version : {infoVersion?.InformationalVersion ?? "not set"}");
            Console.WriteLine($"IsDynamic    : {currentAssembly.IsDynamic}");
            Console.WriteLine($"IsFullyTrusted: {currentAssembly.IsFullyTrusted}");
            Console.WriteLine($"In GAC       : {currentAssembly.GlobalAssemblyCache}");

            Console.WriteLine("\n── Referenced Assemblies ──");
            foreach (AssemblyName refName in currentAssembly.GetReferencedAssemblies())
                Console.WriteLine($"  {refName.Name,-40} v{refName.Version}");

            Console.WriteLine("\n── Modules ──");
            foreach (Module module in currentAssembly.GetModules())
            {
                Console.WriteLine($"  Module   : {module.Name}");
                Console.WriteLine($"  ScopeName: {module.ScopeName}");
                Console.WriteLine($"  MDToken  : {module.MetadataToken}");
            }

            Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            bool alreadyLoaded = loadedAssemblies.Any(a => a.GetName().Name == "System.Linq");
            Console.WriteLine($"System.Linq already loaded: {alreadyLoaded}");

            // var weakRef = new WeakReference(loaded);
            // Console.WriteLine($"Assembly alive: {weakRef.IsAlive}");

            // var ctx    = new AssemblyLoadContext("PluginContext", isCollectible: true);
            // Assembly a = ctx.LoadFromAssemblyPath("/path/plugin.dll");
            // ctx.Unload();

            Type t1 = typeof(int);
            Type t2 = 42.GetType();
            bool same = t1 == t2;
            Console.WriteLine($"typeof(int) == (42).GetType(): {same}");

            // MethodInfo cachedAdd = calcType.GetMethod("Add")!;
            // for (int i = 0; i < 3; i++)
            //     Console.WriteLine(cachedAdd.Invoke(calc, new object[] { i, i * 2 }));

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