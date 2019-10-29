using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDirectoryWatcher
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** The Amazing File Watcher App *****\n");
            var watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"C:\MyFolder";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName |
                                   NotifyFilters.DirectoryName;
            watcher.Filter = "*.txt";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;

            Console.WriteLine(@"Press 'q' to quit app.");
            while (Console.Read() != 'q') ;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} {1}!", e.FullPath, e.ChangeType);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
