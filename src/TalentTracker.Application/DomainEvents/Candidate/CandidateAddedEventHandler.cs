using MediatR;
using Microsoft.Extensions.Logging;
using TalentTracker.Application.Common.Repositories;
using TalentTracker.Domain.Aggregates.Candidates.Events;
using TalentTracker.Domain.Aggregates.Events.Entities;
using TalentTracker.Domain.Aggregates.Events.Enumerations;

namespace TalentTracker.Application.DomainEvents.Candidate;

internal class CandidateAddedEventHandler : INotificationHandler<CandidateAddedEvent>
{
    private readonly ILogger<CandidateAddedEventHandler> _logger;
    private readonly IEventLogRepository _eventLogRepository;

    public CandidateAddedEventHandler(ILoggerFactory logger,
        IEventLogRepository eventLogRepository)
    {
        _logger = logger.CreateLogger<CandidateAddedEventHandler>();
        _eventLogRepository = eventLogRepository;
    }

    public async Task Handle(CandidateAddedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogTrace($"Candidate with Id:{notification.CandidateId} has been created.");

        try
        {
            EventLog eventLog = new(Guid.NewGuid(), EventType.CandidateAdded, $"Created :  created the candidate {notification.Email}-{notification.CandidateGuid}.", notification.UserId);

            await _eventLogRepository.Add(eventLog, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{@notification}", notification);
            throw;
        }
    }
}