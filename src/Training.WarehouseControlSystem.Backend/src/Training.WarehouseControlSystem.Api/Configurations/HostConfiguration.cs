namespace Training.WarehouseControlSystem.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddValidators()
            .AddRepositoriesAndServices()
            .AddPersistence()
            .AddExposers()
            .AddMappers()
            .AddDevTools();

        return new(builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        await app.MigrateDatabaseSchemasAsync();
        app.UseCors()
            .UseIdentityInfrastructure()
            .UseExposers()
            .UseDevTools();

        return app;
    }
}