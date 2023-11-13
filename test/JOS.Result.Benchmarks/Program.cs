using BenchmarkDotNet.Running;

namespace JOS.Result.Benchmarks;

class Program
{
    static void Main(string[] args)
    {
        var summary1 = BenchmarkRunner.Run<NotFoundBenchmarks>();
        var summary2 = BenchmarkRunner.Run<FoundBenchmarks>();
    }
}