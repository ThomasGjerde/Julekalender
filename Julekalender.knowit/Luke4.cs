using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Julekalender.knowit
{
    class Luke4
    {
        public static void Run()
        {
            FileStream fs = new FileStream(@"input/kilma_data_blindern.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            for (int i = 0; i < 24; i++)
            {
                sr.ReadLine();
            }
            double lowestTemp = 100;
            DateTime date = new DateTime();
            while (sr.EndOfStream == false)
            {
                try
                {
                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex(@"[ ]{2,}", options);
                    string line = regex.Replace(sr.ReadLine(), @" ");
                    string[] array = line.Split(' ');
                    var nfi = new NumberFormatInfo();
                    nfi.NegativeSign = "-";
                    double temp = double.Parse(array[4].Replace(',', '.'), nfi);
                    if (temp < lowestTemp)
                    {
                        DateTime tempDate = DateTime.Parse(array[2]);
                        if (tempDate.Month == 12)
                        {
                            lowestTemp = temp;
                            date = tempDate;
                        }
                    }
                }
                catch
                {

                }
            }
            Console.WriteLine(date.ToShortDateString() + " " + lowestTemp);
        }
    }
}
