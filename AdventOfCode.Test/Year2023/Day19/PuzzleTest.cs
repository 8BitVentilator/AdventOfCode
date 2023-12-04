using AdventOfCode.Year2023.Day19;

namespace AdventOfCode.Test.Day19;

public class PuzzleTest : PuzzleTestBase
{
    [Fact(Skip = "")]
    public void PartOne() => this.Test(new Puzzle().PartOne, @"Year2023\Day19\example_PartOne.txt", "");

    [Fact(Skip = "")]
    public void PartTwo() => this.Test(new Puzzle().PartTwo, @"Year2023\Day19\example_PartTwo.txt", "");
}
