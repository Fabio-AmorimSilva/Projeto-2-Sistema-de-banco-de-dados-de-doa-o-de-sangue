namespace BloodDonationManagement.Application.Dtos;

public class ResultDto
{
    public string Message { get; set; } = null!;
    public bool IsSuccess { get; set; }

    public static ResultDto Success()
        => new ResultDto
        {
            IsSuccess = true
        };

    public static ResultDto Error(string message)
        => new ResultDto
        {
            IsSuccess = false,
            Message = message
        };
}

public class ResultDto<T> : ResultDto
{
    public T? Data { get; set; }

    public ResultDto()
    {
    }
    
    public ResultDto(T? data)
    {
        Data = data;
    }
    
    public new static ResultDto<T> Success()
        => new()
        {
            IsSuccess = true
        };

    public new static ResultDto<T> Error(string message)
        => new()
        {
            IsSuccess = false,
            Message = message
        };
}