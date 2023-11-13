using System.Collections.Generic;
using System.Net;

namespace JOS.Result.BlogExamples
{
    public class HttpErrorResult : ErrorResult
    {
        public HttpStatusCode StatusCode { get; }

        public HttpErrorResult(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpErrorResult(string message, IReadOnlyCollection<Error> errors, HttpStatusCode statusCode) : base(message, errors)
        {
            StatusCode = statusCode;
        }
    }
}
