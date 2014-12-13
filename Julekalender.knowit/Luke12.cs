using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke12
    {
        public static void Run()
        {
            DateTime dt = new DateTime(1337,1,1);
            DateTime now = DateTime.Now;
            int f13 = 0;
            while (dt.DayOfWeek != DayOfWeek.Friday)
            {
                dt = dt.AddDays(1);
            }
            while (dt < now)
            {
                if (dt.Day == 13)
                {
                    f13++;
                }
                dt = dt.AddDays(7);
            }
            Console.WriteLine(f13);
        }
    }
}
