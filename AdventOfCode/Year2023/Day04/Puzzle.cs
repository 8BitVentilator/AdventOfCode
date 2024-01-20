using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023.Day04;

public partial class Puzzle : IPuzzle
{
    private record Card(int Id, int CountMatchingNumbers);

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();

    public object PartOne(string[] input) 
        => Cards(input).Sum(Points);

    public object PartTwo(string[] input)
        => Copies(Cards(input).ToArray());

    private int Copies(Card[] cards)
    {
        var proceessedCards = new List<Card>(cards);
        var index = 0;

        while (index < proceessedCards.Count)
        {
            var card = proceessedCards[index++];
            if (card.CountMatchingNumbers > 0)
                proceessedCards.AddRange(cards.Skip(card.Id).Take(card.CountMatchingNumbers));
        }

        return proceessedCards.Count;
    }

    private IEnumerable<Card> Cards(string[] input)
    {
        Card Card(MatchCollection matches)
            => new(int.Parse(matches.First().Value), CountMatchingNumbers(matches));

        int CountMatchingNumbers(MatchCollection numbers)
            => numbers.Skip(1)
                .GroupBy(number => number.Value)
                .Count(group => group.Count() > 1);

        return input.Select(card => Card(NumberRegex().Matches(card)));
    }

    private int Points(Card card)
        => card.CountMatchingNumbers == 0 
            ? 0 
            : 1 << card.CountMatchingNumbers - 1;
}
