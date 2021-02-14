namespace JOS.Result.Tests
{
    public interface IDummyInterface
    {
        Result<MyData> ExecuteGeneric();
        Result Execute();
    }

    public class MyData
    {
        
    }
}
