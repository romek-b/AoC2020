using Xunit;

namespace TobogganTrajectory.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(3,1,7)]
        [InlineData(5,1,3)]
        [InlineData(7,1,4)]
        [InlineData(1,2,2)]
        public void CountTrees_Works(int rightSlope, int downSlope, int expected)
        {
            // arrange

            // act
            var result = Program.CountTrees(_input, (rightSlope, downSlope));

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiplyBySlope_Works()
        {
            // arrange
            var slopes = new[]
            {
                (1,1),
                (3,1),
                (5,1),
                (7,1),
                (1,2)
            };

            // act
            var result = Program.MultiplyBySlope(_input, slopes);

            // assert
            Assert.Equal(336, result);
        }

        private readonly string[] _input;
        public ProgramTests()
        {
            _input = new[]
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            };
        }
    }
}
