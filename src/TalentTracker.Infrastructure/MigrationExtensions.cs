using TalentTracker.Shared.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TalentTracker.Infrastructure;

public static class MigrationExtensions
{
    public static IHost UseTalentTrackerMigration(this IHost app)
    {
        // configure seed
        app.MigrateDbContext<TalentTrackerDBContext>((context, services) =>
        {
            var env = services.GetService<IWebHostEnvironment>();
            var settings = services.GetService<IOptions<TalentTrackerInfrastructureSettings>>();
            var logger = services.GetService<ILogger<TalentTrackerDbContextSeeding>>();

            if (settings?.Value?.EnableMigration ?? false)
                context.Database.Migrate();

            new TalentTrackerDbContextSeeding()
                .SeedAsync(context, env, settings, logger)
                .Wait();
        });

        return app;
    }
}