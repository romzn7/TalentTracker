using MediatR;
using Microsoft.Extensions.Logging;
using TalentTracker.Application.Common.Repositories;
using TalentTracker.Domain.Aggregates.Candidates.Events;
using TalentTracker.Domain.Aggregates.Events.Entities;
using TalentTracker.Domain.Aggregates.Events.Enumerations;

namespace TalentTracker.Application.DomainEvents.Candidate
{
     internal class CandidateUpdatedEventHandler : INotificationHandler<CandidateUpdatedEvent>
    {
        private readonly ILogger<CandidateUpdatedEventHandler> _logger;
        private readonly IEventLogRepository _eventLogRepository;

        public CandidateUpdatedEventHandler(ILoggerFactory logger,
            IEventLogRepository eventLogRepository)
        {
            _logger = logger.CreateLogger<CandidateUpdatedEventHandler>();
            _eventLogRepository = eventLogRepository;
        }

        public async Task Handle(CandidateUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogTrace($"Candidate with Id:{notification.CandidateId} has been updated.");

            try
            {
                EventLog eventLog = new(Guid.NewGuid(), EventType.CandidateUpdated, $"Updated : {notification.UserId} updated the candidate {notification.CandidateId}.", notification.UserId);

                await _eventLogRepository.Add(eventLog, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@notification}", notification);
                throw;
            }
        }
    }
}
