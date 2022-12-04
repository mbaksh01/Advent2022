namespace Advent2022.Benchmarks.Days;

[MemoryDiagnoser(true)]
public class Day4Benchmarks
{
    [Benchmark]
    public void GetContainedPairsCount() => Day4.GetContainedPairsCount();

    [Benchmark]
    public void GetOverlappingPairsCount() => Day4.GetOverlappingPairsCount();
}
