namespace Hp_Web_App.Shared.Authentication;
public class Result<TSuccess, TError>
{
    public TSuccess Success1 { get; } = default!;
    public TError Error { get; } = default!;
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    private Result(TSuccess success)
    {
        Success1 = success;
        IsSuccess = true;
    }

    private Result(TError error)
    {
        Error = error;
        IsSuccess = false;
    }

    public static Result<TSuccess, TError> Success(TSuccess success) => new(success);
    public static Result<TSuccess, TError> Failure(TError error) => new(error);

    public static implicit operator Result<TSuccess, TError>(TSuccess success)
        => Success(success);

    public static implicit operator Result<TSuccess, TError>(TError error)
        => Failure(error);
}





