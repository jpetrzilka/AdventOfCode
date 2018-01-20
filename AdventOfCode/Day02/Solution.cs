using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day02
{
    public class Solution
    {
        public long GetResult1(string input)
        {
            return input
                .Trim()
                .Split(
                    new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line
                    .Trim()
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(number => long.Parse(number)))
                .Sum(numbers => numbers.Max() - numbers.Min());
        }
    }
}
