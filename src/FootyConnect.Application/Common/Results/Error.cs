namespace FootyConnect.Application.Common.Results;

public sealed record Error(string Code, string Message)
{
    internal static readonly Error None = new(ErrorTypeConstant.None, string.Empty);
    public static implicit operator Result(Error error) => Result.Failure(error);
}
