<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	var input = @"";
	SonarPart1(input);
	SonarPart2(input);
}

int SonarPart1(string input)
	=> Sonar(input, x => x);

int SonarPart2(string input)
{
	return Sonar(input, x => x
		.Select((item, index) => 
			item
			+ (index > 0 ? x.ElementAt(index - 1) : 0)
			+ (index > 1 ? x.ElementAt(index - 2) : 0))
		.Skip(2));
}
	
int Sonar(string input, Func<IEnumerable<int>, IEnumerable<int>> dataAggregation)
{
	var depthData = input
		.Split(new[] { Environment.NewLine }, StringSplitOptions.TrimEntries)
		.Select(x => int.Parse(x));
	var aggregatedData = dataAggregation(depthData);
	var results = aggregatedData
		.Select((item, index) => index > 0 && item - aggregatedData.ElementAt(index - 1) > 0);

	return results.Count(r => r);
}

#region private::Tests

string testInput = @"199
200
208
210
200
207
240
269
260
263";

[Fact]
void ShouldSonarPart1()
{
	Assert.Equal(7, SonarPart1(testInput));
}

[Fact]
void ShouldSonarPart2()
{
	Assert.Equal(5, SonarPart2(testInput));
}

#endregion