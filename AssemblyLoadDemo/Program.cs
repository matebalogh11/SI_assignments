using System;
using System.Reflection;

namespace AssemblyLoadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string longName = "System.ServiceProcess, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
            BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;
            Assembly assembly = Assembly.Load(longName);
            Console.WriteLine(assembly.FullName);
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine("Type name: " + type.Name);
                MemberInfo[] members =  type.GetMembers(flags);
                foreach (MemberInfo member in members)
                {
                    Console.WriteLine($"Member name: {member.Name} and type: {member.MemberType}");
                }
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(Environment.NewLine);
            }
            Console.ReadKey();
        }
    }
}
