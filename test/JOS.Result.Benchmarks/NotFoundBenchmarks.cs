using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace JOS.Result.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
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
                return null;
            }
        }

        [Benchmark (OperationsPerInvoke = 100000)]
        public Result<MyData> NotFoundResult()
        {
            var result = GetMyDataErrorResult();
            return result.Success ? result : null;
        }

        private static MyData GetMyDataThrow()
        {
            throw new Exception("MyData was not found");
        }

        private static Result<MyData> GetMyDataErrorResult()
        {
            return new ErrorResult<MyData>("MyData was not found");
        }
    }

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
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
            return new SuccessResult<MyData>(new MyData());
        }
}
}
