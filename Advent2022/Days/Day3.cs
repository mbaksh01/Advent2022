using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent2022.Days;

/// <summary>
/// Day 3 challenges.
/// </summary>
internal class Day3
{
    /// <summary>
    /// Takes the contents of an elves <paramref name="rucksack"/>,
    /// splits it into 2 compartments and compares each value from the
    /// second compartment to the first compartment.
    /// </summary>
    /// <param name="rucksack">Rucksack to search.</param>
    /// <returns>The item which is common in both parts.</returns>
    /// <exception cref="UnreachableException">
    /// If a match is not found then this exception is thrown,
    /// however for day 3's input it does not contain anything which would 
    /// cause this error to be thrown.
    /// </exception>
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

        throw new UnreachableException("The input was invalid.");
    }

    /// <summary>
    /// Takes a <paramref name="rucksack"/> as an input,
    /// finds the repeated item and then converts that to a priority.
    /// </summary>
    /// <param name="rucksack"></param>
    /// <returns>
    /// The priority of the duplicate item in the <paramref name="rucksack"/>.
    /// </returns>
    internal static int GetPriority(ReadOnlySpan<char> rucksack)
    {
        char duplicateItem = GetRepeatedItem(rucksack);

        if (Regex.IsMatch(duplicateItem.ToString(), "[a-z]"))
        {
            return duplicateItem - 96;
        }

        return duplicateItem - 38;
    }

    /// <summary>
    /// Part 1 challenge is to loop though all the rucksacks
    /// of the elves and find the duplicate item. Then convert
    /// that item to a priority and sum all the priorities.
    /// </summary>
    /// <returns>The sum of all the priorities.</returns>
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

    /// <summary>
    /// Takes the input of a group of elves and find the a item
    /// shared between all 3 rucksacks.
    /// </summary>
    /// <param name="elf1Rucksack"></param>
    /// <param name="elf2Rucksack"></param>
    /// <param name="elf3Rucksack"></param>
    /// <returns>The common item between all 3 rucksacks.</returns>
    /// <exception cref="UnreachableException">
    /// If a match is not found then this exception is thrown,
    /// however for day 3's input it does not contain anything which would 
    /// cause this error to be thrown.
    /// </exception>
    internal static char GetGroupBadge(ReadOnlySpan<char> elf1Rucksack, ReadOnlySpan<char> elf2Rucksack, ReadOnlySpan<char> elf3Rucksack)
    {
        foreach (char item in elf1Rucksack)
        {
            if (elf2Rucksack.Contains(item) && elf3Rucksack.Contains(item))
            {
                return item;
            }
        }

        throw new UnreachableException("The inputs were invalid.");
    }

    /// <summary>
    /// Takes a rucksack <paramref name="item"/> and converts
    /// it to a priority.
    /// </summary>
    /// <param name="item">Item to convert.</param>
    /// <returns>The priority of the <paramref name="item"/>.</returns>
    internal static int GetPriority(char item)
    {
        if (Regex.IsMatch(item.ToString(), "[a-z]"))
        {
            return item - 96;
        }

        return item - 38;
    }

    /// <summary>
    /// Part 2 challenge is to loop through elves in groups of 3,
    /// find a item contained within all three of the rucksacks,
    /// convert that item to a priority and total the priority of
    /// all the groups.
    /// </summary>
    /// <returns>The total priority for all the groups.</returns>
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
