namespace Advent2022.Benchmarks.Days;

[MemoryDiagnoser(true)]
public class Day2Benchmarks
{
    [Benchmark]
    public void GetTotalScore() => Day2.GetTotalScore();

    [Benchmark]
    public void GetTotalScore2() => Day2.GetTotalScore2();
}
