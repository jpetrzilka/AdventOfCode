using AdventOfCode.Day02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
