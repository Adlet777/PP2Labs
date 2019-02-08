using System;

namespace Task3
{

    class Doub                                                                  //declaring a new class named Doub
    {
        public int[] a;                                                         //creating a public integer array in a new class
        public int length;                                                      //creating a public integer variable

        public void Count()                                                     //creating a public method Count() 
        {
            int[] array = new int[length * 2];                                  //declaring a new integer array with a size of a previously declared integer value doubled
            for (int i = 0, j = 0; i < length * 2 && j < length; i += 2, j++)   //starting a loop with 2 variables, one starting from 0 to the size of a new array each time incrementing by 2, and the other starting 0 to first variable each time incrementing by 1
            {
                array[i] = a[j];                                                //for the two elements of a new array giving the values of the one element of the first array 
                array[i + 1] = a[j];
            }

            for (int i = 0; i < array.Length; i++)                              //starting a loop from 0 to the end of a size of a new array, incrementing by 1    
            {
                Console.Write(array[i] + " ");                                  //output each element of an array with the " " between each element
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Doub d = new Doub();                                                //calling a class Doub

            int a = Convert.ToInt32(Console.ReadLine());                        //entering value and converting it to integer
            d.length = a;                                                       //giving the public integer in a class Doub the value of an entered integer from the last step
                                                         

            string[] s = Console.ReadLine().Split(" ");                         //entering string line and divide it by " "
            int[] arr = new int[a];                                             //creating an array with the size of an entered integer from the last steps
            for (int i = 0; i < arr.Length; i++)                                //starting a for loop from 0 to the size of a new array incrementing by 1
            {
                arr[i] = int.Parse(s[i]);                                       //for each element of a new array giving the value of an element from the same position from string array, converted to integer
            }

            d.a = arr;                                                          //for the array from the class Doub giving a value of a previously created array
            d.Count();                                                          //calling the function Count()
        }
    }
}
