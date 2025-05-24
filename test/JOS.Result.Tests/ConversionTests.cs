using JOSResult;
using Shouldly;
using Xunit;

namespace JOS.Result.Tests;

public class ConversionTests
{
    [Fact]
    public void CanConvertImplicitlyFromGenericErrorResultToErrorResult()
    {
        var result = new FailedResult<MyData>(new Error("Some error", "Any"));

        FailedResult failedResult = result;

        failedResult.Error!.ErrorMessage.ShouldBe(result.Error!.ErrorMessage);
    }

    [Fact]
    public void CanConvertImplicitlyFromGenericSuccessResultToSuccessResult()
    {
        var genericSuccessResult = new SucceededResult<MyData>(new MyData());

        SucceededResult successResult = genericSuccessResult;

        successResult.Succeeded.ShouldBeTrue();
    }
}
