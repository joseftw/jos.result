using System;

namespace JOS.Result;

public static class ResultExtensions
{
    public static Result MissingPatternMatch(this Result result)
    {
        throw new Exception($"You have forgotten to match '{result.GetType().Name}'");
    }
}
