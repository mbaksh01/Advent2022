namespace Advent2022.Tests.Unit.Days;

public class Day6Tests
{
    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void IdentifyUniqueSection_Length4(string dataStream, int index)
    {
        // Act
        int response = Day6.IdentifyUniqueSection(dataStream, 4);

        // Assert
        _ = response.Should().Be(index);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void IdentifyUniqueSection_Length14(string dataStream, int index)
    {
        // Act
        int response = Day6.IdentifyUniqueSection(dataStream, 14);

        // Assert
        _ = response.Should().Be(index);
    }

    [Fact]
    public void GetStartOfPackatMarkerTest() => _ = Day6.GetStartOfPackatMarker().Should().Be(1542);

    [Fact]
    public void GetStartOfMessageMarkerTest() => _ = Day6.GetStartOfMessageMarker().Should().Be(3153);
}
