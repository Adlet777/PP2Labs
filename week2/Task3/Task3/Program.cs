using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            FSI();
            InternalDirs();
        }
    

        static void FSI() 
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Адлет\Desktop\PP2Labs\week2");
            FileSystemInfo[] fi = dir.GetFileSystemInfos();

            foreach (var file in fi)
            {
                Console.WriteLine(file.Name);
                
                if (file.GetType() == typeof(DirectoryInfo))
                {
                    DirectoryInfo dir3 = new DirectoryInfo(Path.GetFullPath(file.FullName);
                    Console.WriteLine();
                    DirectoryInfo[] di3 = dir3.GetDirectories();
                }
                
            }
            Console.WriteLine();
        }

        static void InternalDirs()
        {
            DirectoryInfo dir2 = new DirectoryInfo(@"C:\Users\Адлет\Desktop\PP2Labs\week2");
            DirectoryInfo[] di = dir2.GetDirectories();

            foreach (var d in di)
            {
                Console.WriteLine("  " + d.Name);
                FileSystemInfo[] di2 = d.GetFileSystemInfos();
                foreach (var dir in di2)
                {
                    Console.WriteLine(dir.Name);
                }
                Console.WriteLine();
            }
        }
    }
}
