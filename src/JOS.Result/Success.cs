namespace JOSResult;

public class Success : Result
{
    public Success() : base(true, null!)
    {
    }
}

public class Success<T> : Result<T>
{
    public Success(T data) : base(data)
    {
    }

    public static implicit operator Success(Success<T> _)
    {
        return new Success();
    }
}
