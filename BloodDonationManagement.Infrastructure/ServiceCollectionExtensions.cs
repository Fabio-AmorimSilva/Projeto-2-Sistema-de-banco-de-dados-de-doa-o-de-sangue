namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDonorRepository, DonorRepository>();
        services.AddScoped<IBloodStockRepository, BloodStockRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGetAddressViaCepService, GetAddressViaCepService>();
        services.AddScoped<IAiService, AiService>();

        services.AddScoped<PasswordHashService>();
        services.AddScoped<JwtTokenService>();
        
        services.AddDbContext<BloodDonationManagementDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services
            .AddJwtConfig(configuration)
            .AddOpenAiServices(configuration);
        
        return services;
    }
    
    public static IServiceCollection AddJwtConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(settings);

        var appSettings = settings.Get<JwtSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings?.JwtKey!);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer("Bearer",options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = appSettings!.ValidOn,
                ValidIssuer = appSettings.Emissary
            };
        });

        return services;
    }

    public static IServiceCollection AddOpenAiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AiModel>(configuration.GetSection("OpenAi"));
        
        return services;
    }
}