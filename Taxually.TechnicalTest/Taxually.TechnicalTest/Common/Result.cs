namespace Taxually.TechnicalTest.Common;

public class Result
{
    public bool IsSuccess { get; private set; }
    
    public string Error { get; private set; }

    public static Result Success() => new() { IsSuccess = true };

    public static Result Failure(string error) => new() { IsSuccess = false, Error = error };
}