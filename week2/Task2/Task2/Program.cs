using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream fs = new FileStream(@"C:\Users\Адлет\Desktop\PP2Labs\week2\input.txt", FileMode.Open, FileAccess.Read);  //creating a file stream or a given path with an access to read
            StreamReader sr = new StreamReader(fs);                                                                             //creating a streamreader for a filestream

            string s = sr.ReadLine();                                   //entering a string line
            string[] nums = s.Split(" ");                               //divide this line by " " and enter each dividion into a string array

            int[] ar = new int[nums.Length];                            //creating two arrays with sizes of the size of a string array
            int[] ar2 = new int[nums.Length];

                for(int i=0; i < nums.Length; i++)                      //starting a loop and entering into the first array all the converted into integer elements of a string array
            {
                ar[i] = Convert.ToInt32(nums[i]);
            }

            bool b = true;                                              //declaring a boolean variable and giving it a "true" value
            int cnt = 0;                                                //declaring a "count" integer and giving it a value of 0 

            foreach(int num in ar)                                      //starting foreach cycle for every element of a first array
            {
                for(int i=2; i<num; i++)                                //starting a loop from 2 to the value of a current element every time incrementing by 1
                {
                    if(num%i == 0)                                      //if the remainder of a division of the element on integer of a cycle is equal to 0 the giving a boolean integer the value of "false"
                    {
                        b = false;
                    }
                }

                if(num!= 1 && b == true)                                //if the number is not the 1 and boolean integer remained "true " after the loop then entering this value into the second array and incrementing "count" by 1
                {
                    for(int i=cnt; i<ar2.Length; i++)
                    {
                        ar2[i] = num;
                    }
                    cnt++;
                }

                b = true;                                               //giving the boolean "true" value again to start the process for the next element
            }

          

            FileStream fs2 = new FileStream(@"C:\Users\Адлет\Desktop\PP2Labs\week2\output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);

            for(int i =0; i<cnt; i++)
            {
                sw.Write(ar2[i] + " ");                                 //creating a new .txt file and wrtiting in it all the value of a second array
            }

            sw.Close();
            fs2.Close();

            sr.Close();
            fs.Close();

            FileStream fs3 = new FileStream(@"C:\Users\Адлет\Desktop\PP2Labs\week2\output.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr2 = new StreamReader(fs3);

            string line = sr2.ReadLine();
            string[] line2 = line.Split(" ");                          //read the created .txt file

                for(int i=0; i<line2.Length; i++)
            {
                Console.Write(line2[i] + " ");
            }

            sr2.Close();
            fs3.Close();

            File.Delete(@"C:\Users\Адлет\Desktop\PP2Labs\week2\output.txt");    //delete the created .txt file
        }
    }
}
