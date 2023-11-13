namespace JOS.Result;

public class FailedResult : Result
{
    public string ErrorMessage => Error!.ErrorMessage;
    public string ErrorType => Error!.ErrorType;

    public FailedResult(Error error) : base(false, error)
    {
    }
}

public class FailedResult<T> : Result<T>
{
    public string ErrorMessage => Error!.ErrorMessage;
    public string ErrorType => Error!.ErrorType;

    public FailedResult(Error error) : base(error)
    {
    }

    public static implicit operator FailedResult(FailedResult<T> errorResult)
    {
        return new FailedResult(errorResult.Error!);
    }
}
