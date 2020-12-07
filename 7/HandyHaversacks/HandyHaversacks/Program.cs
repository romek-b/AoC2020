namespace HandyHaversacks
{
    public static class Program
    {
        public static void Main()
        {
            var input = System.IO.File.ReadAllLines("input.txt");
            var processor = new BagProcessor(input);
            System.Console.WriteLine(processor.CountColors("shiny gold"));
            System.Console.WriteLine(processor.CountBags("shiny gold"));
        }
    }
}
