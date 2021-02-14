using System;

namespace JOS.Result
{
    public static class ResultExtension
    {
        public static Result MissingPatternMatch(this Result result)
        {
            throw new Exception($"You have forgotten to match '{result.GetType().Name}'");
        }

        public static Result<T> MissingPatternMatch<T>(this Result<T> result)
        {
            throw new Exception($"You have forgotten to match '{result.GetType().Name}'");
        }
    }
}
