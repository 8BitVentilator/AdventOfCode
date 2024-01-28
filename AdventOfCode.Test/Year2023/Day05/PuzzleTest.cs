using AdventOfCode.Year2023.Day05;

namespace AdventOfCode.Test.Day05;

public class PuzzleTest : PuzzleTestBase
{
    [Fact]
    public void PartOne() => this.Test(new Puzzle().PartOne, @"Year2023\Day05\example_PartOne.txt", 35l);

    [Fact(Skip = "")]
    public void PartTwo() => this.Test(new Puzzle().PartTwo, @"Year2023\Day05\example_PartTwo.txt", "");
}
