using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());          //entering an integer

            int[] ar = new int[a];                          //creating an array with a size of an integer that has been created in the previous step
            int[] br = new int[a];                          //creating another array with the same size

            string[] s = Console.ReadLine().Split(" ");     //entering string array and divide it by " "

            for (int i = 0; i < s.Length; i++)              //creating a loop and entering all the elements of a string array into the first array
            {
                ar[i] = int.Parse(s[i]);
            }

            bool c = true;                                  //declare a boolean
            int cnt = 0;                                    //declare a variable with a type of integer that is equal to 0 
                                                     

            foreach (int num in ar)                         //starting a "foreach" cycle for all the elements in the first array
            {
                for (int i = 2; i < num; i++)               //creating a loop for each element of an array stating from the value 2 until the element itself and incrementing by 1
                {
                    if (num % i == 0)                       //in a loop making an "if" statement, according to which if a remainder of the element divided by numbers from 2 to element is equal to 0, then the boolean variable should change its' value
                    {
                        c = false;

                    }

                }

                if (c == true && num != 1)                  //creating an "if" statement according to which, if boolean is true and element is not equal to 1 then the element is added into the second array and counting variable is incremented by 1
                {

                    for (int i = cnt; i < br.Length; i++)
                    {
                        br[i] = num;
                    }
                    cnt++;
                }

                c = true;                                   //making boolean true again in order to repeat the whole process for the next element
            }

            Console.WriteLine(cnt);                         //output the counting variable on a console on a separate line as the size of a new array

            for (int i = 0; i < cnt; i++)                   //starting a loop from 0 to the size of a new array incrementing by 1
            {
                Console.Write(br[i] + " ");                 //output every element from the array with the " " between each element
            }
        }
    }
}
