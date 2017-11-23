using System.IO;
using System.Text;

namespace FileEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\bmate\Documents\Overwatch\Settings\Settings_v0.ini"))
            using (StreamWriter writer = new StreamWriter("boot-utf47.txt", false, Encoding.UTF7))
            writer.WriteLine(reader.ReadToEnd());
        }
    }
}
