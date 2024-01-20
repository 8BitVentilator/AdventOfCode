using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023.Day04;

public partial class Puzzle : IPuzzle
{
    private record Card(int Id, IEnumerable<int> Numbers, IEnumerable<int> WinningNumbers);

    [GeneratedRegex(@"Card\s+(\d+): ([\s\d]+) \| ([\s\d]+)")]
    private static partial Regex CardRegex();

    public object PartOne(string[] input) 
        => Cards(input)
            .Sum(Points);

    public object PartTwo(string[] input)
    {
        return "";
    }

    private IEnumerable<Card> Cards(string[] input)
    {
        static Card Card(Match match)
            => new(
                    Id: int.Parse(match.Groups[1].Value),
                    Numbers: match.Groups[2].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse),
                    WinningNumbers: match.Groups[3].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                );

        return input.Select(line => Card(CardRegex().Match(line)));
    }

    private int Points(Card card)
    {
        var count = card.Numbers.Intersect(card.WinningNumbers).Count();

        return count == 0 
            ? 0 
            : 1 << count - 1;
    }
}
