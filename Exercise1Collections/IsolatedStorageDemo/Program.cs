using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace IsolatedStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream myStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, userStore);
            StreamWriter myWriter = new StreamWriter(myStream);
            myWriter.Write("It's my first sentence here.");
            myWriter.Close();

            string[] files = userStore.GetFileNames("UserSettings.set");
            if (files.Length == 0) Console.WriteLine("Empty file sorry.");
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Open, userStore);
            StreamReader myReader = new StreamReader(userStream);
            string content = myReader.ReadToEnd();
            Console.WriteLine(content);
            Console.ReadKey();
        }
    }
}
