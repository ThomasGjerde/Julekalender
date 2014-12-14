using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Util
    {
        public static SortedSet<int> CalcPrimes(int n)
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
    }
}
