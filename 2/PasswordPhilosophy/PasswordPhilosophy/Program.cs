using System;
using System.IO;

namespace PasswordPhilosophy
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var oldCount = Counter.CountUsedToBeValidPasswords(lines);
            Console.WriteLine(oldCount);
            var count = Counter.CountCurrentlyValidPasswords(lines);
            Console.WriteLine(count);
        }
    }
}
