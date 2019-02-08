using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
                     
            FileStream fs = new FileStream(@"C:\Users\Адлет\Desktop\PP2Labs\week2\Task4\folder1\myfile.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write("Hey, this is my file!");

            sw.Close();

            File.Copy(@"C:\Users\Адлет\Desktop\PP2Labs\week2\Task4\folder1\myfile.txt", @"C:\Users\Адлет\Desktop\PP2Labs\week2\Task4\folder2\myfile.txt", true);
            File.Delete(@"C:\Users\Адлет\Desktop\PP2Labs\week2\Task4\folder1\myfile.txt");

            fs.Close();

            FileStream fs2 = new FileStream(@"C:\Users\Адлет\Desktop\PP2Labs\week2\Task4\folder2\myfile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs2);

            string line = sr.ReadLine();
            Console.WriteLine(line);
            sr.Close();

            File.Delete(@"C:\Users\Адлет\Desktop\PP2Labs\week2\Task4\folder2\myfile.txt");
            fs2.Close();

            
                 


        }
    }
}
