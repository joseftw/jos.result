using System;
using System.Collections.Generic;

namespace JOS.Result;

public class Error : Dictionary<string, object>
{
    public Error(string errorType, string errorMessage) : base(0)
    {
        ErrorType = errorType ?? throw new ArgumentNullException(nameof(errorType));
        ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
    }

    public string ErrorType { get; }
    public string ErrorMessage { get; }
}
