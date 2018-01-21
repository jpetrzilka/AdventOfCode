using AdventOfCode.Day02;
using Xunit;

namespace AdventOfCodeTests.Day02
{
    public class Day02Test
    {
        [Fact]
        public void TestFirstPart()
        {
            string input = 
                @"5 1 9 5
                7 5 3
                2 4 6 8";

            var sut = new Solution();

            Assert.Equal(18, sut.GetResult1(input));
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
