using Humanizer;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Events.Enumerations;

public class EventType : Enumeration, IAggregateRoot
{
    #region Tenant Event Types
    public static readonly EventType CandidateAdded = new EventType(1, nameof(CandidateAdded).Humanize().Titleize());
    public static readonly EventType CandidateUpdated = new EventType(2, nameof(CandidateUpdated).Humanize().Titleize());
    #endregion

    public EventType(int id, string name) : base(id, name)
    {
    }
}