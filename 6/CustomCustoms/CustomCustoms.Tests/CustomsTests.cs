using System.Collections.Generic;
using Xunit;

namespace CustomCustoms.Tests
{
    public class CustomTests
    {
        [Fact]
        public void SumAny_Works()
        {
            // arrange
 
            // act
            var result = Customs.SumAny(_customs);

            // assert
            Assert.Equal(11, result);
        }

        [Fact]
        public void SumAll_Works()
        {
            // arrange

            // act
            var result = Customs.SumAll(_customs);

            // assert
            Assert.Equal(6, result);
        }


        [Fact]
        public void CountAnyAnswers_Works()
        {
            // arrange
            var custom = "abcx\nabcy\nabcz";

            // act
            var result = Customs.CountAnyAnswers(custom);

            // assert
            Assert.Equal(6, result);
        }

        private IEnumerable<string> _customs;

        public CustomTests()
        {
            _customs = new[]
            {
                "abc",
                "a\nb\nc",
                "ab\nac" ,
                "a\na\na\na\na",
                "b"
            };
        }
    }
}
