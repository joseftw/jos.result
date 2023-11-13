using System;

namespace JOS.Result;

public class Result
{
    public bool Succeeded { get; }
    public bool Failed => !Succeeded;
    public Error? Error { get; }

    internal Result(bool succeeded, Error error)
    {
        Succeeded = succeeded;
        Error = error;
    }

    public static Result Success() => new(true, null!);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TData> Success<TData>(TData data) => new(data);
    public static Result<TData> Failure<TData>(Error error) => new(error);
}

public class Result<TData> : Result
{
    private TData? _data;

    public TData Data
    {
        get => Succeeded ? _data! : throw new InvalidOperationException($"You can't access .{nameof(Data)} when .{nameof(Success)} is false");
        set => _data = value;
    }

    internal Result(Error error) : base(succeeded: false, error)
    {
    }

    internal Result(TData data) : base(true, null!)
    {
        Data = data;
    }
}
