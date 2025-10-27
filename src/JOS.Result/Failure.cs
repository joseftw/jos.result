namespace JOSResult;

public class Failure : Result
{
    public string ErrorMessage => Error!.ErrorMessage;
    public string ErrorType => Error!.ErrorType;

    public Failure(Error error) : base(false, error)
    {
    }
}

public class Failure<T> : Result<T>
{
    public string ErrorMessage => Error!.ErrorMessage;
    public string ErrorType => Error!.ErrorType;

    public Failure(Error error) : base(error)
    {
    }

    public static implicit operator Failure(Failure<T> errorResult)
    {
        return new Failure(errorResult.Error!);
    }
}
