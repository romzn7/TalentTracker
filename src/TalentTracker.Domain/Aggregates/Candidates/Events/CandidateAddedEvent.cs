using MediatR;

namespace TalentTracker.Domain.Aggregates.Candidates.Events;

public record CandidateAddedEvent(long CandidateId, Guid CandidateGuid, string Email, int UserId) : INotification { }