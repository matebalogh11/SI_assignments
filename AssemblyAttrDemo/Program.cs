using System;
using System.Reflection;

namespace AssemblyAttrDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type assemblyDesc = typeof(AssemblyDescriptionAttribute);
            object[] obj =  assembly.GetCustomAttributes(assemblyDesc, false);
            if (obj.Length > 0)
            {
                AssemblyDescriptionAttribute attr;
                attr = obj[0] as AssemblyDescriptionAttribute;
                Console.WriteLine(attr.Description);
            }
            Console.ReadKey();
        }
    }
}
