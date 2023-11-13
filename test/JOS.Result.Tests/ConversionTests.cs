using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace JOS.Result.Tests;

public class ConversionTests
{
    [Fact]
    public void CanConvertImplicitlyFromGenericErrorResultToErrorResult()
    {
        var genericErrorResult = new ErrorResult<MyData>("Some error", new List<Error> {new Error("some details")});

        ErrorResult errorResult = genericErrorResult;

        errorResult.Message.ShouldBe(genericErrorResult.Message);
        errorResult.Errors.ShouldBe(genericErrorResult.Errors);
    }

    [Fact]
    public void CanConvertImplicitlyFromGenericSuccessResultToSuccessResult()
    {
        var genericSuccessResult = new SuccessResult<MyData>(new MyData());

        SuccessResult successResult = genericSuccessResult;

        successResult.Success.ShouldBeTrue();
    }

    [Fact]
    public void ShouldMapErrorResultToGenericErrorResultCorrectly()
    {
        var errorResult = new ErrorResult("My error", new List<Error> {new Error("some details")});

        var genericErrorResult = errorResult.ToGeneric<MyData>();

        genericErrorResult.Message.ShouldBe(errorResult.Message);
        genericErrorResult.Errors.ShouldBe(genericErrorResult.Errors);
    }
}