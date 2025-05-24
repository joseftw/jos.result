using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using JOSResult;

namespace JOS.Result.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
public class NotFoundBenchmarks
{
    [Benchmark(Baseline = true, OperationsPerInvoke = 100000)]
    public MyData NotFoundThrow()
    {
        try
        {
            return GetMyDataThrow();
        }
        catch (Exception)
        {
            return null!;
        }
    }

    [Benchmark(OperationsPerInvoke = 100000)]
    public MyData NotFoundThrowWithException()
    {
        try
        {
            return GetMyDataThrow();
        }
        catch (Exception)
        {
            return null!;
        }
    }

    [Benchmark (OperationsPerInvoke = 100000)]
    public Result<MyData> NotFoundResult()
    {
        var result = GetMyDataErrorResult();
        return result.Succeeded ? result : null!;
    }

    private static MyData GetMyDataThrow()
    {
        throw new Exception("MyData was not found");
    }

    private static Result<MyData> GetMyDataErrorResult()
    {
        return JOSResult.Result.Failure<MyData>(new Error("NotFound", "MyData was not found"));
    }
}

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
public class FoundBenchmarks
{
    [Benchmark(OperationsPerInvoke = 100000, Baseline = true)]
    public MyData Found()
    {
        return new MyData();
    }

    [Benchmark(OperationsPerInvoke = 100000)]
    public Result<MyData> FoundResult()
    {
        return JOSResult.Result.Success(new MyData());
    }
}
