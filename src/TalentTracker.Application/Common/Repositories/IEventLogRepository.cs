using TalentTracker.Domain.Aggregates.Events.Entities;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Application.Common.Repositories;

public interface IEventLogRepository : IRepository<EventLog>
{
    Task<EventLog> Add(EventLog eventLog, CancellationToken cancellationToken);
}