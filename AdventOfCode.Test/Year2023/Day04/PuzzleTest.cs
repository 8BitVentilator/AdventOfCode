using AdventOfCode.Year2023.Day04;

namespace AdventOfCode.Test.Year2023.Day04;

[Trait("Year", "2023")]
public class PuzzleTest : PuzzleTestBase
{
    [Fact]
    public void PartOne() => this.Test(new Puzzle().PartOne, @"Year2023\Day04\example_PartOne.txt", 13);

    [Fact(Skip = "")]
    public void PartTwo() => this.Test(new Puzzle().PartTwo, @"Year2023\Day04\example_PartTwo.txt", 30);
}
