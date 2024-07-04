using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TalentTracker.Services.Shared.Application.Behaviours;
namespace TalentTracker.Shared.Application.Behaviors;

public static class DependecyResolution
{
    public static IServiceCollection AddMediatrBehaviours(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(XssSanitizeBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AsyncValidatorBehavior<,>));

        return services;
    }
}
