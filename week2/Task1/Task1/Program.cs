using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Адлет\Desktop\PP2Labs\week2\text.txt", FileMode.Open, FileAccess.Read);   //declaring a new filestream for a chosen path with an access to read
            StreamReader sr = new StreamReader(fs);                                                                             //declaring a streamreader for a filestream

            string s = sr.ReadLine();                                           //declaring a string variable and giving it a value of a line read from a streamreader

            int cnt = 0;                                                        //declaring a new integer value that is equal to 0

            for(int i = 0, j = s.Length -1; i<s.Length && j>=0; i++, j--)       //starting a loop for two integers, one is starting from the beginning of a string to its' end and the other from the end of it to its' beginning
            {
                if(s[i] == s[j])                                                //comparing the values of two loops if they're equal increment previously entered integer by one
                {
                    cnt++;
                }
            }

            if(cnt == s.Length)                                                 //if the integer is equal to the size of a string then output "Yes"
            {
                Console.WriteLine("Yes");
            }
            if(cnt!= s.Length)
            {
                Console.WriteLine("No");                                        //otherwise, output "No"
            }
            
        }
    }
}
