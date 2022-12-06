using System.Diagnostics;

namespace Advent2022.Days;

internal class Day6
{
    public static int GetStartOfPackatMarker()
    {
        string input = Helpers.GetInput(6);

        return IdentifyUniqueSection(input, 4);
    }

    public static int GetStartOfMessageMarker()
    {
        string input = Helpers.GetInput(6);

        return IdentifyUniqueSection(input, 14);
    }

    internal static int IdentifyUniqueSection(ReadOnlySpan<char> dataStream, int sectionLength)
    {
        List<char> dataStreamCharacters = new();

        for (int i = 0; i < dataStream.Length; i++)
        {
            char c = dataStream[i];

            if (dataStreamCharacters.Contains(c))
            {
                int keyIndex = dataStreamCharacters.IndexOf(c);

                for (int i_ = keyIndex; i_ >= 0; i_--)
                {
                    dataStreamCharacters.RemoveAt(i_);
                }
            }

            dataStreamCharacters.Add(c);

            if (dataStreamCharacters.Count == sectionLength)
            {
                return i + 1;
            }
        }

        throw new UnreachableException("The given input was not expected to reach this line.");
    }
}
