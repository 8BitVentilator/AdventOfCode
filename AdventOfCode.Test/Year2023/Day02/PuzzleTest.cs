using AdventOfCode.Year2023.Day02;

namespace AdventOfCode.Test.Year2023.Day02;

[Trait("Year", "2023")]
public class PuzzleTest() : PuzzleTestBase(new Puzzle(), 2023, 2)
{
    protected override object? Result_Example_PartOne => 8;
    protected override object? Result_Example_PartTwo => 2286;
    protected override object? Result_PartOne => 2317;
    protected override object? Result_PartTwo => 74804;
}
