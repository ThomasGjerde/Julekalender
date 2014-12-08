using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke1
    {
        public static int Run()
        {
            int sum = 0;
            for (int i = 1; i < 1000000; i++)
            {
                if (i.ToString() == new string(i.ToString().Reverse().ToArray()) && Convert.ToString(i, 8) == new string(Convert.ToString(i, 8).Reverse().ToArray()))
                {
                    sum++;
                }
            }
            return sum;
        }
    }
}
