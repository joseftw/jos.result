namespace JOSResult;

/// <summary>
/// Base class for errors that wrap another <see cref="Error"/> while presenting a different message.
/// </summary>

public abstract class WrappedError : Error
{
    protected WrappedError(string message, Error error) : base(error.ErrorType, message)
    {
        Error = error;
    }

    public Error Error { get; }
}
