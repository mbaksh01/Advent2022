namespace Advent2022.Days;

internal class Day2
{
    enum Hands
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    enum Outcome
    {
        Win = 6,
        Draw = 3,
        Loss = 0
    }

    private static Hands GetHands(char input) => input switch
    {
        'A' or 'X' => Hands.Rock,
        'B' or 'Y' => Hands.Paper,
        'C' or 'Z' => Hands.Scissors,
        _ => throw new ArgumentException(),
    };


    private static Outcome GetRoundsResult(char player1, char player2)
    {
        if (player1 == player2)
        {
            return Outcome.Draw;
        }

        if (GetHands(player1) + 1 == GetHands(player2))
        {
            return Outcome.Win;
        }
    }

    public static int GetTotalScore()
    {
        string input = Helpers.GetInput(2);

        string[] rounds = input.Split("\n\r");

        foreach (string round in rounds)
        {
            if (GetHands(round[0]))
        }

        return 0;
    }
}
