namespace Advent2022.Days;

/// <summary>
/// Day 5 challenges.
/// </summary>
internal class Day5
{
    /// <summary>
    /// Dictionary containing stack numbers and their crates.
    /// </summary>
    internal static Dictionary<int, List<char>> _stacks = new();

    /// <summary>
    /// Takes the input of day 5 and executes all the actions
    /// to find the final state of the crates. Then returns the
    /// top crates from all of the stacks as a string.
    /// </summary>
    /// <param name="craneModel">Model number of crane.</param>
    /// <returns>String of all the top crates.</returns>
    public static string GetCrateOrder(int craneModel)
    {
        string input = Helpers.GetInput(5);

        string[] rows = input.Split("\r\n");

        int rowPosition = ParseStacks(rows);

        if (craneModel == 9000)
        {
            for (int i = rowPosition; i < rows.Length; i++)
            {
                string[] command = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                MoveCrates9000(
                    int.Parse(command[3]),
                    int.Parse(command[5]),
                    int.Parse(command[1]));
            }
        }
        else
        {
            for (int i = rowPosition; i < rows.Length; i++)
            {
                string[] command = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                MoveCrates9001(
                    int.Parse(command[3]),
                    int.Parse(command[5]),
                    int.Parse(command[1]));
            }
        }

        return GetTopCrates();
    }

    /// <summary>
    /// Takes a list of crate rows and parses them into
    /// the <see cref="_stacks"/> dictionary.
    /// </summary>
    /// <param name="crates">List of creates to parse.</param>
    internal static void LoadStacks(string[] crates)
    {
        foreach (string row in crates)
        {
            int stack = 1;

            for (int i = 0; i < row.Length; i += 4)
            {
                if (!_stacks.ContainsKey(stack))
                {
                    _stacks.Add(stack, new());

                    if (!char.IsWhiteSpace(row[i + 1]))
                    {
                        _stacks[stack].Add(row[i + 1]);
                    }

                    stack++;

                    continue;
                }
                
                if (!char.IsWhiteSpace(row[i + 1]))
                {
                    _stacks[stack].Add(row[i + 1]);
                }

                stack++;
            }
        }

        foreach (int key in _stacks.Keys)
        {
            _stacks[key].Reverse();
        }
    }

    /// <summary>
    /// Reorders the crates using the 
    /// </summary>
    /// <param name="fromStack"></param>
    /// <param name="toStack"></param>
    /// <param name="count"></param>
    internal static void MoveCrates9000(int fromStack, int toStack, int count)
    {
        for (int i = 0; i < count; i++)
        {
            char crate = _stacks[fromStack].Last();

            _stacks[toStack].Add(crate);

            _stacks[fromStack].RemoveAt(_stacks[fromStack].Count - 1);
        }
    }

    internal static void MoveCrates9001(int fromStack, int toStack, int count)
    {
        for (int i = 0; i < count; i++)
        {
            char crate = _stacks[fromStack][_stacks[fromStack].Count - count + i];

            _stacks[toStack].Add(crate);

            _stacks[fromStack].RemoveAt(_stacks[fromStack].Count - count + i); 
        }
    }

    internal static int ParseStacks(string[] rows)
    {
        List<string> currentCrates = new();

        int rowPosition = 1;

        foreach (string row in rows)
        {
            if (int.TryParse(row[1].ToString(), out _))
            {
                rowPosition++;
                break;
            }

            currentCrates.Add(row);
            rowPosition++;
        }

        LoadStacks(currentCrates.ToArray());

        return rowPosition;
    }

    internal static string GetTopCrates()
    {
        string output = string.Empty;

        foreach (int key in _stacks.Keys)
        {
            output += _stacks[key].Last();
        }

        return output;
    }
}
