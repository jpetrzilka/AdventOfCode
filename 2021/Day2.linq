<Query Kind="Program">
  <Connection>
    <ID>a6d08f80-dcd1-4f44-8131-18e6641f60fd</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>localhost\SQLEXPRESS</Server>
    <Database>mews-local-db</Database>
  </Connection>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
//	var input = @"";
//
//	var pos = GetFinalPosition2(input);
//	(pos.Horizontal * pos.Vertical).Dump();
}

StateVector GetFinalPosition1(string input)
{
	var instructions = GetInstructions(input);
	var vectors = instructions.Select(x =>
	   x.Direction switch
	   {
		   "up" => new StateVector(0, -x.Increment),
		   "down" => new StateVector(0, x.Increment),
		   "forward" => new StateVector(x.Increment, 0),
		   _ => new StateVector(0, 0)
	   });

	return vectors.Aggregate((x, y) => new StateVector(
		Horizontal: x.Horizontal + y.Horizontal,
		Vertical: x.Vertical + y.Vertical));
}

StateVector GetFinalPosition2(string input)
{
	var instructions = GetInstructions(input);
	int aim = 0;
	var position = new StateVector(0, 0);
	
	foreach (var x in instructions)
	{
		switch (x.Direction)
		{
			case "up":
				aim -= x.Increment;
				break;
			case "down":
				aim += x.Increment;
				break;
			case "forward":
				position = new StateVector(
					Horizontal: position.Horizontal + x.Increment,
					Vertical: position.Vertical + (aim * x.Increment));
				break;
		}
	}

	return position;
}

IEnumerable<Instruction> GetInstructions(string input)
	=> input.Split(new[] { Environment.NewLine }, StringSplitOptions.TrimEntries)
		.Select(x => x.Split(' '))
		.Select(x => new Instruction(
			Direction: x.First(),
			Increment: int.Parse(x.Last())));

record Instruction(string Direction, int Increment);
record StateVector(int Horizontal, int Vertical);

#region private::Tests

string testInput = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";

[Fact]
void ShouldGetFinalPosition1()
{
	var position = GetFinalPosition1(testInput);
	Assert.Equal(150, position.Horizontal * position.Vertical);
}

[Fact]
void ShouldGetFinalPosition2()
{
	var position = GetFinalPosition2(testInput);
	Assert.Equal(900, position.Horizontal * position.Vertical);
}

#endregion