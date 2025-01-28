using System;

namespace JOS.Result;

public class Error
{
    public Error(string errorType, string errorMessage)
    {
        ErrorType = errorType ?? throw new ArgumentNullException(nameof(errorType));
        ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
    }

    public string ErrorType { get; }
    public string ErrorMessage { get; }
}
