using System.Reflection;
using System.Runtime.Loader;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new PluginLoadContext();

            Assembly assembly = context.LoadFromAssemblyPath("C:\\Users\\HEYii\\source\\repos\\WPF-Interview\\Sample\\Plugin\\bin\\Debug\\net8.0\\Plugin.dll");
            var type = assembly.GetType("Plugin.Main");
            dynamic? instance = Activator.CreateInstance(type) as dynamic;

            Console.WriteLine($"Name:{instance.GetName()}");

            instance.Execute();

            context.Unload();
            Console.WriteLine("Plugin has been uploaded");

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.ReadLine();
        }
    }

    public class PluginLoadContext : AssemblyLoadContext
    {
        public PluginLoadContext() : base(isCollectible: true)
        {

        }

        protected override Assembly? Load(AssemblyName assemblyName)
        {
            //自定义解析依赖项

            return base.Load(assemblyName);
        }
    }
}
