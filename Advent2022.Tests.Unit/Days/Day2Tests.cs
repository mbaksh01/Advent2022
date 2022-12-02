namespace Advent2022.Tests.Unit.Days;

public class Day2Tests
{
    [Fact]
    public void RockPaperScisorsTest()
    {
        _ = Day2.GetRoundResult('A', 'X').Should().Be(Day2.Outcome.Draw);
        _ = Day2.GetRoundResult('B', 'X').Should().Be(Day2.Outcome.Loss);
        _ = Day2.GetRoundResult('C', 'X').Should().Be(Day2.Outcome.Win);
        _ = Day2.GetRoundResult('A', 'Y').Should().Be(Day2.Outcome.Win);
        _ = Day2.GetRoundResult('B', 'Y').Should().Be(Day2.Outcome.Draw);
        _ = Day2.GetRoundResult('C', 'Y').Should().Be(Day2.Outcome.Loss);
        _ = Day2.GetRoundResult('A', 'Z').Should().Be(Day2.Outcome.Loss);
        _ = Day2.GetRoundResult('B', 'Z').Should().Be(Day2.Outcome.Win);
        _ = Day2.GetRoundResult('C', 'Z').Should().Be(Day2.Outcome.Draw);
    }

    [Fact]
    public void GetRoundScoreTest()
    {
        _ = Day2.GetRoundScore('A', 'X').Should().Be(Day2.Hand.Scissors);
        _ = Day2.GetRoundScore('B', 'X').Should().Be(Day2.Hand.Rock);
        _ = Day2.GetRoundScore('C', 'X').Should().Be(Day2.Hand.Paper);
        _ = Day2.GetRoundScore('A', 'Y').Should().Be(Day2.Hand.Rock);
        _ = Day2.GetRoundScore('B', 'Y').Should().Be(Day2.Hand.Paper);
        _ = Day2.GetRoundScore('C', 'Y').Should().Be(Day2.Hand.Scissors);
        _ = Day2.GetRoundScore('A', 'Z').Should().Be(Day2.Hand.Paper);
        _ = Day2.GetRoundScore('B', 'Z').Should().Be(Day2.Hand.Scissors);
        _ = Day2.GetRoundScore('C', 'Z').Should().Be(Day2.Hand.Rock);
    }

    [Fact]
    public void Part1Answer() => _ = Day2.GetTotalScore().Should().Be(11150);

    [Fact]
    public void Part2Answer() => _ = Day2.GetTotalScore2().Should().Be(8295);
}
