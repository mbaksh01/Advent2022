using Advent2022.Extensions;

namespace Advent2022.Days;

internal class Day4
{
    internal static bool CompareRanges(Range elf1, Range elf2)
    {
        if (elf1.Start.Value <= elf2.Start.Value && elf1.End.Value >= elf2.End.Value)
        {
            return true;
        }

        if (elf2.Start.Value <= elf1.Start.Value && elf2.End.Value >= elf1.End.Value)
        {
            return true;
        }

        return false;
    }

    internal static Range ParseRange(ReadOnlySpan<char> rangeAsString)
        => new(
            int.Parse(rangeAsString[..rangeAsString.IndexOf("-")]), 
            int.Parse(rangeAsString[(rangeAsString.IndexOf("-") + 1)..]));

    public static int GetContainedPairsCount()
    {
        string input = Helpers.GetInput(4);

        int count = 0;  
        
        foreach (ReadOnlySpan<char> item in input.SplitLines())
        {
            count += CompareRanges(ParseRange(item[..item.IndexOf(",")]), ParseRange(item[(item.IndexOf(",") + 1)..]))
                ? 1 : 0;
        }

        return count;
    }

    internal static bool IsOverlapping(Range elf1, Range elf2)
    {
        if (elf1.End.Value < elf2.Start.Value)
        {
            return false;
        }

        if (elf2.End.Value < elf1.Start.Value)
        {
            return false;
        }

        return true;
    }

    public static int GetOverlappingPairsCount()
    {
        string input = Helpers.GetInput(4);

        int count = 0;

        foreach (ReadOnlySpan<char> item in input.SplitLines())
        {
            count += IsOverlapping(ParseRange(item[..item.IndexOf(",")]), ParseRange(item[(item.IndexOf(",") + 1)..]))
                ? 1 : 0;
        }

        return count;
    }
}
