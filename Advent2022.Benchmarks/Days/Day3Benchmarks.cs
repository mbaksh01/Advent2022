namespace Advent2022.Benchmarks.Days;

[MemoryDiagnoser(true)]
public class Day3Benchmarks
{
    [Benchmark]
    public void GetPrioritySum() => Day3.GetPrioritySum();

    [Benchmark]
    public void GetGroupedPrioritySum() => Day3.GetGroupedPrioritySum();
}
