using System.Diagnostics;

namespace Advent2022.Days;

/// <summary>
/// Day 6 challenges.
/// </summary>
internal class Day6
{
    /// <summary>
    /// Gets the position where the start of a packet is.
    /// </summary>
    /// <returns>
    /// The cardinal position of the last character of the packet identifier.
    /// </returns>
    public static int GetStartOfPackatMarker()
    {
        string input = Helpers.GetInput(6);

        return IdentifyUniqueSection(input, 4);
    }

    /// <summary>
    /// Gets the position where the start of a message is.
    /// </summary>
    /// <returns>
    /// The cardinal position of the last character of the message identifier.
    /// </returns>
    public static int GetStartOfMessageMarker()
    {
        string input = Helpers.GetInput(6);

        return IdentifyUniqueSection(input, 14);
    }

    /// <summary>
    /// Takes in a <paramref name="dataStream"/> and then find a unique section
    /// the length of <paramref name="sectionLength"/>.
    /// </summary>
    /// <param name="dataStream"></param>
    /// <param name="sectionLength">Length of unique string.</param>
    /// <returns>
    /// The cardinal position of the last character in the unique string.
    /// </returns>
    /// <exception cref="UnreachableException"></exception>
    internal static int IdentifyUniqueSection(ReadOnlySpan<char> dataStream, int sectionLength)
    {
        List<char> dataStreamCharacters = new();

        // Loop through data stream.
        for (int i = 0; i < dataStream.Length; i++)
        {
            // Get current character.
            char c = dataStream[i];

            // Check if character is contained within list.
            if (dataStreamCharacters.Contains(c))
            {
                // If it exists, remove the character and all characters before it.
                int keyIndex = dataStreamCharacters.IndexOf(c);

                dataStreamCharacters.RemoveRange(0, keyIndex + 1);
            }

            // Add character.
            dataStreamCharacters.Add(c);

            // Check if list length is desired length. If so return current value's cardinal position.
            if (dataStreamCharacters.Count == sectionLength)
            {
                return i + 1;
            }
        }

        // Malformed input.
        throw new UnreachableException("The given input was not expected to reach this line.");
    }
}
