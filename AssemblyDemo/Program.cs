using System;
using System.Reflection;

namespace AssemblyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string longName = "system, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            Assembly assembly = Assembly.Load(longName);
            ShowAssembly(assembly);

            Assembly ourAssembly = Assembly.GetExecutingAssembly();
            ShowAssembly(ourAssembly);

            Console.ReadKey();
        }

        static void ShowAssembly(Assembly assembly)
        {
            Console.WriteLine(assembly.FullName);
            Console.WriteLine(assembly.GlobalAssemblyCache);
            Console.WriteLine(assembly.Location);
            Console.WriteLine(assembly.ImageRuntimeVersion);
            Console.WriteLine(Environment.NewLine +  "Modules: ");
            foreach (Module module in assembly.GetModules())
            {
                Console.WriteLine(module.Name);
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}
