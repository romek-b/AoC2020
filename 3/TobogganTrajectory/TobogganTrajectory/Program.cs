using System;
using System.Collections.Generic;
using System.IO;

namespace TobogganTrajectory
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            Console.WriteLine(CountTrees(input, (3,1)));
            var slopes = new[]
            {
                (1,1),
                (3,1),
                (5,1),
                (7,1),
                (1,2)
            };
            Console.WriteLine(MultiplyBySlope(input, slopes));
        }

        public static long MultiplyBySlope(string[] input, IEnumerable<(int right, int down)> slopes)
        {
            var result = (long)1;
            foreach(var slope in slopes)
            {
                result *= CountTrees(input, slope);
            }
            return result;
        }

        public static int CountTrees(string[] input, (int right, int down) slope)
        {
            return CountTrees(ConvertToMap(input), slope);
        }

        private static int CountTrees(byte[][] map, (int right, int down) slope)
        {
            var result = 0;
            var v = 0;
            var h = 0;
            var wide = map[0].Length;
            do
            {
                h = (h + slope.right) % wide;
                v += slope.down;
                result += map[v][h];
            }
            while (v + slope.down <= map.Length - 1);
            return result;
        }

        private static byte[][] ConvertToMap(string[] input)
        {
            var array = new List<byte[]>();
            foreach (var line in input)
            {
                var values = new List<byte>();
                foreach (var c in line)
                {
                    var value = c switch
                    {
                        '.' => (byte)0,
                        '#' => (byte)1,
                        _ => throw new ArgumentException("Wrong input!")
                    };

                    values.Add(value);
                }
                array.Add(values.ToArray());
            }
            return array.ToArray();
        }
    }
}
