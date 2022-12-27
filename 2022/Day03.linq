<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>


void Main()
{
	string input = """
		vJrwpWtwJgWrhcsFMMfFFhFp
		jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
		PmmdzqPrVvPwwTWBwg
		wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
		ttgJtRGJQctTZtZT
		CrZsJsPPZsGzwwsLwLmpwMDw
		""";

	Part1(input);
	Part2(input);
}

void Part1(string input)
{
	input
		.Split(Environment.NewLine)
		.Select(x => x
			.Substring(0, x.Length / 2).ToCharArray()
			.Intersect(x.Substring(x.Length / 2).ToCharArray())
			.Single())
		.Select(x => x >= 'a'
			? (int)x - 96
			: (int)x - 64 + 26)
		.Sum()
		.Dump();
}

void Part2(string input)
{
	input
		.Split(Environment.NewLine)
		.Batch(3)
		.Select(x => x.ElementAt(0)
			.Intersect(x.ElementAt(1)
				.Intersect(x.ElementAt(2)))
			.Single())
		.Select(x => x >= 'a'
			? (int)x - 96
			: (int)x - 64 + 26)
		.Sum()
		.Dump();
}
