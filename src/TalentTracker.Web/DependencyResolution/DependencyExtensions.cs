using MediatR;
using TalentTracker.Infrastructure;
using TalentTracker.Application.DependencyResolution;
using FluentValidation;

namespace TalentTracker.Web.DependencyResolution;

public static class DependencyExtensions
{
    public static IServiceCollection AddWeb(this IServiceCollection services, IHostEnvironment environment, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddInfrastructure(environment, configuration);
        services.AddApplication();

        var assembly = typeof(DependencyExtensions).Assembly;
        services.AddAutoMapper(assembly);
        services.AddMediatR(assembly);
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
