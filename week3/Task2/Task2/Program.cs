using System;
using System.Collections.Generic;
using System.IO;

namespace Task2                                                                         //FAR manager
{
    enum Mode { Directory, File };                                                      //declaring the enumeration for the mode of a current file(хранилище состояния)

    class Folder                                                                        //creating a new class named Folder
    {
        private int selectedIndex;                                                      //declaring a private integer variable 
        List<FileSystemInfo> contents;                                                  //creating a list
        public string FullPath { get; set; }                                            //creating a gettter and setter for FullPath
        public int GetSelectedIndex() { return selectedIndex; }                         //creating a function that returns an index

        public Folder(DirectoryInfo directory, int index = 0)                           //creating a public function named Folder with two inputs (directory and index)
        {
            selectedIndex = index;                                                      //giving a private variable the value of index
            contents = new List<FileSystemInfo>();                                      //creating a new list

            foreach (var dir in directory.GetDirectories())                             //adding to list each directory that is not hidden
            {
                if (!dir.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    contents.Add(dir);
                }

            }
            foreach (var file in directory.GetFiles())                                  //adding to list each file that is not hidden
            {
                if (!file.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    contents.Add(file);
                }
            }

            FullPath = directory.FullName;                                              //giving the Fullpath the value of a name of a current directory

        }


        public void PrintFolder()                                                       //creating a function for printing a folder
        {
            Console.Clear();
            for (int i = 0; i < contents.Count; i++)                                    //starting a loop for the list
            {
                if (i == selectedIndex)                                                 //giving the red foreground colour for the index line
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;                       //giving black foreground colour in other cases

                if (contents[i].GetType() == typeof(DirectoryInfo))                     //for the elements with the type of directoryinfo giving the white foreground colour
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;                      //in other cases(fileinfo) giving yellow foreground colour

                Console.WriteLine(i + 1 + ". " + contents[i].Name);                     //output all the elements in an order

            }

        }

        public void Up()                                                                //creating the function for the UpArrow key
        {
            if (selectedIndex == 0)                                                     //if the index at the very top then going to the last element in the list
            {
                selectedIndex = contents.Count - 1;
            }
            else
                selectedIndex--;                                                        //in other cases decreasing index by one
        }

        public void Down()                                                              //creating the function for the DownArrow key
        {
            if (selectedIndex == contents.Count - 1)                                    //if the index at the bottom then making index 0 again
            {
                selectedIndex = 0;
            }
            else
                selectedIndex++;                                                        //in other cases increment index by 1
        }

