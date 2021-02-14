using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace JOS.Result
{
    public abstract class Result
    {
        public bool Success { get; protected set; }
        public bool Failure => !Success;
    }

    public abstract class Result<T> : Result
    {
        private T _data;

        protected Result(T data)
        {
            Data = data;
        }

        public T Data
        {
            get => Success ? _data : throw new Exception($"You can't access .{nameof(Data)} when .{nameof(Success)} is false");
            set => _data = value;
        }
    }

    public class SuccessResult : Result
    {
        public SuccessResult()
        {
            Success = true;
        }
    }

    public class SuccessResult<T> : Result<T>
    {
        public SuccessResult(T data) : base(data)
        {
            Success = true;
        }
    }

    public class ErrorResult : Result, IErrorResult
    {
        public ErrorResult(string message) : this(message, Array.Empty<Error>())
        {
            
        }

        public ErrorResult(string message, IReadOnlyCollection<Error> errors)
        {
            Message = message;
            Success = false;
            Errors = errors ?? Array.Empty<Error>();
        }

        public string Message { get; protected set; }
        public IReadOnlyCollection<Error> Errors { get; }
    }

    public class ErrorResult<T> : Result<T>, IErrorResult
    {
        public ErrorResult(string message) : this(message, Array.Empty<Error>())
        {
            
        }

        public ErrorResult(string message, IReadOnlyCollection<Error> errors) : base(default)
        {
            Message = message;
            Success = false;
            Errors = errors ?? Array.Empty<Error>();
        }

        public string Message { get; protected set; }
        public IReadOnlyCollection<Error> Errors { get; }
    }

    public class RetryResult : ErrorResult
    {
        public RetryResult(string message) : base(message)
        {
            
        }

        public RetryResult(string message, IReadOnlyCollection<Error> errors) : base(message, errors)
        {
            
        }
    }

    public class RetryResult<T> : ErrorResult<T>
    {
        public RetryResult(string message) : base(message)
        {
        }

        public RetryResult(string message, IReadOnlyCollection<Error> errors) : base(message, errors)
        {
        }
    }

    public class HttpErrorResult : ErrorResult, IHttpErrorResult
    {
        public HttpErrorResult(string message) : this(message, Array.Empty<Error>())
        {

        }

        public HttpErrorResult(string message, IReadOnlyCollection<Error> errors) : this(message, errors, null)
        {
        }

        public HttpErrorResult(string message, IReadOnlyCollection<Error> errors, HttpResponseMessage response = default, HttpStatusCode statusCode = default) : base(message, errors)
        {
            Response = response;
            StatusCode = statusCode;
        }

        public HttpResponseMessage Response { get; }
        public HttpStatusCode StatusCode { get; }

        public void Dispose()
        {
            Response?.Dispose();
        }
    }

    public class HttpErrorResult<T> : ErrorResult<T>, IHttpErrorResult
    {
        public HttpErrorResult(string message) : base(message)
        {
        }

        public HttpErrorResult(string message, IReadOnlyCollection<Error> errors) : base(message, errors)
        {
        }

        public HttpErrorResult(string message, IReadOnlyCollection<Error> errors, HttpResponseMessage response = default, HttpStatusCode statusCode = default) : base(message, errors)
        {
            Response = response;
            StatusCode = statusCode;
        }

        public HttpResponseMessage Response { get; }
        public HttpStatusCode StatusCode { get; }

        public void Dispose()
        {
            Response?.Dispose();
        }
    }

    public class Error
    {
        public Error(string details) : this(null, details)
        {

        }

        public Error(string code, string details)
        {
            Code = code;
            Details = details;
        }

        public string Code { get; }
        public string Details { get; }
    }

    internal interface IErrorResult
    {
        string Message { get; }
        IReadOnlyCollection<Error> Errors { get; }
    }

    internal interface IHttpErrorResult : IDisposable
    {
        HttpResponseMessage Response { get; }
        HttpStatusCode StatusCode { get; }
    }
}
