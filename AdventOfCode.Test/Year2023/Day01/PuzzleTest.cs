using AdventOfCode.Year2023.Day01;

namespace AdventOfCode.Test.Year2023.Day01;

[Trait("Year", "2023")]
public class PuzzleTest : PuzzleTestBase
{
    [Fact]
    public void PartOne() => this.Test(new Puzzle().PartOne, @"Year2023\Day01\example_PartOne.txt", 142);

    [Fact]
    public void PartTwo() => this.Test(new Puzzle().PartTwo, @"Year2023\Day01\example_PartTwo.txt", 281);
}
