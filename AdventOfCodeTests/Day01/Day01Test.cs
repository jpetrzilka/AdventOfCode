using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System.Text;
using AdventOfCode.Day01;

namespace AdventOfCodeTests.Day01
{
    public class Day01Test
    {
        [Theory]
        [InlineData("1122",3)]
        [InlineData("1111",4)]
        [InlineData("1234",0)]
        [InlineData("91212129",9)]
        public void TestFirstPart(string input, int output)
        {
            Assert.Equal(output, new Solution().GetResult1(input));
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void TestSecondPart(string input, int output)
        {
            Assert.Equal(output, new Solution().GetResult2(input));
        }
    }
}
