using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"C:\Users\Адлет\Desktop\PP2Labs\week2\Task4\folder1\myfile.txt";    //declaring two paths for to different locations of a file
            string path2 = @"C:\Users\Адлет\Desktop\PP2Labs\week2\Task4\folder2\myfile.txt";    

            FileStream fs = new FileStream(path1, FileMode.Create, FileAccess.Write);           //creating a filestream for the first path with an access to write
            StreamWriter sw = new StreamWriter(fs);                                             //starting streamwrite for this filestream

            sw.Write("Hey, this is my file!");                                                  //writing a phrase in this file

            sw.Close();

            File.Copy(path1, path2, true);                                                      //copying this file to the second path
            File.Delete(path1);                                                                 //deleting this file from the first path

            fs.Close();

            FileStream fs2 = new FileStream(path2, FileMode.Open, FileAccess.Read);             //creating a filestream for the second path with an access to read
            StreamReader sr = new StreamReader(fs2);                                            //starting streamreader for this filestream

            string line = sr.ReadLine();                                                        //read line 
            Console.WriteLine(line);                                                            //output the read line to console
            sr.Close();                                                                         //stop streamreader

            File.Delete(path2);                                                                 //delete this file from the second path
            fs2.Close();

            
                 


        }
    }
}
