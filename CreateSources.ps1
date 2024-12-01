param (
    [Parameter(Mandatory=$true)]
    [int]$Year,
	[Parameter(Mandatory=$true)]
    [int]$Day
)


$DayStr = $Day.ToString('00')
$SourceFolder = "AdventOfCode\Year$Year\Day$DayStr"
$InputFile = "$SourceFolder\input.txt"
$SourceFile = "$SourceFolder\Puzzle.cs"

New-Item -Name $SourceFolder -ItemType Directory
New-Item -Name $InputFile -ItemType File
New-Item -Path $SourceFile -ItemType File
Add-Content $SourceFile ("namespace AdventOfCode.Year$Year.Day$DayStr;")
Add-Content $SourceFile ("")
Add-Content $SourceFile ("public class Puzzle : IPuzzle")
Add-Content $SourceFile ("{")
Add-Content $SourceFile ("    public object PartOne(string[] input)")
Add-Content $SourceFile ("    {")
Add-Content $SourceFile ("        throw new NotImplementedException();")
Add-Content $SourceFile ("    }")
Add-Content $SourceFile ("")
Add-Content $SourceFile ("    public object PartTwo(string[] input)")
Add-Content $SourceFile ("    {")
Add-Content $SourceFile ("        throw new NotImplementedException();")
Add-Content $SourceFile ("    }")
Add-Content $SourceFile ("}")

$TestFolder = "AdventOfCode.Test\Year$Year\Day$DayStr"
$ExamplePartOneFile = "$TestFolder\example_PartOne.txt"
$ExamplePartTwoFile = "$TestFolder\example_PartTwo.txt"
$TestFile = "$TestFolder\PuzzleTest.cs"

New-Item -Name $TestFolder -ItemType Directory
New-Item -Name $ExamplePartOneFile -ItemType File
New-Item -Name $ExamplePartTwoFile -ItemType File
New-Item -Name $TestFile -ItemType File
Add-Content $TestFile ("using AdventOfCode.Year$Year.Day$DayStr;")
Add-Content $TestFile ("")
Add-Content $TestFile ("namespace AdventOfCode.Test.Year$Year.Day$DayStr;")
Add-Content $TestFile ("")
Add-Content $TestFile ("[Trait(`"Year`", `"$Year`")]");
Add-Content $TestFile ("public class PuzzleTest : PuzzleTestBase")
Add-Content $TestFile ("{")
Add-Content $TestFile ("    [Fact]")
Add-Content $TestFile ("    public void PartOne() => this.Test(new Puzzle().PartOne, @`"Year$Year\Day$DayStr\example_PartOne.txt`", `"`");")
Add-Content $TestFile ("")
Add-Content $TestFile ("    [Fact]")
Add-Content $TestFile ("    public void PartTwo() => this.Test(new Puzzle().PartTwo, @`"Year$Year\Day$DayStr\example_PartTwo.txt`", `"`");")
Add-Content $TestFile ("}")
