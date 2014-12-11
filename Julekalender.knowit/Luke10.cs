using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender.knowit
{
    class Luke10
    {
        static bool[] drunk;
        public static void Run()
        {
            //This is actually faster than using a List<>
            drunk = new bool[1500];
            int lastIndex = 0;
            for (int i = 0; i < drunk.Length - 1; i++)
            {
                int relativeIndex = GetNextSober(lastIndex)+1;
                lastIndex = GetNextSober(relativeIndex);
                drunk[lastIndex] = true;
            }
            Console.WriteLine(GetNextSober(0) + 1);
        }
        private static int GetNextSober(int startIndex)
        {
            int relativeIndex = startIndex;
            if (relativeIndex == drunk.Length)
            {
                relativeIndex = 0;
            }
            while (drunk[relativeIndex] == true)
            {
                relativeIndex++;
                if (relativeIndex == drunk.Length)
                {
                    relativeIndex = 0;
                }
            }
            return relativeIndex;
        }
    }
}
