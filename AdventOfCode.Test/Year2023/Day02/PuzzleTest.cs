using AdventOfCode.Year2023.Day02;

namespace AdventOfCode.Test.Day02;

public class PuzzleTest : PuzzleTestBase
{
    [Fact]
    public void PartOne() => this.Test(new Puzzle().PartOne, @"Year2023\Day02\example_PartOne.txt", 8);

    [Fact]
    public void PartTwo() => this.Test(new Puzzle().PartTwo, @"Year2023\Day02\example_PartTwo.txt", 2286);
}
