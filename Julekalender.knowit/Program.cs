using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace Julekalender.knowit
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();

            Luke12.Run();
            
            timer.Stop();
            if (timer.ElapsedMilliseconds > 0)
            {
                Console.WriteLine("Run time: " + timer.ElapsedMilliseconds + "ms");
            }
            else
            {
                Console.WriteLine("Run time: " + ((double)timer.ElapsedTicks / (double)10000) + "ms");
            }
            Console.Read();
        }
    }
}
