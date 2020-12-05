using System;
using System.IO;
using System.Linq;

namespace BinaryBoarding
{
    public static class Program
    {
        public static void Main()
        {
            var codes = File.ReadAllLines("input.txt");
            var boardingPasses = codes.Select(c => new BoardingPass(c));
            var maxSeatId = boardingPasses.Max(bp => bp.SeatId);
            var minSeatId = boardingPasses.Min(bp => bp.SeatId);
            Console.WriteLine(maxSeatId);

            var sumOfAllSeatIds =
                Enumerable.Range(minSeatId, maxSeatId - minSeatId + 1).Sum(x => x);
            var sumOfSeatdIdsFromBps = boardingPasses.Sum(x => x.SeatId);
            var missingSeatId = sumOfAllSeatIds - sumOfSeatdIdsFromBps;

            if(!boardingPasses.Any(x => x.SeatId == missingSeatId))
            {
                Console.WriteLine($"I'm right! The missing seat ID is {missingSeatId}");
            }
            else
            {
                throw new Exception("The answer is wrong!");
            }
        }
    }
}
