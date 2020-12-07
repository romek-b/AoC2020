using Xunit;

namespace HandyHaversacks.Tests
{
    public class BagProcessorTests
    {
        [Fact]
        public void CountColors_Works()
        {
            // arrange

            // act
            var result = _bagProcessor.CountColors("shiny gold");

            // assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void CountBags_Works()
        {
            // arrange

            // act
            var result = _bagProcessor.CountBags("shiny gold");

            // assert
            Assert.Equal(32, result);
        }

        private readonly BagProcessor _bagProcessor;

        public BagProcessorTests()
        {
            var input = new[] {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            };

            _bagProcessor = new BagProcessor(input);
        }
    }
}
