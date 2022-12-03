namespace Advent2022;

/// <summary>
/// Helpers for this project.
/// </summary>
internal class Helpers
{
    /// <summary>
    /// The this input for a given <paramref name="day"/>.
    /// </summary>
    /// <param name="day">Day to get input for.</param>
    /// <returns>The input of that day as a string.</returns>
    public static string GetInput(int day) => File.ReadAllText($"./Assets/Day{day}_Input.txt");
}
