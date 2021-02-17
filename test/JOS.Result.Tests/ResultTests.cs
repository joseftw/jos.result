using System;
using NSubstitute;
using Shouldly;
using Xunit;

namespace JOS.Result.Tests
{
    public class ResultTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenTryingToAccessDataOnErrorResultWhenSuccessIsFalse()
        {
            var result = new ErrorResult<MyData>("error from test");

            var exception = Should.Throw<Exception>(() => result.Data);

            exception.Message.ShouldBe("You can't access .Data when .Success is false");
        }

        [Fact]
        public void SuccessShouldBeTrueForSuccessResult()
        {
            var result = new SuccessResult();

            result.Success.ShouldBeTrue();
            result.Failure.ShouldBeFalse();
        }

        [Fact]
        public void SuccessShouldBeTrueForGenericSuccessResult()
        {
            var result = new SuccessResult<object>(null);

            result.Success.ShouldBeTrue();
            result.Failure.ShouldBeFalse();
        }

        [Fact]
        public void FailureShouldBeTrueForErrorResult()
        {
            var result = new ErrorResult("error from test");

            result.Failure.ShouldBeTrue();
            result.Success.ShouldBeFalse();
        }

        [Fact]
        public void FailureShouldBeTrueForGenericErrorResult()
        {
            var result = new ErrorResult<object>("error from test");

            result.Failure.ShouldBeTrue();
            result.Success.ShouldBeFalse();
        }

        [Fact]
        public void ShouldBeAbleToReturnSuccessResultForResult()
        {
            var sut = Substitute.For<IDummyInterface>();
            var returnResult = new SuccessResult();
            sut.Execute().Returns(returnResult);

            var result = sut.Execute();

            result.ShouldBe(returnResult);
        }

        [Fact]
        public void ShouldBeAbleToReturnGenericSuccessResultForResult()
        {
            var sut = Substitute.For<IDummyInterface>();
            var returnResult = new SuccessResult<MyData>(new MyData());
            sut.Execute().Returns(returnResult);

            var result = sut.Execute();

            result.ShouldBe(returnResult);
        }

        [Fact]
        public void ShouldBeAbleToReturnErrorResultForResult()
        {
            var sut = Substitute.For<IDummyInterface>();
            var returnResult = new ErrorResult("error from test");
            sut.Execute().Returns(returnResult);

            var result = sut.Execute();

            result.ShouldBe(returnResult);
        }

        [Fact]
        public void ShouldBeAbleToReturnGenericErrorResultForResult()
        {
            var sut = Substitute.For<IDummyInterface>();
            var returnResult = new ErrorResult<MyData>("error from test");
            sut.Execute().Returns(returnResult);

            var result = sut.Execute();

            result.ShouldBe(returnResult);
        }

        [Fact]
        public void ShouldBeAbleToReturnGenericSuccessResultForGenericResult()
        {
            var sut = Substitute.For<IDummyInterface>();
            var returnResult = new SuccessResult<MyData>(new MyData());
            sut.ExecuteGeneric().Returns(returnResult);

            var result = sut.ExecuteGeneric();

            result.ShouldBe(returnResult);
        }

        [Fact]
        public void ShouldBeAbleToReturnGenericErrorResultForGenericResult()
        {
            var sut = Substitute.For<IDummyInterface>();
            var returnResult = new ErrorResult<MyData>("error from test");
            sut.ExecuteGeneric().Returns(returnResult);

            var result = sut.ExecuteGeneric();

            result.ShouldBe(returnResult);
        }

        [Fact]
        public void ShouldBeAbleToPatternMatchResult()
        {
            var sut = Substitute.For<IDummyInterface>();
            var returnResult = new SuccessResult();
            sut.Execute().Returns(returnResult);

            var result = sut.Execute();

            _ = result switch
            {
                SuccessResult successResult => successResult,
                ErrorResult errorResult => errorResult,
                _ => result.MissingPatternMatch()
            };
        }

        [Fact]
        public void ShouldBeAbleToPatternMatchGenericResult()
        {
            var sut = Substitute.For<IDummyInterface>();
            var returnResult = new SuccessResult<MyData>(new MyData());
            sut.ExecuteGeneric().Returns(returnResult);

            var result = sut.ExecuteGeneric();

            _ = result switch
            {
                SuccessResult<MyData> successResult => successResult,
                ErrorResult<MyData> errorResult => errorResult,
                _ => result.MissingPatternMatch()
            };
        }
    }
}
