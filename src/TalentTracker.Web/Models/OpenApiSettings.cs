using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TalentTracker.Api.Models;

public class CreateCandidateDTOFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context) => schema.Example = new OpenApiObject
    {
        [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateCandidateDTO.FirstName))] = new OpenApiString("Joe"),
        [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateCandidateDTO.LastName))] = new OpenApiString("Denver"),
        [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateCandidateDTO.Email))] = new OpenApiString("joe.denver@yopmail.com"),
        [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateCandidateDTO.PhoneNumber))] = new OpenApiString("9808789456"),
        [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateCandidateDTO.FreeTextComment))] = new OpenApiString("lorepsum lopsum"),
        [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateCandidateDTO.LinkedinProfileUrl))] = new OpenApiString("www.linkedin.com/joe.denver"),
        [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateCandidateDTO.GithubProfileUrl))] = new OpenApiString("www.github.com/joe.denver"),
        [System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(CreateCandidateDTO.TimeIntervalToCall))] = new OpenApiString("2pm")
    };
}