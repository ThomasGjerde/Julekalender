using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Julekalender.knowit
{
    class Luke7
    {
        public static void Run()
        {
            Dictionary<int, int> dictionary = GetPixels(@"input/Santa.png");
            List<KeyValuePair<int, int>> list = dictionary.ToList();
            list.Sort(
                delegate(KeyValuePair<int, int> o1, KeyValuePair<int, int> o2)
                {
                    return o2.Value.CompareTo(o1.Value);
                }
            );
            Console.WriteLine(list[9].Value);
        }
        private static Dictionary<int, int> GetPixels(string imgPath)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            Bitmap img = new Bitmap(imgPath);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    int key = img.GetPixel(i, j).ToArgb();
                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary[key] = 1;
                    }
                    else
                    {
                        dictionary[key] += 1;
                    }

                }
            }
            return dictionary;
        }
    }
}
