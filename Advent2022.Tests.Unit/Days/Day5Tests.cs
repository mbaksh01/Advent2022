namespace Advent2022.Tests.Unit.Days;

public class Day5Tests
{
    [Fact]
    public void LoadStacksTest()
    {
        Day5._stacks.Clear();

        // Arrange
        string[] crates = new string[]
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]"
        };

        // Act
        Day5.LoadStacks(crates);

        // Assert
        _ = Day5._stacks.Keys.Should().Contain(1);
        _ = Day5._stacks.Keys.Should().Contain(2);
        _ = Day5._stacks.Keys.Should().Contain(3);

        _ = Day5._stacks[1].Count.Should().Be(2);
        _ = Day5._stacks[2].Count.Should().Be(3);
        _ = Day5._stacks[3].Count.Should().Be(1);

        _ = Day5._stacks[1].Last().Should().Be('N');
        _ = Day5._stacks[2].Last().Should().Be('D');
        _ = Day5._stacks[3].Last().Should().Be('P');
    }

    [Fact]
    public void MoveCratesTest()
    {
        Day5._stacks.Clear();

        // Arrange
        string[] crates = new string[]
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]"
        };

        Day5.LoadStacks(crates);

        // Act
        Day5.MoveCrates9000(2, 1, 1);

        // Assert
        _ = Day5._stacks[1].Count.Should().Be(3);
        _ = Day5._stacks[2].Count.Should().Be(2);

        _ = Day5._stacks[1].Last().Should().Be('D');
        _ = Day5._stacks[2].Last().Should().Be('C');
    }

    [Fact]
    public void GetCrateOrder9000Test() => _ = Day5.GetCrateOrder9000().Should().Be("WSFTMRHPP");

    [Fact]
    public void GetCrateOrder9001Test() => _ = Day5.GetCrateOrder9001().Should().Be("GSLCMFBRP");
}
