using System;

namespace TASK3_2
{
    class Program
    {
        static void Main(string[] args)
        {
                                                                    

            int a = Convert.ToInt32(Console.ReadLine());                   //entering an integer   
                                                                
                                                                
            string[] s = Console.ReadLine().Split(" ");                    //reading a string line, divide it by " " and put each division inside a string array as an element   
            int[] arr = new int[a];                                        //creating an array with the size of a previously entered integer value     
            for (int i = 0; i < arr.Length; i++)                           //starting a loop from 0 to the sie of an array   
            {
                arr[i] = int.Parse(s[i]);                                  //input each element of a string array inside the second array as an integer     
            }

            int[] array = new int[a * 2];                                  //creating the new array with a size of a doubled previously entered integer
            for (int i = 0, j = 0; i < a * 2 && j < a; i += 2, j++)        //starting a loop with 2 variables, one starting from 0 to the size of a new array each time incrementing by 2, and the other starting 0 to first variable each time incrementing by 1
            {
                array[i] = arr[j];                                         // for each i-th and (i+1)-th element of the new array giving a value of j-th element of a previous array       
                array[i + 1] = arr[j];
            }

            for (int i = 0; i < array.Length; i++)                         //starting a loop for a new array         
            {
                Console.Write(array[i] + " ");                             //output every element of an array with " " between them     
            }

                       
        }
    }
}
