namespace HandheldHalting
{
    public static class Program
    {
        public static void Main()
        {
            var listing = System.IO.File.ReadAllLines("input.txt");
            var processor = new Processor(listing);
            processor.Execute();
            System.Console.WriteLine(processor.Acc);
            var bruteForceFinder = new BruteforceOperationFinder(listing);
            System.Console.WriteLine(bruteForceFinder.Find());
        }
    }
}
