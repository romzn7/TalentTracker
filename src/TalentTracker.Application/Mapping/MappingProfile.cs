using TalentTracker.Shared.Application.Mapping;

namespace TalentTracker.Application.Mapping;

public class MappingProfile : BaseMappingProfile
{
    public MappingProfile()
       : base(typeof(MappingProfile).Assembly)
    {
    }
}
