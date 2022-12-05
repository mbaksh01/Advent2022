namespace Advent2022.Benchmarks.Days;

[MemoryDiagnoser(true)]
public class Day5Benchmarks
{
    [Benchmark]
    public void GetCrateOrder9000() => Day5.GetCrateOrder(9000);

    [Benchmark]
    public void GetCrateOrder9001() => Day5.GetCrateOrder(9001);
}
