# JOS.Result
https://josef.codes/my-take-on-the-result-class-in-c-sharp/

## Breaking changes

### Version 4
`FailureResult` has been renamed to `Failure`
`SuccessResult` has been renamed to `Success`

### Version 3
All types moved to the `JOSResult` namespace instead of `JOS.Result` to avoid 
having to type `Result.Result`. Update your usings from
```csharp
using JOS.Result;
```
to
```csharp
using JOSResult;
```

Made `ErrorType` static
