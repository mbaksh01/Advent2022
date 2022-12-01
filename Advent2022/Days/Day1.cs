namespace Advent2022.Days;

internal static class Day1
{
    public static (int first, int second, int third) GetTopThreeCalories()
    {
        string input = File.ReadAllText("./Assets/Day1_Input.txt");

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

    public static int GetHighestCalories()
    {
        string input = File.ReadAllText("./Assets/Day1_Input.txt");

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
