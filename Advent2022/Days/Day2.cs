using System.Diagnostics;

namespace Advent2022.Days;

/// <summary>
/// Day 2 challenges.
/// </summary>
internal class Day2
{
    /// <summary>
    /// All possible hands that you can play
    /// in Rock Paper Scissors.
    /// The value of each had is the score you get
    /// for playing that hand.
    /// </summary>
    internal enum Hand
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    /// <summary>
    /// All the possible outcomes of a game.
    /// The value of each outcome represents 
    /// the score you get.
    /// </summary>
    internal enum Outcome
    {
        Win = 6,
        Draw = 3,
        Loss = 0
    }

    /// <summary>
    /// Converts the inputs from the text file to 
    /// the <see cref="Hand"/> enum.
    /// </summary>
    /// <param name="input"><see cref="Hand"/> as character.</param>
    /// <returns>The <paramref name="input"/> as a <see cref="Hand"/>.</returns>
    /// <exception cref="UnreachableException">
    /// If the input can not be converted then this exception is thrown,
    /// however for day 2's input it does not contain anything which would 
    /// cause this error to be thrown.
    /// </exception>
    private static Hand GetHand(char input) => input switch
    {
        'A' or 'X' => Hand.Rock,
        'B' or 'Y' => Hand.Paper,
        'C' or 'Z' => Hand.Scissors,
        _ => throw new UnreachableException(),
    };

    /// <summary>
    /// Part 2 of the challenge said that the second column is actually
    /// the expected outcome of the game. This method converts the character
    /// values to their <see cref="Outcome"/>.
    /// </summary>
    /// <param name="input"><see cref="Outcome"/> as character.</param>
    /// <returns></returns>
    /// <exception cref="UnreachableException">
    /// If the input can not be converted then this exception is thrown,
    /// however for day 2's input it does not contain anything which would 
    /// cause this error to be thrown.
    /// </exception>
    private static Outcome GetOutcome(char input) => input switch
    {
        'X' => Outcome.Loss,
        'Y' => Outcome.Draw,
        'Z' => Outcome.Win,
        _ => throw new UnreachableException()
    };

    /// <summary>
    /// Gets the <see cref="Outcome"/> of a round.
    /// </summary>
    /// <param name="player1Hand">Player 1's <see cref="Hand"/> as a character.</param>
    /// <param name="player2Hand">Player 2's <see cref="Hand"/> as a character.</param>
    /// <returns>The outcome of the 2 hands.</returns>
    internal static Outcome GetRoundResult(char player1Hand, char player2Hand)
    {
        if (GetHand(player1Hand) == GetHand(player2Hand))
        {
            return Outcome.Draw;
        }

        if (GetHand(player1Hand) + 1 == GetHand(player2Hand))
        {
            return Outcome.Win;
        }
        
        if ((int)GetHand(player1Hand) - (int)GetHand(player2Hand) == 2)
        {
            return Outcome.Win;
        }

        return Outcome.Loss;
    }

    /// <summary>
    /// Gets the hand which you would be needed to play 
    /// to get the desired <paramref name="outcome"/>.
    /// </summary>
    /// <param name="player1">The hand of your opponent.</param>
    /// <param name="outcome">The <see cref="Outcome"/> you want from this round.</param>
    /// <returns>The hand you should choose.</returns>
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

    /// <summary>
    /// Loops through input of day 2 and gets the 
    /// total score using part 1 logic.
    /// </summary>
    /// <returns>The total score.</returns>
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

    /// <summary>
    /// Loops through input of day 2 and gets the
    /// total score using part 2 logic.
    /// </summary>
    /// <returns>The total score.</returns>
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
