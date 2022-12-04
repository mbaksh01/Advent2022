namespace Advent2022.Tests.Unit.Days;

public class Day4Tests
{
    [Fact]
    public void ParseRangeTest()
    {
        _ = Day4.ParseRange("2-5").Should().Be(new Range(2, 5));
        _ = Day4.ParseRange("6-6").Should().Be(new Range(6, 6));
        _ = Day4.ParseRange("45-51").Should().Be(new Range(45, 51));
        _ = Day4.ParseRange("12-89").Should().Be(new Range(12, 89));
    }

    [Fact]
    public void CompareRangesTest()
    {
        _ = Day4.CompareRanges(new Range(2, 4) , new Range(6, 8)).Should().BeFalse();
        _ = Day4.CompareRanges(new Range(2, 3) , new Range(4, 5)).Should().BeFalse();
        _ = Day4.CompareRanges(new Range(5, 7) , new Range(7, 9)).Should().BeFalse();
        _ = Day4.CompareRanges(new Range(2, 8) , new Range(3, 7)).Should().BeTrue();
        _ = Day4.CompareRanges(new Range(4, 6) , new Range(6, 6)).Should().BeTrue();
    }

    [Fact]
    public void GetContainedPairsCountTest() => _ = Day4.GetContainedPairsCount().Should().Be(433);

    [Fact]
    public void IsOverlappingTest()
    {
        _ = Day4.IsOverlapping(new Range(2, 4), new Range(6, 8)).Should().BeFalse();
        _ = Day4.IsOverlapping(new Range(2, 3), new Range(4, 5)).Should().BeFalse();
        _ = Day4.IsOverlapping(new Range(5, 7), new Range(7, 9)).Should().BeTrue();
        _ = Day4.IsOverlapping(new Range(2, 8), new Range(3, 7)).Should().BeTrue();
        _ = Day4.IsOverlapping(new Range(4, 6), new Range(6, 6)).Should().BeTrue();
        _ = Day4.IsOverlapping(new Range(2, 6), new Range(4, 8)).Should().BeTrue();
    }

    [Fact]
    public void GetOverlappingPairsCountTest() => _ = Day4.GetOverlappingPairsCount().Should().Be(852);
}
