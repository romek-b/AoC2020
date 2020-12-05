using Xunit;

namespace BinaryBoarding.Tests
{
    public class BoardingPassTests
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void Constructor_Works(string code, int expectedRow, int expectedColumn, int expectedSeatId)
        {
            // arrange

            // act
            var result = new BoardingPass(code);

            // assert
            Assert.Equal(expectedRow, result.Row);
            Assert.Equal(expectedColumn, result.Column);
            Assert.Equal(expectedSeatId, result.SeatId);
        }
    }
}
