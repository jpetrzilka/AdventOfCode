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
            var solution = new Solution();
            Assert.Equal(output, solution.GetResult(input));
        }
    }
}
