using Microsoft.AspNetCore.Builder;
using TalentTracker.Shared.Models.Configurations;

namespace TalentTracker.Shared.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseApplicationCORS(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseCors(WebApiSettings.CORSPolicy);

        return applicationBuilder;
    }
}
