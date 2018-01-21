using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day02
{
    public class Solution
    {
        public long GetResult1(string input)
        {
            return CalculateChecksum(input, MinMaxProcessing);
        }
        public long GetResult2(string input)
        {
            return CalculateChecksum(input, EvenDivision);
        }

        long CalculateChecksum(string input, Func<IEnumerable<long>, long> checksumCalculation)
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
                .Sum(checksumCalculation);
        }

        long MinMaxProcessing(IEnumerable<long> numbers)
            => numbers.Max() - numbers.Min();

        long EvenDivision(IEnumerable<long> numbers)
        {
            foreach (var number in numbers)
                foreach (var divisor in numbers)
                    if (number != divisor)
                        if (number % divisor == 0)
                            return number / divisor;

            throw new Exception("Could not calculate checksum");
        }
    }
}
