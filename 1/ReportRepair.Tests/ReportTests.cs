using Xunit;

namespace ReportRepair.Tests
{
    public class ReportTests
    {
        [Theory]
        [InlineData(2, 514579)]
        [InlineData(3, 241861950)]
        public void FindResult_Returns_Result(int dim, int expected)
        {
            // arrange
            var input = new[] { 1721, 979, 366, 299, 675, 1456 };

            // act
            var result = Report.FindResult(dim, 2020, input);

            // assert
            Assert.Equal(expected, result);
        }
    }
}
