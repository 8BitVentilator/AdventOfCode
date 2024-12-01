using AdventOfCode.Year2024.Day01;

namespace AdventOfCode.Test.Year2024.Day01;

[Trait("Year", "2024")]
public class PuzzleTest : PuzzleTestBase
{
    [Fact]
    public void PartOne() => this.Test(new Puzzle().PartOne, @"Year2024\Day01\example_PartOne.txt", 11);

    [Fact]
    public void PartTwo() => this.Test(new Puzzle().PartTwo, @"Year2024\Day01\example_PartTwo.txt", 31);
}
