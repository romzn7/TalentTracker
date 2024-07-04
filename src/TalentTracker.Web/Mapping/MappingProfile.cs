using TalentTracker.Shared.Application.Mapping;
namespace TalentTracker.Services.Person.API.Mapping;
public class MappingProfile : BaseMappingProfile
{
    public MappingProfile()
       : base(typeof(MappingProfile).Assembly)
    {
    }
}