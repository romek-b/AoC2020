using System.Collections.Generic;
using Xunit;

namespace PasswordPhilosophy.Tests
{
    public class CounterTests
    {
        [Fact]
        public void CountUsedToBeValidPasswords_Works()
        {
            // arrange

            // act
            var result = Counter.CountUsedToBeValidPasswords(_input);

            // assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void CountCurrentlyValidPasswords_Works()
        {
            // arrange

            // act
            var result = Counter.CountCurrentlyValidPasswords(_input);

            // assert
            Assert.Equal(1, result);
        }

        private readonly IEnumerable<string> _input;

        public CounterTests()
        {
            _input = new[]
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };
        }
    }
}
