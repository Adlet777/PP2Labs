using System;
using System.IO;
using System.Collections.Generic;

namespace Task                                                                      //Creating an INTERFACE for the FAR Manager
{
    class Folder                                                                    //creating a new class named "Folder"
    {
        private int selectedIndex;                                                  //creating a private variable for an index
        List<FileSystemInfo> contents;                                              //creating a list with a type of filesysteminfo
        public string FullPath { get; set; }                                        //creating a getter and setter for a string FullPath
        public int GetSelectedIndex() { return selectedIndex; }                     //creating a function that returns the value of an index

        public Folder(DirectoryInfo directory, int index = 0)                       //create a private function named Folder with two inputs(directory and index)
        {
            selectedIndex = index;                                                  //giving a private variable the value of an index
            contents = new List<FileSystemInfo>();                                  //creating a new list

            foreach (var dir in directory.GetDirectories())                         //starting a foreach loop for every directory in directory
            {
                if (!dir.Attributes.HasFlag(FileAttributes.Hidden))                 //add to the list all the directories that are not hidden files
                {
                    contents.Add(dir);
                }

            }
            foreach (var file in directory.GetFiles())                              //starting a loop for every file in directory
            {
                if (!file.Attributes.HasFlag(FileAttributes.Hidden))                //add to the list every file that is not hidden
                {
                    contents.Add(file);
                }
            }


        }


        public void PrintFolder()                                                   //creating a function for printing a folder
        {
            Console.Clear();
            for (int i = 0; i < contents.Count; i++)                                //starting a for loop for the list
            {
                if (i == selectedIndex)                                             //giving the selected index red background colour
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;                   //for other case giving it a black background colour

                if (contents[i].GetType() == typeof(DirectoryInfo))                 //if the element of a list is of a type of directoryinfo then giving it white foreground colour
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;                  //in other cases(for fileinfos) giving it a yellow foreground colour

                Console.WriteLine(i + 1 + ". " + contents[i].Name);                 //writing all the elements in a list in an order

            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Адлет\Desktop\PP2Labs\week3\Folder");      //declaring the directoryinfo for a given path
            Folder folder = new Folder(dir);                                                            //creating a variable folder with a type of a class

            folder.PrintFolder();                                                                       //calling the function to print the interface
        }
    }
}
