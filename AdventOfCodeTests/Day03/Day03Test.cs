using AdventOfCode.Day03;
using Xunit;

namespace AdventOfCodeTests.Day03
{
    public class Day03Test
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        public void TestFirstPart(int input, int expectedOutput)
        {
            var sut = new Solution();
            Assert.Equal(expectedOutput, sut.GetResult1(input));
        }

        [Fact]
        public void TestSecondPart()
        {
            string input =
                @"5 9 2 8
                9 4 7 3
                3 8 6 5";

            var sut = new Solution();

            Assert.Equal(9, sut.GetResult2(input));
        }
    }
}
