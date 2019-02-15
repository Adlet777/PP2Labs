using System;
using System.Collections.Generic;
using System.IO;

namespace Addition2
{
                                                                                                 //RECURSION
    class Program
    {
        static void rec(DirectoryInfo dir, string space)                                         //CREATING A RECURSION FUNCTION
        {
            Console.WriteLine(space + dir.Name);                                                 //OUTPUT CURRENT STRING "SPACE" AND A NAME OF A DIRECTORY
            space += "     ";                                                                    //INCREASING THE LENGTH OF A CURRENT STRING "SPACE"
            FileSystemInfo[] fsi = dir.GetFileSystemInfos();                                     //GETTING ALL THE FILESYSTEMINFOS FROM THE PREVIOUS DIRECTORY AND PUTTING THEM INSIDE AN ARRAY
            for (int i = 0; i < fsi.Length; i++)                                                 //STARTING A LOOP FROM 0 TO THE LENGTH OF AN ARRAY
            {
                if (fsi[i].GetType() == typeof(FileInfo))                                        //IF AN ELEMENT OF AN ARRAY HAS A TYPE OF FILEINFO THEN OUTPUT INCREASED STRING "SPACE" AND ELEMENT'S NAME
                {
                    Console.WriteLine(space + fsi[i].Name);
                }

                else
                {
                    rec(fsi[i] as DirectoryInfo, space);                                         //IF AN ELEMENT HAS A TYPE OF DIRECTORYINFO, THEN STARTING THE RECURSION AGAIN ON A GIVEN DIRECTORY
                }
            }
        }


        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Адлет\Desktop\PP2Labs\week2"); //TAKING DIRECTORY INFO FROM A CHOSEN PATH
            rec(dir, "");                                                                   //APPLYING A RECURSION FUNCTION ON A CHOSEN DIRECTORY
        }
    }
}
