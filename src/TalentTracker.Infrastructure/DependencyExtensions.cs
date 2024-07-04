using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TalentTracker.Application.Common.Repositories;
using TalentTracker.Infrastructure.Repositories;
using TalentTracker.Shared.Extensions;
namespace TalentTracker.Infrastructure;

public static class DependencyExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IHostEnvironment environment, IConfiguration configuration)
    {
        services.Configure<TalentTrackerInfrastructureSettings>(configuration.GetSection("TalentTrackerSettings:Infrastructure"));

        services.AddDbContext<TalentTrackerDBContext>(options => options.BuildReadOptimizedDbContext(environment, configuration.GetConnectionString(nameof(TalentTrackerDBContext))!,
          typeof(DependencyExtensions).Assembly.GetName().Name!),
          ServiceLifetime.Scoped); //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
        services.AddDbContext<TalentTrackerDBContext>(options => options.BuildReadOptimizedDbContext(environment, configuration.GetConnectionString(nameof(TalentTrackerDBContext))),
        ServiceLifetime.Scoped);

        services.AddScoped<ICandidateRepository, CandidateRepository>();
        services.AddScoped<IReadOnlyCandidateRepository, ReadOnlyCandidateRepository>();
        services.AddScoped<IEventLogRepository, EventLogRepository>();

        return services;
    }
}
