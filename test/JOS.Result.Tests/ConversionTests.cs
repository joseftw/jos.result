using JOSResult;
using Shouldly;
using Xunit;

namespace JOS.Result.Tests;

public class ConversionTests
{
    [Fact]
    public void CanConvertImplicitlyFromGenericErrorResultToErrorResult()
    {
        var result = new Failure<MyData>(new Error("Some error", "Any"));

        Failure failure = result;

        failure.Error!.ErrorMessage.ShouldBe(result.Error!.ErrorMessage);
    }

    [Fact]
    public void CanConvertImplicitlyFromGenericSuccessResultToSuccessResult()
    {
        var genericSuccessResult = new Success<MyData>(new MyData());

        Success successResult = genericSuccessResult;

        successResult.Succeeded.ShouldBeTrue();
    }
}
