using JOSResult;

namespace JOS.Result.Tests
{
    public interface IDummyInterface
    {
        Result<MyData> ExecuteGeneric();
        JOSResult.Result Execute();
    }

    public class MyData
    {
        
    }
}
