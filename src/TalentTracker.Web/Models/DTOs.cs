using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using TalentTracker.Application.Commands.Candidate;
using TalentTracker.Shared.Mappings;

namespace TalentTracker.Api.Models;

public class DTOs
{
}

#region Candidate
[SwaggerSchemaFilter(typeof(CreateCandidateDTOFilter))]
public class CreateCandidateDTO : IMapTo<CreateCandidate.Command>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string TimeIntervalToCall { get; set; }
    public string FreeTextComment { get; set; }
    public string LinkedinProfileUrl { get; set; }
    public string GithubProfileUrl { get; set; }
    public void Mapping(Profile profile) => profile.CreateMap<CreateCandidateDTO, CreateCandidate.Command>();
}

public record CreateCandidateResponseDTO : IMapFrom<CreateCandidate.Response>
{
    public Guid CandidateGUID { get; init; }
    public string Email { get; init; }
    public void Mapping(Profile profile) => profile.CreateMap<CreateCandidate.Response, CreateCandidateResponseDTO>();
}
#endregion


