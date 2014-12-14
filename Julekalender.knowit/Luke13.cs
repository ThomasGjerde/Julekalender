using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke13
    {
        public static void Run()
        {
            SortedSet<int> primes = Util.CalcPrimes(1000);
            int MIRPs = 0;
            foreach (int prime in primes)
            {
                string primeString = prime.ToString();
                string primeStringReverse = new string(primeString.Reverse().ToArray());
                if (primeString != primeStringReverse && primes.Contains(int.Parse(primeStringReverse)))
                {
                    MIRPs++;
                }
            }
            Console.WriteLine(MIRPs);
        }
    }
}
