using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke9
    {
        public static void Run()
        {
            SortedSet<int> calculations = new SortedSet<int>();
            for (int i = 200; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (i + j >= 1000)
                    {
                        string result = i.ToString() + j.ToString() + (i + j).ToString();                      
                        if(String.Concat(result.OrderBy(c => c)) == "0123456789")
                        {
                            calculations.Add(i);
                            calculations.Add(j);
                        }
  
                    }
                }
            }
            foreach (int num in calculations)
            {
                Console.WriteLine(num);
                return;
            }

        }
    }
}
