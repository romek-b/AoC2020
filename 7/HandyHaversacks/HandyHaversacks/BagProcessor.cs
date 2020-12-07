using System.Collections.Generic;
using System.Linq;

namespace HandyHaversacks
{
    public class BagProcessor
    {
        private readonly IDictionary<string, int> _bagColorDictionary;
        private readonly IList<(int OuterBag, int InnerBag, int InnerBagCount)> _bagAssignments;

        public BagProcessor(IList<string> input)
        {
            _bagColorDictionary = new Dictionary<string, int>();
            _bagAssignments = new List<(int, int, int)>();

            for (var i = 0; i < input.Count; i++)
            {
                var bagColor = input[i].Split(" bags contain ")[0];
                _bagColorDictionary.Add(bagColor, i);
            }

            foreach (var bag in input)
            {
                var bagColorKey = _bagColorDictionary[bag.Split(" bags contain ")[0]];
                var bagContent = bag.Split(" bags contain ")[1]
                    .Replace(" bags", "")
                    .Replace(" bag", "")
                    .Replace(".", "")
                    .Split(", ");

                if (bagContent[0] != "no other")
                {
                    foreach (var item in bagContent)
                    {
                        var inner = item.Split(" ", 2);
                        _bagAssignments.Add((bagColorKey, _bagColorDictionary[inner[1]], int.Parse(inner[0])));
                    }
                }
            }
        }

        public int CountColors(string rootBagColor)
        {
            var count = 0;
            var bagIds = new List<int> { _bagColorDictionary[rootBagColor] };
            var usedBagIds = bagIds;
            while (bagIds.Count > 0)
            {
                bagIds = _bagAssignments.Where(a => bagIds.Contains(a.InnerBag))
                    .Select(a => a.OuterBag)
                    .Distinct()
                    .Where(i => !usedBagIds.Contains(i))
                    .ToList();
                usedBagIds.AddRange(bagIds);
                count += bagIds.Count;
            }

            return count;
        }

        public int CountBags(string rootBagColor)
        {
            var count = 0;
            var bagIds = new List<(int Id, int Multiplier)> { (_bagColorDictionary[rootBagColor], 1) };
            var innerCount = 0;
            do
            {
                bagIds = bagIds.SelectMany(b => _bagAssignments
                        .Where(a => a.OuterBag == b.Id)
                        .Select(a => (a.InnerBag, a.InnerBagCount, b.Multiplier)))
                    .Select(x => (x.InnerBag, x.InnerBagCount * x.Multiplier))
                    .ToList();
                innerCount = bagIds.Sum(x => x.Multiplier);
                count += innerCount;
            }
            while (innerCount > 0);

            return count;
        }
    }
}
