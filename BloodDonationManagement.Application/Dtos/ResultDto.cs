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
    public new static ResultDto<T> Success()
        => new ResultDto<T>()
        {
            IsSuccess = true
        };

    public new static ResultDto<T> Error(string message)
        => new ResultDto<T>()
        {
            IsSuccess = false,
            Message = message
        };
}