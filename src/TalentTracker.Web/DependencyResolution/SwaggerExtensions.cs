using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using TalentTracker.Shared.Models.Middlewares;
using TalentTracker.Web.Routing;

namespace TalentTracker.Api.DependencyResolution;

public static class SwaggerExtensions
{
    public static SwaggerGenOptions AddTalentTrackerSwaggerGen(this SwaggerGenOptions options)
    {
        options.EnableAnnotations();

        options.SwaggerDoc(ApiGroupings.TalentTrackerApiGroupingsName, new OpenApiInfo
        {
            Version = "v1",
            Title = "Talent Tracker",
            Description = "Talent Tracker Web API"
        });

        return options;
    }

    public static List<SwaggerEndpointDefinition> UseTalentTrackerSwaggerEndpoints(this List<SwaggerEndpointDefinition> swaggerEndpointDefinitions)
    {
        swaggerEndpointDefinitions.Add(new SwaggerEndpointDefinition($"/swagger/{ApiGroupings.TalentTrackerApiGroupingsName}/swagger.json", "TalentTracker"));

        return swaggerEndpointDefinitions;
    }
}
