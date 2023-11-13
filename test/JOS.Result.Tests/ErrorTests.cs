using Shouldly;
using Xunit;

namespace JOS.Result.Tests;

public class ErrorTests
{
    [Fact]
    public void ShouldBePossibleToAddExtraDataToError()
    {
        var error = new Error("SomeType", "Any message")
        {
            ["otherData"] = "some data"
        };

        error.ErrorType.ShouldBe("SomeType");
        error.ErrorMessage.ShouldBe("Any message");
        error["otherData"] = "some data";
    }
}
