using System;
using System.Linq;

namespace AdventOfCode.Day01
{
    public class Solution
    {
        public int GetResult1(string input)
            => SolveCaptcha(input, 1);

        public int GetResult2(string input)
            => SolveCaptcha(input, input.Length / 2);

        int SolveCaptcha(string input, int distance)
            => Enumerable.Range(0, input.Length)
                         .Select(index => GetPair(input, index, distance))
                         .Where(pair => pair.first == pair.second)
                         .Sum(pair => pair.first);

        (int first, int second) GetPair(string i, int index, int distance)
            => (Convert.ToInt32(i[index] - '0'),
                Convert.ToInt32(i[(index + distance) % i.Length] - '0'));
    }
}
