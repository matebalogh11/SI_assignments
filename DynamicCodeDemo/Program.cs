using System;
using System.Reflection;

namespace DynamicCodeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.Web.dll";
            Assembly assembly = Assembly.LoadFrom(path);
            Type type = assembly.GetType("System.Web.HttpUtility");
            MethodInfo info1 = type.GetMethod("HtmlEncode", new Type[] { typeof(string) });
            MethodInfo info2 = type.GetMethod("HtmlDecode", new Type[] { typeof(string) });
            string original = "me & dog <best friends ever!>";
            Console.WriteLine(original);
            string encoded = (string)info1.Invoke(null, new object[] { original });
            Console.WriteLine(encoded);
            string decoded = (string)info2.Invoke(null, new object[] { encoded });
            Console.WriteLine(decoded);
            Console.ReadKey();
        }
    }
}
