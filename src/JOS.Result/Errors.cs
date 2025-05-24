namespace JOSResult;

public class ValidationError : Error
{
    public ValidationError(string message) : base(JOSResult.ErrorType.Validation, message)
    {
    }
}

public class ResourceValidationError : ValidationError
{
    public ResourceValidationError(string resource, string message) : base(message)
    {
        Resource = resource;
    }

    public string Resource { get; }
}

public class NullOrEmptyError : ResourceValidationError
{
    public NullOrEmptyError(string resource) : base(resource, $"The property '{resource}' cannot be null or empty.")
    {
    }

    public NullOrEmptyError(string resource, string message) : base(resource, message) { }
}

public class ValueTooLongError : ResourceValidationError
{
    public ValueTooLongError(
        string resource,
        string valueInformation,
        int actualLength,
        string unit,
        int maxLength) : base(resource, CreateMessage(valueInformation, actualLength, unit, maxLength))
    {
    }

    private static string CreateMessage(string valueInformation, int actualLength, string unit, int maxLength)
    {
        return $"The '{valueInformation}' is {actualLength} {unit} long which is too long, " +
               $"max length is {maxLength}";
    }
}

public class ValueTooSmallError : ResourceValidationError
{
    public ValueTooSmallError(
        string resource,
        string valueInformation,
        int actualLength,
        string unit,
        int minLength) : base(resource, CreateMessage(valueInformation, actualLength, unit, minLength))
    {
    }

    private static string CreateMessage(string valueInformation, int actualLength, string unit, int minLength)
    {
        return $"The '{valueInformation}' is {actualLength} {unit} long which is too short, " +
               $"min length is {minLength}";
    }
}

public class NotFoundError : Error
{
    public NotFoundError(string objectType, string id) : base(
        JOSResult.ErrorType.NotFound, $"The {objectType} with id '{id}' could not be found.")
    {
    }
}

public class ConflictError : Error
{
    public ConflictError(string typeName, object propertyValue) : base(
        "Conflict", $"'{propertyValue}' already exists ({typeName})")
    {
    }
}

public class DeserializationError : Error
{
    public DeserializationError(string errorMessage) : base("Deserialization", errorMessage)
    {
    }
}
