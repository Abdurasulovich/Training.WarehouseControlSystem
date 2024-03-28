using Microsoft.EntityFrameworkCore;

namespace Training.WarehouseControlSystem.Api.Configurations;

public static class MigrationExtension
{
    public static async ValueTask MigrateAsync<TContext>(this IServiceScopeFactory scopeFactory)
        where TContext : DbContext
    {
        await using var scope = scopeFactory.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();

        if ((await context.Database.GetPendingMigrationsAsync()).Any())
            await context.Database.MigrateAsync();
    }
}