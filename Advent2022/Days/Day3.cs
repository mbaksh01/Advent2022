using System.Text.RegularExpressions;

namespace Advent2022.Days;

internal class Day3
{
    internal static char GetRepeatedItem(ReadOnlySpan<char> rucksack)
    {
        ReadOnlySpan<char> firstCompartment = rucksack[..(rucksack.Length / 2)];
        ReadOnlySpan<char> secondCompartment = rucksack[(rucksack.Length / 2)..];

        foreach (char item in secondCompartment)
        {
            if (firstCompartment.Contains(item))
            {
                return item;
            }
        }

        throw new ArgumentException("The input was invalid.", nameof(rucksack));
    }

    internal static int GetPriority(ReadOnlySpan<char> rucksack)
    {
        char duplicateItem = GetRepeatedItem(rucksack);

        if (Regex.IsMatch(duplicateItem.ToString(), "[a-z]"))
        {
            return duplicateItem - 96;
        }

        return duplicateItem - 38;
    }

    public static int GetPrioritySum()
    {
        string input = Helpers.GetInput(3);

        string[] rucksacks = input.Split("\n");

        int prioritySum = 0;

        foreach (string rucksack in rucksacks)
        {
            prioritySum += GetPriority(rucksack);
        }

        return prioritySum;
    }

    internal static char GetGroupBadge(ReadOnlySpan<char> elf1Rucksack, ReadOnlySpan<char> elf2Rucksack, ReadOnlySpan<char> elf3Rucksack)
    {
        foreach (char item in elf1Rucksack)
        {
            if (elf2Rucksack.Contains(item) && elf3Rucksack.Contains(item))
            {
                return item;
            }
        }

        throw new ArgumentException("The inputs were invalid.");
    }

    internal static int GetPriority(char item)
    {
        if (Regex.IsMatch(item.ToString(), "[a-z]"))
        {
            return item - 96;
        }

        return item - 38;
    }

    public static int GetGroupedPrioritySum()
    {
        string input = Helpers.GetInput(3);

        string[] rucksacks = input.Split("\n");

        int prioritySum = 0;

        for (int i = 0; i < rucksacks.Length - 2; i += 3)
        {
            char badge = GetGroupBadge(
                            rucksacks[i],
                            rucksacks[i + 1],
                            rucksacks[i + 2]);

            prioritySum += GetPriority(badge);
        }

        return prioritySum;
    }
}
