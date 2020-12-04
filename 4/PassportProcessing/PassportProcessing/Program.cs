using System;

namespace PassportProcessing
{
    public static class Program
    {
        public static void Main()
        {
            var data = System.IO.File.ReadAllText("input.txt");
            Console.WriteLine(Processing.CheckValidPassportsFromData(data));
            Console.WriteLine(Processing.CheckStrictlyValidPassportsFromData(data));
        }
    }
}
