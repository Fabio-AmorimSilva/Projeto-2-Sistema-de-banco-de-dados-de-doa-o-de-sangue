namespace BloodDonationManagement.Infrastructure;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDonatorRepository, DonatorRepository>();
        services.AddScoped<IBloodStockRepository, BloodStockRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddDbContext<BloodDonationManagementDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        return services;
    }
}