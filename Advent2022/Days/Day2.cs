namespace Advent2022.Days;

internal class Day2
{
    internal enum Hand
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    internal enum Outcome
    {
        Win = 6,
        Draw = 3,
        Loss = 0
    }

    private static Hand GetHand(char input) => input switch
    {
        'A' or 'X' => Hand.Rock,
        'B' or 'Y' => Hand.Paper,
        'C' or 'Z' => Hand.Scissors,
        _ => throw new ArgumentException(),
    };

    private static Outcome GetOutcome(char input) => input switch
    {
        'X' => Outcome.Loss,
        'Y' => Outcome.Draw,
        'Z' => Outcome.Win,
        _ => throw new ArgumentException()
    };

    internal static Outcome GetRoundResult(char player1, char player2)
    {
        if (GetHand(player1) == GetHand(player2))
        {
            return Outcome.Draw;
        }

        if (GetHand(player1) + 1 == GetHand(player2))
        {
            return Outcome.Win;
        }
        
        if ((int)GetHand(player1) - (int)GetHand(player2) == 2)
        {
            return Outcome.Win;
        }

        return Outcome.Loss;
    }

    internal static Hand GetRoundScore(char player1, char outcome)
    {
        Hand player1Hand = GetHand(player1);
        Hand outcomeAsHand = GetHand(outcome);

        if (outcome == 'Y')
        {
            return player1Hand;
        }

        if ((int)player1Hand == (int)outcomeAsHand)
        {
            return (Hand)Math.Abs((int)outcomeAsHand - 4);
        }

        return player1Hand + ((int)outcomeAsHand - 2);
    }

    public static int GetTotalScore()
    {
        string input = Helpers.GetInput(2);

        string[] rounds = input.Split("\r\n");

        int score = 0;

        foreach (string round in rounds)
        {
            score += (int)GetRoundResult(round[0], round[2]);
            score += (int)GetHand(round[2]);
        }

        return score;
    }

    public static int GetTotalScore2()
    {
        string input = Helpers.GetInput(2);

        string[] rounds = input.Split("\r\n");

        int score = 0;

        foreach (string round in rounds)
        {
            score += (int)GetOutcome(round[2]);
            score += (int)GetRoundScore(round[0], round[2]);
        }

        return score;
    }
}
