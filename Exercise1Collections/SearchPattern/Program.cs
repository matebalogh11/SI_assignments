using System;
using System.Collections.Generic;
using System.IO;

namespace SearchPattern
{
    class Program
    {
        static List<FileInfo> FoundFiles;

        static void Main(string[] args)
        {
            string fileName = args[0];
            string directoryName = args[1];
            FoundFiles = new List<FileInfo>();

            DirectoryInfo rootDir = new DirectoryInfo(directoryName);
            if (!rootDir.Exists)
            {
                Console.WriteLine("The given directory does not exist.");
                return;
            }
            RecursiveSearch(FoundFiles, fileName, rootDir);
            Console.WriteLine($"Found {FoundFiles.Count} files");
            FoundFiles.ForEach(x => Console.WriteLine(x.FullName));
            Console.ReadKey();
        }

        static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDirectory)
        {
            foreach (FileInfo file in currentDirectory.GetFiles())
            {
                if (file.Name == fileName)
                {
                    FoundFiles.Add(file);
                }
            }
            foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
            {
                RecursiveSearch(foundFiles, fileName, dir);
            }
        }
    }
}
