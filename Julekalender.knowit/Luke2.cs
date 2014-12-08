using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke2
    {
        static HashSet<int> primeSet = new HashSet<int>();
        static HashSet<int> candidateSet = new HashSet<int>();
        public static void Run()
        {
            int n = 9;
            primeSet = GetTwoDigitPrimes();
            generateCandidateSet(n);
            Console.WriteLine(CalcM(n));
        }
        private static void generateCandidateSet(int targetLength)
        {
            foreach (int prime in primeSet)
            {
                int start = Convert.ToInt32(prime.ToString().Substring(0, 1));
                if (start == targetLength)
                {
                    GenerateCandidates(prime.ToString(), targetLength);
                }
            }
        }
        private static void GenerateCandidates(string prefix, int targetLength)
        {
            if (prefix.Length < targetLength - 1)
            {
                foreach (int prime in primeSet)
                {
                    GenerateCandidates(prefix + prime, targetLength);
                }
            }
            else if (prefix.Length == targetLength - 1)
            {
                for (int i = 1; i < 10; i += 2)
                {
                    GenerateCandidates(prefix + i, targetLength);
                }
            }
            else if (prefix.Length == targetLength)
            {
                candidateSet.Add(int.Parse(prefix));
            }

        }
        private static int CalcM(int n)
        {
            foreach (int candidate in candidateSet)
            {
                if(HasOnlyUniquePrimes(candidate))
                {
                    return candidate;
                }
            }
            return -1;
        }
        private static bool HasOnlyUniquePrimes(int m)
        {
            int[] num = m.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < num.Length - 1; i++)
            {
                int primeCand = (num[i] * 10) + num[i+1];
                if (!isPrime(primeCand))
                {
                    return false;
                }
                else if (set.Contains(primeCand))
                {
                    return false;
                }
                else
                {
                    set.Add(primeCand);
                }
            }
            return true;
        }
        private static bool isPrime(int m)
        {
            if (primeSet.Contains(m))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static HashSet<int> GetTwoDigitPrimes()
        {
            HashSet<int> primes = new HashSet<int>();
            for (int i = 10; i < 100; i++)
            {
                if (CalcIsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
        private static bool CalcIsPrime(int m)
        {
            if (m == 1)
            {
                return false;
            }
            if (m == 2)
            {
                return true;
            }
            for (int i = 3; i < m; i++)
            {
                if (m % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
