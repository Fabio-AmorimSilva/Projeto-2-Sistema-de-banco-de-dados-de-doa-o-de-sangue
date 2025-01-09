var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddExceptionHandler()
    .AddApplication();

builder.Services
    .AddInfrastructure(builder.Configuration);

builder.Services.AddOpenApi();
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
            .WithPreferredScheme("Bearer")
            .WithHttpBearerAuthentication(bearer =>
            {
                bearer.Token = "your-bearer-token";
            });
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();