using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke14
    {
        public static void Run()
        {
            int counter = 0;
            for (int i = 0; i < 100000; i++)
            {
                string numString = i.ToString();
                if (IsFlippable(numString) && Flip(numString) == numString)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
        private static bool IsFlippable(string input)
        {
            if (input.Contains('2') || input.Contains('3') || input.Contains('4') || input.Contains('5') || input.Contains('7'))
            {
                return false;
            }
            return true;
        }
        private static string Flip(string input)
        {
            input = input.Replace('6', 'A');
            input = input.Replace('9', '6');
            input = input.Replace('A', '9');
            return new string(input.Reverse().ToArray());
        }
    }
}
