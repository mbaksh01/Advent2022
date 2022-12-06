namespace Advent2022.Tests.Unit.Days;

public class Day6Tests
{
    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void GetStartOfPackatMarkerTest(string dataStream, int index)
    {
        // Act
        int response = Day6.GetStartOfPackatMarker(dataStream);

        // Assert
        _ = response.Should().Be(index);
    }
}
