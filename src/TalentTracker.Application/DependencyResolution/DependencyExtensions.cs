using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TalentTracker.Application.DependencyResolution;

public static class DependencyExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyExtensions).Assembly;
        services.AddMediatR(assembly);
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
