using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TelesEducacao.Conteudos.Data.Configuration;

public static class DbMigrationHelperExtension
{
    public static void UseDbMigrationConteudosHelper(this IServiceProvider serviceProvider)
    {
        DbMigrationHelpers.EnsureSeedData(serviceProvider).Wait();
    }
}

public static class DbMigrationHelpers
{
    public static async Task EnsureSeedData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var conteudosContext = scope.ServiceProvider.GetRequiredService<ConteudosContext>();
        await conteudosContext.Database.MigrateAsync();
    }
}