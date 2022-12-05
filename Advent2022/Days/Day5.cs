namespace Advent2022.Days;

internal class Day5
{
    internal static Dictionary<int, List<char>> _stacks = new();

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

    internal static void MoveCrates9000(int fromStack, int toStack, int count)
    {
        for (int i = 0; i < count; i++)
        {
            char crate = _stacks[fromStack].Last();

            _stacks[toStack].Add(crate);

            _stacks[fromStack].Remove(_stacks[fromStack].Count - 1);
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

    public static string GetCrateOrder9000()
    {
        string input = Helpers.GetInput(5);

        string[] rows = input.Split("\r\n");

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

        for (int i = rowPosition; i < rows.Length; i++)
        {
            string[] command = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            MoveCrates9000(
                int.Parse(command[3]),
                int.Parse(command[5]),
                int.Parse(command[1]));
        }

        string output = string.Empty;

        foreach (int key in _stacks.Keys)
        {
            output += _stacks[key].Last();
        }

        return output;
    }

    public static string GetCrateOrder9001()
    {
        string input = Helpers.GetInput(5);

        string[] rows = input.Split("\r\n");

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

        for (int i = rowPosition; i < rows.Length; i++)
        {
            string[] command = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            MoveCrates9001(
                int.Parse(command[3]),
                int.Parse(command[5]),
                int.Parse(command[1]));
        }

        string output = string.Empty;

        foreach (int key in _stacks.Keys)
        {
            output += _stacks[key].Last();
        }

        return output;
    }
}
