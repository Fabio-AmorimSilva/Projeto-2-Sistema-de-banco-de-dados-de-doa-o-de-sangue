namespace BloodDonationManagement.Domain.Common;

public class Result
{
    public string Message { get; set; } = null!;
    public bool IsSuccess { get; set; }

    public static Result Success()
        => new Result
        {
            IsSuccess = true
        };

    public static Result Error(string message)
        => new Result
        {
            IsSuccess = false,
            Message = message
        };
}

public class Result<T> : Result
{
    public T? Data { get; set; }

    public Result()
    {
    }
    
    public Result(T? data)
    {
        Data = data;
    }
    
    public new static Result<T> Success()
        => new()
        {
            IsSuccess = true
        };

    public new static Result<T> Error(string message)
        => new()
        {
            IsSuccess = false,
            Message = message
        };
}