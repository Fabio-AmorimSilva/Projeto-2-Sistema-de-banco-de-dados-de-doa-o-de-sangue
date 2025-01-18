using Microsoft.Extensions.DependencyInjection;

namespace BloodDonationManagement.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.TryAddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<GetAddressViaCepService>();
        services.AddScoped<BloodStockQuantityNotificationService>();

        return services;
    }
}