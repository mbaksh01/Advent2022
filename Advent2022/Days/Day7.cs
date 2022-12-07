namespace Advent2022.Days;

internal class Day7
{
    public static int GetNumbers()
    {
        string input = Helpers.GetInput(7);

        string[] lines = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

        return ProcessLines(lines.Skip(1).ToList(), out _).Where(x => x <= 100_000).Sum();
    }

    internal static List<int> ProcessLines(List<string> lines, out int index)
    {
        List<int> currentDirectory = new();
        int total = 0;

        for (index = 0; index < lines.Count; index++)
        {
            string line = lines[0];

            if (line.StartsWith("$ cd .."))
            {
                //currentDirectory.RemoveAt(currentDirectory.Count - 1);
                currentDirectory.Add(total);
                return currentDirectory;
            }

            if (line.StartsWith("$ cd "))
            {
                // currentDirectory.Add(line.Split(" ")[2]);

                int count = lines.ToList().IndexOf(line) + 1;

                total += ProcessLines(lines.Skip(count).ToList(), out index).Sum();

                //if (output <= 100_000)
                //{
                //    currentDirectoryTotal += output;
                //}

                //currentDirectoryTotal += output;
                currentDirectory.Add(total);

                return currentDirectory;
            }

            if (int.TryParse(line.Split(" ")[0], out int value))
            {
                total += value;
            }
        }

        currentDirectory.Add(total);
        return currentDirectory;
    }

    internal static int GetFolderSize(List<string> items)
    {
        int result = 0;

        foreach (string item in items)
        {
            if (int.TryParse(item.Split(" ")[0], out int value))
            {
                result += value;
            }
        }

        return result;
    }
}
