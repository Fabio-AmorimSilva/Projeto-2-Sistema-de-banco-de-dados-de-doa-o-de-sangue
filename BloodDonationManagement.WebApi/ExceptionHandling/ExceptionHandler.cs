namespace BloodDonationManagement.WebApi.ExceptionHandling;

internal class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken
    )
    {
        var error = new Error
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = exception.Message 
        };
        
        httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
        await httpContext.Response.WriteAsJsonAsync(error, cancellationToken);

        return true;
    }
}