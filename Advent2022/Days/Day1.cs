namespace Advent2022.Days;

/// <summary>
/// Day 1 challenges.
/// </summary>
internal static class Day1
{
    /// <summary>
    /// Takes the input for day 1 and gets the top three
    /// calories from all the elves.
    /// </summary>
    /// <returns>The highest, second highest and third highest calories.</returns>
    public static (int first, int second, int third) GetTopThreeCalories()
    {
        string input = Helpers.GetInput(1);

        string[] elves = input.Split("\r\n");

        int highest = 0;
        int s_highest = 0;
        int t_highest = 0;
        int weightAsInt = 0;

        foreach (string combinedWeight in elves)
        {
            if (int.TryParse(combinedWeight, out int result))
            {
                weightAsInt += result;

                continue;
            }
            
            if (weightAsInt > highest)
            {
                highest = weightAsInt;
            }
            else if (weightAsInt > s_highest)
            {
                s_highest = weightAsInt;
            }
            else if (weightAsInt > t_highest)
            {
                t_highest = weightAsInt;
            }

            weightAsInt = 0;
        }

        return (highest, s_highest, t_highest);
    }

    /// <summary>
    /// Takes the input for day 1 and finds the 
    /// highest calories a elf has.
    /// </summary>
    /// <returns>The largest calorie count.</returns>
    public static int GetHighestCalories()
    {
        string input = Helpers.GetInput(1);

        string[] elves = input.Split("\r\n");

        int highest = 0;
        int weightAsInt = 0;

        foreach (string combinedWeight in elves)
        {
            if (int.TryParse(combinedWeight, out int result))
            {
                weightAsInt += result;

                continue;
            }

            if (weightAsInt > highest)
            {
                highest = weightAsInt;
            }

            weightAsInt = 0;
        }

        return highest;
    }
}
