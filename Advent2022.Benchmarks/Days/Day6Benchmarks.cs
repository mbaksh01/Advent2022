namespace Advent2022.Benchmarks.Days;

[MemoryDiagnoser(true)]
public class Day6Benchmarks
{
    [Benchmark]
    public void GetStartOfPackatMarker() => Day6.GetStartOfPackatMarker();

    [Benchmark]
    public void GetStartOfMessageMarker() => Day6.GetStartOfMessageMarker();

    [Benchmark]
    public void IdentifyUniqueSection() => Day6.IdentifyUniqueSection("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14);
}
