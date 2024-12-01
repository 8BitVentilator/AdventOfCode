using AdventOfCode.Year2023.Day03;

namespace AdventOfCode.Test.Year2023.Day03;

[Trait("Year", "2023")]
public class PuzzleTest : PuzzleTestBase
{
    [Fact]
    public void PartOne() => this.Test(new Puzzle().PartOne, @"Year2023\Day03\example_PartOne.txt", 4361);

    [Fact]
    public void PartTwo() => this.Test(new Puzzle().PartTwo, @"Year2023\Day03\example_PartTwo.txt", 467835);
}
