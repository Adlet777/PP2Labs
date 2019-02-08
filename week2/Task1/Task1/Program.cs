using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Адлет\Desktop\PP2Labs\week2\text.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();

            int cnt = 0;

            for(int i = 0, j = s.Length -1; i<s.Length && j>=0; i++, j--)
            {
                if(s[i] == s[j])
                {
                    cnt++;
                }
            }

            if(cnt == s.Length)
            {
                Console.WriteLine("Yes");
            }
            if(cnt!= s.Length)
            {
                Console.WriteLine("No");
            }
            
        }
    }
}
