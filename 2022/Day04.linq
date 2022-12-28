<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

int Part1(string input)
	=> Solution(input, (a, b) =>
	{
		var intersect = a.Intersect(b);
		return !a.Except(intersect).Any() || !b.Except(intersect).Any();
	});

int Part2(string input)
	=> Solution(input, (a, b) => a.Intersect(b).Any());

int Solution(string input, Func<IEnumerable<int>, IEnumerable<int>, bool> intersectEvaluator)
{
	return input
		.Split(Environment.NewLine)
		.Select(line => line
			.Split(',')
			.Select(x => x.Split('-'))
			.Select(x => int.Parse(x.First())..int.Parse(x.Last()))
			.Select(x => Enumerable.Range(x.Start.Value, x.End.Value - x.Start.Value + 1)))
		.Where(x =>
		{
			return intersectEvaluator(x.First(), x.Last());
			
		})
		.Count();
}

[Fact]
void Part1Test()
{
	var input = """
	2-4,6-8
	2-3,4-5
	5-7,7-9
	2-8,3-7
	6-6,4-6
	2-6,4-8
	""";

	Assert.Equal(2, Part1(input));
}

[Fact]
void Part2Test()
{
	var input = """
	2-4,6-8
	2-3,4-5
	5-7,7-9
	2-8,3-7
	6-6,4-6
	2-6,4-8
	""";

	Assert.Equal(4, Part2(input));
}
