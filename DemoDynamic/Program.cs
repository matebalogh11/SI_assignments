using System;
using System.Reflection.Emit;
using System.Reflection;

namespace DemoDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName myName = new AssemblyName();
            myName.Name = "Mynewproject";
            myName.Version = new Version("1.0.0.0");
            AppDomain currentDomain = AppDomain.CurrentDomain;
            AssemblyBuilder myAsBuilder =  currentDomain.DefineDynamicAssembly(myName, AssemblyBuilderAccess.ReflectionOnly);
            ModuleBuilder myModBuilder = myAsBuilder.DefineDynamicModule("CodeModule", "DemoAssembly.dll");
            TypeBuilder myTypeBuilder = myModBuilder.DefineType("myType", TypeAttributes.Public);
            Type finalObj = myTypeBuilder.CreateType();
            foreach (MemberInfo info in finalObj.GetMembers())
            {
                Console.WriteLine($"Member type: {info.MemberType} and name: {info.Name}");
            }
            Console.ReadKey();
        }
    }
}
