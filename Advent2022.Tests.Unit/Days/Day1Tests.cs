namespace Advent2022.Tests.Unit.Days;

public class Day1Tests
{
    [Fact]
    public void GetTopThreeCaloriesTest()
    {
        // Act
        var (first, second, third) = Day1.GetTopThreeCalories();

        int total = first + second + third;

        // Assert
        _ = total.Should().Be(195292);
    }

    [Fact]
    public void GetHighestCaloriesTest()
    {
        int highest = Day1.GetHighestCalories();

        // Assert
        _ = highest.Should().Be(66306);
    }
}