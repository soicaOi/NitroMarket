using Catalog.Application.Queries.BrandQueries;

namespace Catalog.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var assembly = typeof(GetBrandsQuery).Assembly;
        var licenseKey = configuration.GetSection("MediatR:LicenseKey").Value;

        services.AddMediatR(config =>
        {
            config.LicenseKey = licenseKey;
            config.RegisterServicesFromAssembly(assembly);
        });

        return services;
    }

    public static WebApplication UseApiServices(
        this WebApplication app
    )
    {
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapGet("/", () => "Hello World!");

        return app;
    }
}
