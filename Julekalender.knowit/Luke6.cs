using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke6
    {
        public static void Run()
        {
            Console.WriteLine(GetUniqueProducts(8000, 8000));
        }
        private static int GetUniqueProducts(int n, int m)
        {
            HashSet<int> products = new HashSet<int>();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    products.Add(i * j);
                }
            }
            return products.Count;
        }
    }
}
