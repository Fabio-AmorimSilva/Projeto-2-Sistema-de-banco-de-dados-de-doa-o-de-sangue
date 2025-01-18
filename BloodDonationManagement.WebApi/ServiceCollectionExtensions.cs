namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<ExceptionHandler>();
        
        return services;
    }
    
    public static WebApplicationBuilder AddJwtConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<JwtTokenService>();
        builder.Services.Configure<JwtSettings>(builder.Configuration);
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

        return builder;
    }
}