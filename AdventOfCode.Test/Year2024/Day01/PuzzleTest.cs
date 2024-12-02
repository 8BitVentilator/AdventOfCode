using AdventOfCode.Year2024.Day01;

namespace AdventOfCode.Test.Year2024.Day01;

[Trait("Year", "2024")]
public class PuzzleTest() : PuzzleTestBase(new Puzzle(), 2024, 1)
{
    protected override object? Result_Example_PartOne => 11;
    protected override object? Result_Example_PartTwo => 31;
    protected override object? Result_PartOne => 1765812;
    protected override object? Result_PartTwo => 20520794;
}
