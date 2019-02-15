using System;

namespace Task2
{
    class Student                                                          //creating a new class "Student"
    {
        private string name;                                               //creating three private variables
        private string ID;
        private int year;

        public void PrintInfo(string name, string ID, int year)            //creating a public function to acces three private variables
        {
            for (int i = 0; i < 4; i++)                                    //inside a function starting a loop 
            {
                Console.WriteLine(name + " " + ID + " " + (year + i));     //in a loop output three variables with the third one incrementing on one each time
            }
        }
    }

    class Program                                                           //
    {
        static void Main(string[] args)
        {
            Student stud = new Student();                                   //creating element of a class "Student"
            string name = Console.ReadLine();                               //entering a string variable
            string ID = Console.ReadLine();                                 //entering a string variable
            int year = int.Parse(Console.ReadLine());                       // entering an integer variable

            stud.PrintInfo(name, ID, year);                                 //calling a function from a class "Student"
        }
    }
}
