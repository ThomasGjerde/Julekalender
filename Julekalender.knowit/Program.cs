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

            Luke9.Run();
            
            timer.Stop();
            Console.WriteLine("Run time: " + timer.ElapsedMilliseconds + "ms");
            Console.Read();
        }
    }
}
