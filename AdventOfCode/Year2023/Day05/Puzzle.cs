using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023.Day05;

public partial class Puzzle : IPuzzle
{
    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();

    record Seeds(ulong Start, ulong Length) : IEnumerable<ulong>
    {
        
        public IEnumerator<ulong> GetEnumerator()
        {
            for(var i = Start; i < Start + Length; i++)
                yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

    record Mapping(ulong Destination, ulong Source, ulong Length)
    {
        public ulong? Map(ulong value)
            => value >= this.Source && value <= Source + Length - 1
                ? Destination + (value - Source)
                : null;
    }

    record MappingCollection(IReadOnlyCollection<Mapping> Mappings)
    {
        public ulong Map(ulong value)
            => Mappings.Select(mapping => mapping.Map(value))
                       .FirstOrDefault(x => x is not null) ?? value;
    }
    
    record Almanac(IEnumerable<Seeds> Seeds,
                   MappingCollection SeedToSoil,
                   MappingCollection SoilToFertilizer,
                   MappingCollection FertilizerToWater,
                   MappingCollection WaterToLight,
                   MappingCollection LightToTemperature,
                   MappingCollection TemperatureToHumidity,
                   MappingCollection HumidityToLocation);

    public object PartOne(string[] input)
    {
        var almanac = Parse(input, ParseSeedsPartOne);
        return almanac.Seeds
                .AsParallel()
                .Select(seeds => LowestLocation(seeds, almanac))
                .Min();
    }

    private ulong LowestLocation(Seeds seeds, Almanac almanac)
        => seeds
            .Select(almanac.SeedToSoil.Map)
            .Select(almanac.SoilToFertilizer.Map)
            .Select(almanac.FertilizerToWater.Map)
            .Select(almanac.WaterToLight.Map)
            .Select(almanac.LightToTemperature.Map)
            .Select(almanac.TemperatureToHumidity.Map)
            .Select(almanac.HumidityToLocation.Map)
            .Min();

    public object PartTwo(string[] input)
    {
        var almanac = Parse(input, ParseSeedsPartTwo);
        return almanac.Seeds
                .AsParallel()
                .Select(seeds => LowestLocation(seeds, almanac))
                .Min();
    }

    private IEnumerable<Seeds> ParseSeedsPartOne(IEnumerable<ulong> seeds)
        => seeds.Select(x => new Seeds(x, 1));

    private IEnumerable<Seeds> ParseSeedsPartTwo(IEnumerable<ulong> values)
        => values.Chunk(2).Select(x => new Seeds(x[0], x[1]));

    private Almanac Parse(string[] input, Func<IEnumerable<ulong>, IEnumerable<Seeds>> parseSeeds)
    {
        IEnumerable<string> Section(string name)
            => input.SkipWhile(line => !line.StartsWith(name))
                    .TakeWhile(line => !string.IsNullOrEmpty(line));

        IEnumerable<ulong> SeedValues()
            => NumberRegex().Matches(Section("seeds").Single())
                .Select(match => ulong.Parse(match.Value));

        IReadOnlyCollection<Mapping> ParseMapping(string name)
            => Section(name).Skip(1)
                .Select(line => NumberRegex().Matches(line))
                .Select(matches => new Mapping(
                    Destination: ulong.Parse(matches[0].Value),
                    Source: ulong.Parse(matches[1].Value),
                    Length: ulong.Parse(matches[2].Value)))
                .ToList();

        return new(
            Seeds: parseSeeds(SeedValues()),
            SeedToSoil: new MappingCollection(ParseMapping("seed-to-soil map")),
            SoilToFertilizer: new MappingCollection(ParseMapping("soil-to-fertilizer map")),
            FertilizerToWater: new MappingCollection(ParseMapping("fertilizer-to-water map")),
            WaterToLight: new MappingCollection(ParseMapping("water-to-light map")),
            LightToTemperature: new MappingCollection(ParseMapping("light-to-temperature map")),
            TemperatureToHumidity: new MappingCollection(ParseMapping("temperature-to-humidity map")),
            HumidityToLocation: new MappingCollection(ParseMapping("humidity-to-location map"))
       );
    }
}
