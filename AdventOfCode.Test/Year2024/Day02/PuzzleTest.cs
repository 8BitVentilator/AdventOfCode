using AdventOfCode.Year2024.Day02;

namespace AdventOfCode.Test.Year2024.Day02;

[Trait("Year", "2024")]
public class PuzzleTest() : PuzzleTestBase(new Puzzle())
{
    protected override object? Result_Example_PartOne => 2;
    protected override object? Result_Example_PartTwo => 4;
    protected override object? Result_PartOne => 598;
    protected override object? Result_PartTwo => 634;
}
