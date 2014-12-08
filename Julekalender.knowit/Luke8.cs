using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke8
    {
        public static void Run()
        {
            for (int i = 1; i < 10000; i++)
            {
                if (i == GetDivisorSum(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        private static int GetDivisorSum(int num)
        {
            int sum = 0;
            for (int i = 1; i < num; i++)
            {
                if (num % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
    
}
