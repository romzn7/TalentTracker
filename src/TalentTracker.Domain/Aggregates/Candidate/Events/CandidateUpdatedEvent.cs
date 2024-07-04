using MediatR;

namespace TalentTracker.Domain.Aggregates.Candidates.Events;

public record CandidateUpdatedEvent(long CandidateId, Guid CandidateGuid, int UserId) : INotification { }
