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

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        public void TestSecondPart(int input, int expectedOutput)
        {
            var sut = new Solution();
            Assert.Equal(9, sut.GetResult2(input));
        }
    }
}
