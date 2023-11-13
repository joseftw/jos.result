namespace JOS.Result;

public class SucceededResult : Result
{
    public SucceededResult() : base(true, null!)
    {
    }
}

public class SucceededResult<T> : Result<T>
{
    public SucceededResult(T data) : base(data)
    {
    }

    public static implicit operator SucceededResult(SucceededResult<T> _)
    {
        return new SucceededResult();
    }
}
