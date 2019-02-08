using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream fs = new FileStream(@"C:\Users\Адлет\Desktop\PP2Labs\week2\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            string[] nums = s.Split(" ");

            int[] ar = new int[nums.Length];
            int[] ar2 = new int[nums.Length];

                for(int i=0; i < nums.Length; i++)
            {
                ar[i] = Convert.ToInt32(nums[i]);
            }

            bool b = true;
            int cnt = 0;

            foreach(int num in ar)
            {
                for(int i=2; i<num; i++)
                {
                    if(num%i == 0)
                    {
                        b = false;
                    }
                }

                if(num!= 1 && b == true)
                {
                    for(int i=cnt; i<ar2.Length; i++)
                    {
                        ar2[i] = num;
                    }
                    cnt++;
                }

                b = true;
            }

          

            FileStream fs2 = new FileStream(@"C:\Users\Адлет\Desktop\PP2Labs\week2\output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);

            for(int i =0; i<cnt; i++)
            {
                sw.Write(ar2[i] + " ");
            }

            sw.Close();
            fs2.Close();

            sr.Close();
            fs.Close();

            FileStream fs3 = new FileStream(@"C:\Users\Адлет\Desktop\PP2Labs\week2\output.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr2 = new StreamReader(fs3);

            string line = sr2.ReadLine();
            string[] line2 = line.Split(" ");

                for(int i=0; i<line2.Length; i++)
            {
                Console.Write(line2[i] + " ");
            }

            sr2.Close();
            fs3.Close();

            File.Delete(@"C:\Users\Адлет\Desktop\PP2Labs\week2\output.txt");
        }
    }
}
