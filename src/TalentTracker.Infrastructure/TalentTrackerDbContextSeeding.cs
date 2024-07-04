using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Infrastructure;


internal class TalentTrackerDbContextSeeding
{
    public async Task SeedAsync(TalentTrackerDBContext context, IWebHostEnvironment env, IOptions<TalentTrackerInfrastructureSettings> settings,
    ILogger<TalentTrackerDbContextSeeding> logger)
    {
        var policy = _CreatePolicy(logger, nameof(TalentTrackerDbContextSeeding));

        await policy.ExecuteAsync(async () =>
        {
            using (context)
            {
                if (settings.Value.EnableMigrationSeed)
                {
                    await _MigrateEnumeration(context, context.EventTypes);
                }
            }
        });
    }

    #region Helpers

    private async Task _MigrateEnumeration<T>(TalentTrackerDBContext context, DbSet<T> entity)
        where T : Enumeration
    {
        var dbEnumerations = (await entity.ToListAsync()) ?? Enumerable.Empty<T>();
        var localEnumerations = Enumeration.GetAll<T>().Where(c => !dbEnumerations.Select(l => l.Id).Contains(c.Id));
        if (localEnumerations.Any())
        {
            foreach (var localEnumeration in localEnumerations)
                await context.AddAsync<T>(localEnumeration);

            await context.SaveChangesAsync();
        }
    }

    private AsyncRetryPolicy _CreatePolicy(ILogger<TalentTrackerDbContextSeeding> logger, string prefix, int retries = 3) => Policy.Handle<SqlException>().
            WaitAndRetryAsync(
                retryCount: retries,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timeSpan, retry, ctx) =>
                {
                    logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries} {TotalMilliseconds}", prefix, exception.GetType().Name, exception.Message, retry, retries, timeSpan.TotalMilliseconds);
                }
            );
    #endregion
}
