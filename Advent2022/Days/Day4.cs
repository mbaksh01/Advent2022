using Advent2022.Extensions;

namespace Advent2022.Days;

/// <summary>
/// Day 4 challenges.
/// </summary>
internal class Day4
{
    /// <summary>
    /// Checks whether the <paramref name="elf2"/>'s range is
    /// contained with in <paramref name="elf1"/>'s range.
    /// </summary>
    /// <param name="elf1"></param>
    /// <param name="elf2"></param>
    /// <returns>
    /// <see langword="true"/> if the range of <paramref name="elf2"/>
    /// is contained by <paramref name="elf1"/>; otherwise <see langword="false"/>.
    /// </returns>
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

    /// <summary>
    /// Converts a string range to a <see cref="Range"/>.
    /// </summary>
    /// <param name="rangeAsString">
    /// Format of string is "12-64", where 12 is that start
    /// index and 64 is the end index.
    /// </param>
    /// <returns><paramref name="rangeAsString"/> as a <see cref="Range"/>.</returns>
    internal static Range ParseRange(ReadOnlySpan<char> rangeAsString)
        => new(
            int.Parse(rangeAsString[..rangeAsString.IndexOf("-")]), 
            int.Parse(rangeAsString[(rangeAsString.IndexOf("-") + 1)..]));

    /// <summary>
    /// Takes the input of day 4 and checks if a
    /// elves range is contained by another elves range.
    /// </summary>
    /// <returns>The number of pairs which have containing ranges.</returns>
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

    /// <summary>
    /// Checks whether the ranges overlap.
    /// </summary>
    /// <param name="elf1"></param>
    /// <param name="elf2"></param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="elf1"/>'s range overlaps
    /// with <paramref name="elf2"/>'s range; otherwise <see langword="false"/>.
    /// </returns>
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

    /// <summary>
    /// Takes day 4's input and checks whether 
    /// any ranges are overlapping.
    /// </summary>
    /// <returns>The number of overlapping pairs.</returns>
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
