using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReportRepair
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = ReadInput().ToArray();
            Console.WriteLine(Report.FindResult(2, 2020, input));
            Console.WriteLine(Report.FindResult(3, 2020, input));
        }

        public static IEnumerable<int> ReadInput()
        {
            var result = new List<int>();
            var line = default(string);
            using (var sr = new StreamReader("input.txt"))
            {
                while((line = sr.ReadLine()) != null)
                {
                    if(int.TryParse(line, out var number))
                    {
                        result.Add(number);
                    }
                }
            }
            return result;
        }
    }
}
