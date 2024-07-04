﻿using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TalentTracker.Shared.Application.Events;
using TalentTracker.Shared.Helpers;
using TalentTracker.Shared.Models.Configurations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace TalentTracker.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTalentTrackerApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            //set to true for backward compatibility
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
        });

        services.AddVersionedApiExplorer(options =>
        {
            // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            // note: the specified format code will format the version as "'v'major[.minor][-status]"
            options.GroupNameFormat = "'v'VVV";

            // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
            // can also be used to control the format of the API version in route templates
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddTimestampProvider();

        services.TryAddSingleton<AsyncMediator>();
        services.TryAddSingleton<IAsyncMediator, AsyncMediator>();
        services.AddSingleton<IHtmlInputSanitizer, HtmlInputSanitizer>();

        //Change InvalidModelStateResponseFactory so the middleware will handle validation error
        services.Configure<ApiBehaviorOptions>(options
            => options.InvalidModelStateResponseFactory = CustomInvalidModelStateResponseFactory);

        return services;
    }

    private static Func<ActionContext, IActionResult> CustomInvalidModelStateResponseFactory => actionContext =>
    {
        string message = "One or more validation errors occurred.";
        throw new ValidationException(message, actionContext.ModelState.Select(c => new FluentValidation.Results.ValidationFailure(c.Key, string.Join('|', c.Value!.Errors.Select(e => e.ErrorMessage)), c.Value.AttemptedValue)));
    };

    /// <summary>
    /// Registers the ICurrentUserHelper to services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCurrentUserProvider(this IServiceCollection services)
    {
        //services.AddSingleton<ICurrentUserHelper, HttpContextCurrentUserHelper>();
        services.AddHttpContextAccessor();
        return services;
    }

    /// <summary>
    /// Registers the ICurrentUserHelper to services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddTimestampProvider(this IServiceCollection services)
    {
        services.AddSingleton<ITimestampHelper, TimestampHelper>();
        return services;
    }
    public static IServiceCollection AutoRegisterServices(this IServiceCollection serviceCollection, Assembly assembly)
    {
        if (assembly == null)
            throw new ArgumentNullException(nameof(assembly));

        var implementedServices = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(IRegisterableService).IsAssignableFrom(t))
            .ToList();

        foreach (var implementedService in implementedServices)
        {
            var implementedServiceInterfaces = implementedService.GetInterfaces()
                .Where(i => i != typeof(IRegisterableService) && i != typeof(ITransientService) &&
                    i != typeof(IScopedService) && i != typeof(ISingletonService)).ToList();

            foreach (var implementedServiceInterface in implementedServiceInterfaces)
            {
                if (typeof(ITransientService).IsAssignableFrom(implementedServiceInterface))
                    serviceCollection.AddTransient(implementedServiceInterface, implementedService);
                else if (typeof(IScopedService).IsAssignableFrom(implementedServiceInterface))
                    serviceCollection.AddScoped(implementedServiceInterface, implementedService);
                else if (typeof(ISingletonService).IsAssignableFrom(implementedServiceInterface))
                    serviceCollection.AddSingleton(implementedServiceInterface, implementedService);
            }
        }

        return serviceCollection;
    }

    public static IServiceCollection AddApplicationCORS(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(c =>
        {
            c.AddPolicy(WebApiSettings.CORSPolicy,
            builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                //Expose content-disposition so FE can get the filename
                .WithExposedHeaders("content-disposition")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials();
            });
        });

        return services;
    }
}
