﻿using System.Collections.Generic;
using JOSResult;

namespace JOS.Result.BlogExamples
{
    public class NotFoundResult<T> : ErrorResult<T>
    {
        public NotFoundResult(string message) : base(message)
        {
        }

        public NotFoundResult(string message, IReadOnlyCollection<Error> errors) : base(message, errors)
        {
        }
    }
}
