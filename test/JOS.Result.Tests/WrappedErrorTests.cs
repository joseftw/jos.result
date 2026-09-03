using JOSResult;
using Shouldly;
using Xunit;

namespace JOS.Result.Tests;

public class WrappedErrorTests
{
    [Fact]
    public void ShouldReturnPublicErrorWhenReadingErrorMessage()
    {
        var notFoundError = new NotFoundError("Account", "some-id");

        var result = new PublicError("This is the public message", notFoundError);

        result.ErrorMessage.ShouldBe("This is the public message");
        result.ErrorType.ShouldBe(notFoundError.ErrorType);
        result.Error.ShouldBe(notFoundError);
    }
}

public class PublicError : WrappedError
{
    public PublicError(string message, Error error) : base(message, error)
    {
    }
}
