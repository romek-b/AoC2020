namespace CustomCustoms
{
    public static class Program
    {
        public static void Main()
        {
            var input = System.IO.File.ReadAllText("input.txt");
            var customs = input.Split("\n\n");
            var sumAny = Customs.SumAny(customs);
            var sumAll = Customs.SumAll(customs);
            System.Console.WriteLine(sumAny);
            System.Console.WriteLine(sumAll);
        }
    }
}