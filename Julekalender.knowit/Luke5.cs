using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke5
    {
        static HashSet<int> bigNumbers;
        static SortedSet<int> primes;
        public static void Run()
        {
            GenerateBigNumbers();
            primes = NewCalcPrimes(987654321/2);
            List<int> factorList = new List<int>();
            foreach (int i in bigNumbers)
            {
                factorList.Add(FindHighestPrimeFactor(i));
            }
            factorList.Sort();
            Console.WriteLine(factorList[0]);
        }
        private static int FindHighestPrimeFactor(int num)
        {
                foreach (int prime in primes.Reverse())
                {
                    if (num % prime == 0)
                    {
                        return prime;
                    }
                }
                return 1000000000;
        }
        private static void GenerateBigNumbers()
        {
            int[] init = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bigNumbers = new HashSet<int>();
            MakePermutation(init, 0);
        }
        private static void AddToBigNumbers(int[] array)
        {
            string tempString = "";
            for (int i = 0; i < array.Length; i++)
            {
                tempString += array[i];
            }
            bigNumbers.Add(int.Parse(tempString));
        }
        private static void MakePermutation(int []array,int startIndex ) {
            if (startIndex == array.Length)
            {
                AddToBigNumbers(array);
            }
            else
            {
                for (int i = startIndex; i < array.Length; i++)
                {
                    int temp = array[startIndex];
                    array[startIndex] = array[i];
                    array[i] = temp;
                    MakePermutation(array, startIndex + 1);
                    temp = array[startIndex];
                    array[startIndex] = array[i];
                    array[i] = temp;
                }
            }
        }
        private static SortedSet<int> NewCalcPrimes(int n)
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
            foreach (KeyValuePair<int,bool> pair in A)
            {
                if (pair.Value == true)
                {
                    ret.Add(pair.Key);
                }
            }
            return ret;
        }
    }
}
