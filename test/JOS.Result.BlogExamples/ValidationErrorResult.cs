using System.Collections.Generic;

namespace JOS.Result.BlogExamples
{
    public class ValidationErrorResult : ErrorResult
    {
        public ValidationErrorResult(string message) : base(message)
        {
        }

        public ValidationErrorResult(string message, IReadOnlyCollection<ValidationError> errors) : base(message, errors)
        {
        }
    }

    public class ValidationError : Error
    {
        public ValidationError(string propertyName, string details) : base(null, details)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; }
    }
}
