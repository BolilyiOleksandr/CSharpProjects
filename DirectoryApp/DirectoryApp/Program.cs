using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Directory(Info) *****\n");
            ShowWindowsDirectoryInfo();
            DisplayImageFiles();
            //ModifyAppDirectory();
            FunWithDirectoryType();

            Console.ReadLine();
        }

        private static void ShowWindowsDirectoryInfo()
        {
            var dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("************************\n");
        }

        private static void DisplayImageFiles()
        {
            var dir = new DirectoryInfo(@"C:\Users\JA0006284\Downloads\Images");
            var imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);

            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("File name: {0}", f.Name);
                Console.WriteLine("File size: {0}", f.Length);
                Console.WriteLine("Creation: {0}", f.CreationTime);
                Console.WriteLine("Attributes: {0}", f.Attributes);
                Console.WriteLine("************************************");
            }
        }

        private static void ModifyAppDirectory()
        {
            var dir = new DirectoryInfo(@"C:\");
            dir.CreateSubdirectory("MyFolder");
            var myDataFolder = dir.CreateSubdirectory(@"MyFolder\Data");

            Console.WriteLine("New Folder is: {0}", myDataFolder);
        }

        private static void FunWithDirectoryType()
        {
            var drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives:");
            foreach (string s in drives)
            {
                Console.WriteLine("--> {0}", s);
            }
        }

    }
}
