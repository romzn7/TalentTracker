using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TalentTracker.Application.Common.Repositories;
using TalentTracker.Domain.Aggregates.Events.Entities;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Infrastructure.Repositories;

public class EventLogRepository : IEventLogRepository
{
    private readonly ILogger<EventLogRepository> _logger;
    private readonly TalentTrackerDBContext _talentTrackerDBContext;
    public EventLogRepository(ILogger<EventLogRepository> logger,
         TalentTrackerDBContext talentTrackerDBContext)
    {
        _logger = logger;
        _talentTrackerDBContext = talentTrackerDBContext;
    }

    public IUnitOfWork UnitOfWork => _talentTrackerDBContext;

    public async Task<EventLog> Add(EventLog eventLog, CancellationToken cancellationToken)
    {
        try
        {
            if (eventLog.IsTransient())
            {
                var entityEntry = await _talentTrackerDBContext
                    .EventLogs
                    .AddAsync(eventLog);

                _talentTrackerDBContext.Entry(entityEntry.Entity.EventType).State = EntityState.Detached;

                return entityEntry.Entity;
            }
            else
                return eventLog;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{@eventLog}", eventLog);
            throw;
        }
    }
}
