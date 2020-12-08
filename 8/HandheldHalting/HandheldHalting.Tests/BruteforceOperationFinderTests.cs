using System.Collections.Generic;
using Xunit;

namespace HandheldHalting.Tests
{
    public class BruteforceOperationFinderTests
    {
        [Fact]
        public void Find_Works()
        {
            // arrange

            // act
            var result = _bfof.Find();

            // assert
            Assert.Equal(8, result);
        }

        private readonly BruteforceOperationFinder _bfof;

        public BruteforceOperationFinderTests()
        {
            var input = new List<string>()
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };

            _bfof = new BruteforceOperationFinder(input);
        }
    }
}
