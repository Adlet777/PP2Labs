using System;

namespace Task2
{
    class Student
    {
        public string name;
        public string ID;
        public int year;

        public void PrintInfo()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(name + " " + ID + " " + (year + i));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student stud = new Student();
            stud.name = Console.ReadLine();
            stud.ID = Console.ReadLine();
            stud.year = int.Parse(Console.ReadLine());

            stud.PrintInfo();
        }
    }
}
