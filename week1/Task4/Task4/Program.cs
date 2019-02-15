using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());      //entering an integer value
            int[,] arr = new int[a, a];                 //creating a double array with the size of previously entered integer

            for (int i = 0; i < a; i++)                 //starting a loop for each row in an array
            {
                for (int j = 0; j <= i; j++)            //starting a loop inside the loop for each element, that is less than value of a current row, in a row
                {
                        Console.Write("[*]");           //for each element inside the loop output "[*]"
                }
                Console.WriteLine();                    //output new line
            }
        }
    }
}
