namespace Core;

public sealed class Result<T>
{
    public T? Value { get; }
    public Error? Error { get; }
    public bool IsSuccess => Error == Error.None;

    private Result(T value)
    {
        Value = value;
        Error = Error.None;
    }

    private Result(Error error)
    {
        Error = error;
        Value = default!;
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(Error error) => new(error);

    //public TResult ToActionResult<TResult>(
    //    Func<T, TResult> success,
    //    Func<Error, TResult> failure)
    //{
    //    return _isSuccess ? success(_value) : failure(_error);
    //}

}
