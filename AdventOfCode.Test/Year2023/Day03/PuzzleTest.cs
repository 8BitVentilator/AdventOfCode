using AdventOfCode.Year2023.Day03;

namespace AdventOfCode.Test.Year2023.Day03;

[Trait("Year", "2023")]
public class PuzzleTest() : PuzzleTestBase(new Puzzle())
{
    protected override object? Result_Example_PartOne => 4361;
    protected override object? Result_Example_PartTwo => 467835;
    protected override object? Result_PartOne => 553079;
    protected override object? Result_PartTwo => 84363105;
}
