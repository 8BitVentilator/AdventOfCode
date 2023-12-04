namespace AdventOfCode.Test;

public class PuzzleTestBase
{
    public void Test(Func<string[], object> method, string inputFile, object expected)
    {
        var input = File.ReadAllLines(inputFile);
        var result = method(input);

        Assert.Equal(expected, result);
    }
}
