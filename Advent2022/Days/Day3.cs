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
}
