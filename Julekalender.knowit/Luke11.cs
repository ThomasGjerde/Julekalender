using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke11
    {
        static Dictionary<Tuple<int,int>, int> primeSums;
        static List<int> primes;
        static int max = 10000000;
        public static void Run()
        {
            primeSums = new Dictionary<Tuple<int, int>, int>();
            SortedSet<int> primeSet = CalcPrimes(max);
            primes = new List<int>();
            foreach (int prime in primeSet)
            {
                primes.Add(prime);
            }
            foreach (int prime in primeSet)
            {
                if (IsContinuousPrimeSum(prime, 7) && IsContinuousPrimeSum(prime, 17) && IsContinuousPrimeSum(prime, 41) && IsContinuousPrimeSum(prime, 541))
                {
                    Console.WriteLine(prime);
                    return;
                }
            }
        }
        private static SortedSet<int> CalcPrimes(int n)
        {
            Dictionary<int, bool> A = new Dictionary<int, bool>();
            for (int i = 2; i <= n; i++)
            {
                A[i] = true;
            }
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (A[i] == true)
                {
                    for (int j = (int)Math.Pow(i, 2); j < n; j += i)
                    {
                        A[j] = false;
                    }
                }
            }
            SortedSet<int> ret = new SortedSet<int>();
            foreach (KeyValuePair<int, bool> pair in A)
            {
                if (pair.Value == true)
                {
                    ret.Add(pair.Key);
                }
            }
            return ret;
        }
        private static bool IsContinuousPrimeSum(int sum, int num)
        {
            for (int i = 0; i < primes.Count; i++)
            {
                int calcSum = CalcContinuousPrimeSum(i, num);
                if (calcSum == sum)
                {
                    return true;
                }
                else if (calcSum > sum || calcSum == -1 || calcSum > max)
                {
                    return false;
                }

            }
            return false;
        }
        private static int CalcContinuousPrimeSum(int startIndex, int num)
        {
            if(primeSums.ContainsKey(new Tuple<int,int>(startIndex,num)))
            {
                return primeSums[new Tuple<int, int>(startIndex, num)];
            }
            int sum = 0;
            if ((startIndex + num) >= primes.Count)
            {
                return -1;
            }
            for (int i = startIndex; i < startIndex + num; i++)
            {
                sum += primes[i];
            }
            primeSums.Add(new Tuple<int, int>(startIndex, num), sum);
            return sum;
        }
    }
}