        public FileSystemInfo GetSelectedObj()                                          //creating a new function with a type of filesysteminfo to return the current object
        {
            return contents[selectedIndex];
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Адлет\Desktop\PP2Labs\week3\Folder");          //declaring a directory for a given path
            Folder folder = new Folder(dir);                                                                //calling a class Folder and giving the current directory to it

            Stack<Folder> dirs = new Stack<Folder>();                                   //creating a stack with a type of the class Folder
            dirs.Push(folder);                                                          //pushing directory into the stack

            bool run = true;                                                            //declaring a boolean variable and giving it a value "true"

            Mode mode = Mode.Directory;                                                 //giving the value of a first state to the enumerator

            while (run)                                                                 //starting a while loop
            {
                if (mode == Mode.Directory)                                             //printing upper layer of a stack if its a directory
                {
                    dirs.Peek().PrintFolder();
                }

                ConsoleKeyInfo pressedkey = Console.ReadKey();                          //waiting for user to press the key button

                switch (pressedkey.Key)                                                 //starting a "switch" for the pressed key
                {
                    case ConsoleKey.UpArrow:                                                                //if pressed key is UpArrow calling the Up() function
                        dirs.Peek().Up();
                        break;
                    case ConsoleKey.DownArrow:                                                              //if pressed key is DownArrow calling the Down() function
                        dirs.Peek().Down();
                        break;
                    case ConsoleKey.Enter:                                                                  //if pressed key is Enter 
                        FileSystemInfo selected = dirs.Peek().GetSelectedObj();                             //taking a filesysteminfo of a current object

                        if (selected.GetType() == typeof(DirectoryInfo))                                    //if the object is directory then push to the stack
                        {
                            dirs.Push(new Folder(selected as DirectoryInfo));
                        }
                        else
                        {
                            string fullPath = (selected as FileInfo).FullName;                              //in other cases(for files) taking the fullname of a file
                            FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);       //starting a filestream for the path of a fullname of a file with an access to read
                            StreamReader sr = new StreamReader(fs);                                         //starting a streamreader for the filestream

                            Console.BackgroundColor = ConsoleColor.Black;                                   //making the background colour black and the foreground colour yellow
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.Clear();
                            Console.Write(sr.ReadToEnd());                                                  //output the containings of a file on console

                            mode = Mode.File;                                                               //changing enumerator state to file

                            sr.Close();
                            fs.Close();
                        }
                        break;
                    case ConsoleKey.Escape:                                                                 //if pressed key is Escape
                        if (mode == Mode.Directory)                                                         // if enumerator state is directory than stopping switch by changing the boolean variable to "false"
                        {
                            run = false;
                        }
                        else
                        {
                            mode = Mode.Directory;                                                          //in other cases changing the enumerator state to directory
                        }
                        break;
                    case ConsoleKey.Backspace:                                                              //if pressed key is Backspace 
                        if (dirs.Count > 1)
                        {
                            dirs.Pop();                                                                     //if stack is not empty deleting the upper layer
                        }
                        break;
                    default:
                        break;
                    case ConsoleKey.D:                                                                      //if pressed key is D
                        string currentPath = dirs.Peek().FullPath;                                          //declaring the current path by calling the getter FullPath
                        FileSystemInfo selected2 = dirs.Peek().GetSelectedObj();                            //taking filesysteminfo of a selected object
                        if (selected2.GetType() == typeof(FileInfo))                                         
                        {
                            File.Delete(selected2.FullName);
                        }
                        else
                        {
                            Directory.Delete(selected2.FullName);                                           //deleting the object
                        }
                        if (dirs.Count > 1)
                        {
                            Folder currentFolder = dirs.Pop();                                              //if stack is not empty then deleting the upper layer to "refresh" the page
                            if (currentFolder.GetSelectedIndex() != 0)
                            {
                                dirs.Push(new Folder(new DirectoryInfo(currentPath), currentFolder.GetSelectedIndex() - 1));    //if index is not 0 then decrease index by one after deleting object
                            }
                            else
                            {
                                dirs.Push(new Folder(new DirectoryInfo(currentPath), currentFolder.GetSelectedIndex()));
                            }
                        }

                        break;
                    case ConsoleKey.R:                                                                      //if pressed key is R
                        FileSystemInfo selected3 = dirs.Peek().GetSelectedObj();                            //getting filesysteminfo on the selected object
                        string currentPath2 = dirs.Peek().FullPath;                                         //declaring the current path by calling the getter of an upper layer of a stack
                        if (selected3.GetType() == typeof(FileInfo))                                        //if the object is file
                        {
                            Console.WriteLine("Please enter a new file name:");
                            string oldname = selected3.FullName;                                            //creating a string of a fullname of a file
                            string newname = Console.ReadLine();                                            //entering the new name of a file
                            string newpath = oldname.Replace(selected3.Name, newname);                      //creating a new path of a file by replacing the old name in an old path by the new name

                            File.Move(oldname, newpath);                                                    //moving file from old path to new path
                            File.Delete(oldname);                                                           //deleting old file
                        }
                        if (selected3.GetType() == typeof(DirectoryInfo))                                   //if the objest is directory
                        {
                            Console.WriteLine("Please enter a new directory name:");
                            string oldpath = selected3.FullName;                                            //declaring an old path by using a getter to take a full name of a directory
                            string newname = Console.ReadLine();                                            //entering the new name of a directory
                            string newpath = oldpath.Replace(selected3.Name, newname);                      //changing the path of a directory by replacing the old name in its' full name by the new name

                            Directory.Move(oldpath, newpath);                                               //move the directory from old path to new path

                        }

                        if (dirs.Count > 1)
                        {
                            Folder currentFolder = dirs.Pop();
                            dirs.Push(new Folder(new DirectoryInfo(currentPath2), currentFolder.GetSelectedIndex()));   //to "refresh" the page if stack is not empty delete the upper layer of it and push the current one
                        }

                        break;

                }
            }
        }
    }
}
