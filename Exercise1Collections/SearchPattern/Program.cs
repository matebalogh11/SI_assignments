using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace SearchPattern
{
    class Program
    {
        static List<FileInfo> FoundFiles;
        static List<FileSystemWatcher> watchers;
        static List<DirectoryInfo> archiveDirs;

        static void Main(string[] args)
        {
            string fileName = args[0];
            string directoryName = args[1];

            FoundFiles = new List<FileInfo>();
            watchers = new List<FileSystemWatcher>();

            DirectoryInfo rootDir = new DirectoryInfo(directoryName);
            if (!rootDir.Exists)
            {
                Console.WriteLine("The given directory does not exist.");
                return;
            }
            RecursiveSearch(FoundFiles, fileName, rootDir);
            Console.WriteLine($"Found {FoundFiles.Count} files");
            FoundFiles.ForEach(x => Console.WriteLine(x.FullName));

            foreach (FileInfo file in FoundFiles)
            {
                FileSystemWatcher newWatcher = new FileSystemWatcher(file.DirectoryName, file.Name);
                newWatcher.Changed += new FileSystemEventHandler(WatcherChanged);
                newWatcher.Deleted += new FileSystemEventHandler(WatcherDeleted);
                newWatcher.Renamed += new RenamedEventHandler(WatcherRenamed);
                newWatcher.EnableRaisingEvents = true;
                watchers.Add(newWatcher);
            }

            archiveDirs = new List<DirectoryInfo>();
            for (int i = 0; i < FoundFiles.Count; i++)
            {
                archiveDirs.Add(Directory.CreateDirectory("archive" + i.ToString()));
            }

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
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
        static void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                Console.WriteLine("{0} has been changed!", e.FullPath);
                FileSystemWatcher senderWatcher = (FileSystemWatcher)sender;
                int index = watchers.IndexOf(senderWatcher, 0);
                ArchiveFile(archiveDirs[index], FoundFiles[index]);
            }
        }
        static void WatcherDeleted(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                Console.WriteLine("{0} has been deleted!", e.FullPath);
                FileSystemWatcher check = (FileSystemWatcher)sender;
                watchers.Remove(check);
            }
        }

        static void WatcherRenamed(object sender, RenamedEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Renamed)
            {
                Console.WriteLine($"{e.OldFullPath} has been renamed to {e.FullPath}.");
            }
        }

        static void ArchiveFile(DirectoryInfo archiveDir, FileInfo fileToArchive)
        {
            FileStream input = fileToArchive.OpenRead();
            string path = string.Format("{0}\\{2:yyyy-MM-dd_hh-mm-ss-tt}-{1}.gz", archiveDir.FullName, fileToArchive.Name, DateTime.Now);
            FileStream output = File.Create(path);
            GZipStream Compressor = new GZipStream(output, CompressionMode.Compress);
            input.CopyTo(Compressor);

            Compressor.Close();
            input.Close();
            output.Close();
        }
    }
}
