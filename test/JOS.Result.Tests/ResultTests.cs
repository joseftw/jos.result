using System;
using NSubstitute;
using Shouldly;
using Xunit;

namespace JOS.Result.Tests;

public class ResultTests
{
    [Fact]
    public void ShouldThrowExceptionWhenTryingToAccessDataOnErrorResultWhenSuccessIsFalse()
    {
        var result = Result.Failure<MyData>(new Error("error from test", "any"));

        var exception = Should.Throw<Exception>(() => result.Data);

        exception.Message.ShouldBe("You can't access .Data when .Success is false");
    }

    [Fact]
    public void SuccessShouldBeTrueForSuccessResult()
    {
        var result = new SucceededResult();

        result.Succeeded.ShouldBeTrue();
        result.Failed.ShouldBeFalse();
    }

    [Fact]
    public void SuccessShouldBeTrueForGenericSuccessResult()
    {
        var result = new SucceededResult<object>(null);

        result.Succeeded.ShouldBeTrue();
        result.Failed.ShouldBeFalse();
    }

    [Fact]
    public void FailureShouldBeTrueForErrorResult()
    {
        var result = new FailedResult(new Error("error from test", "any"));

        result.Failed.ShouldBeTrue();
        result.Succeeded.ShouldBeFalse();
    }

    [Fact]
    public void FailureShouldBeTrueForGenericErrorResult()
    {
        var result = new FailedResult<object>(new Error("error from test", "any"));

        result.Failed.ShouldBeTrue();
        result.Succeeded.ShouldBeFalse();
    }

    [Fact]
    public void ShouldBeAbleToReturnSuccessResultForResult()
    {
        var sut = Substitute.For<IDummyInterface>();
        var returnResult = new SucceededResult();
        sut.Execute().Returns(returnResult);

        var result = sut.Execute();

        result.ShouldBe(returnResult);
    }

    [Fact]
    public void ShouldBeAbleToReturnGenericSuccessResultForResult()
    {
        var sut = Substitute.For<IDummyInterface>();
        var returnResult = new SucceededResult<MyData>(new MyData());
        sut.Execute().Returns(returnResult);

        var result = sut.Execute();

        result.ShouldBe(returnResult);
    }

    [Fact]
    public void ShouldBeAbleToReturnErrorResultForResult()
    {
        var sut = Substitute.For<IDummyInterface>();
        var returnResult = new FailedResult(new Error("error from test", "any"));
        sut.Execute().Returns(returnResult);

        var result = sut.Execute();

        result.ShouldBe(returnResult);
    }

    [Fact]
    public void ShouldBeAbleToReturnGenericErrorResultForResult()
    {
        var sut = Substitute.For<IDummyInterface>();
        var returnResult = new FailedResult<MyData>(new Error("error from test", "any"));
        sut.Execute().Returns(returnResult);

        var result = sut.Execute();

        result.ShouldBe(returnResult);
    }

    [Fact]
    public void ShouldBeAbleToReturnGenericSuccessResultForGenericResult()
    {
        var sut = Substitute.For<IDummyInterface>();
        var returnResult = new SucceededResult<MyData>(new MyData());
        sut.ExecuteGeneric().Returns(returnResult);

        var result = sut.ExecuteGeneric();

        result.ShouldBe(returnResult);
    }

    [Fact]
    public void ShouldBeAbleToReturnGenericErrorResultForGenericResult()
    {
        var sut = Substitute.For<IDummyInterface>();
        var returnResult = new FailedResult<MyData>(new Error("error from test", "any"));
        sut.ExecuteGeneric().Returns(returnResult);

        var result = sut.ExecuteGeneric();

        result.ShouldBe(returnResult);
    }
}
