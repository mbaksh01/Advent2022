namespace Advent2022.Benchmarks.Days;

[MemoryDiagnoser(true)]
public class Day1Benchmarks
{
    [Benchmark]
    public void GetHighestCalories() => Day1.GetHighestCalories();

    [Benchmark]
    public void GetTopThreeCalories() => Day1.GetTopThreeCalories();
}
