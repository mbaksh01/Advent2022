namespace Advent2022.Tests.Unit.Days;

public class Day3Tests
{
    [Fact]
    public void GetPriorityTest_UsingSpan()
    {
        _ = Day3.GetPriority("vJrwpWtwJgWrhcsFMMfFFhFp").Should().Be(16);
        _ = Day3.GetPriority("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL").Should().Be(38);
        _ = Day3.GetPriority("PmmdzqPrVvPwwTWBwg").Should().Be(42);
        _ = Day3.GetPriority("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn").Should().Be(22);
        _ = Day3.GetPriority("ttgJtRGJQctTZtZT").Should().Be(20);
        _ = Day3.GetPriority("CrZsJsPPZsGzwwsLwLmpwMDw").Should().Be(19);
    }

    [Fact]
    public void GetPriorityTest_UsingChar()
    {
        _ = Day3.GetPriority('v').Should().Be(22);
        _ = Day3.GetPriority('G').Should().Be(33);
    }

    [Fact]
    public void GetRepeatedItemTest()
    {
        _ = Day3.GetRepeatedItem("vJrwpWtwJgWrhcsFMMfFFhFp").Should().Be('p');
        _ = Day3.GetRepeatedItem("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL").Should().Be('L');
        _ = Day3.GetRepeatedItem("PmmdzqPrVvPwwTWBwg").Should().Be('P');
        _ = Day3.GetRepeatedItem("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn").Should().Be('v');
        _ = Day3.GetRepeatedItem("ttgJtRGJQctTZtZT").Should().Be('t');
        _ = Day3.GetRepeatedItem("CrZsJsPPZsGzwwsLwLmpwMDw").Should().Be('s');
    }

    [Fact]
    public void GetPrioritySumTest() => _ = Day3.GetPrioritySum().Should().Be(7850);

    [Fact]
    public void GetGroupBadgeTest()
    {
        _ = Day3.GetGroupBadge(
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg").Should().Be('r');

        _ = Day3.GetGroupBadge(
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw").Should().Be('Z');
    }

    [Fact]
    public void GetGroupedPrioritySumTest() => _ = Day3.GetGroupedPrioritySum().Should().Be(2581);
}
