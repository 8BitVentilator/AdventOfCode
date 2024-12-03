using AdventOfCode.Year2024.Day03;

namespace AdventOfCode.Test.Year2024.Day03;

[Trait("Year", "2024")]
public class PuzzleTest() : PuzzleTestBase(new Puzzle())
{
    protected override object Result_Example_PartOne => 161;
    protected override object Result_Example_PartTwo => 48;
    protected override object Result_PartOne => 191183308;
    protected override object Result_PartTwo => 92082041;
}
