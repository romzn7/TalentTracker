using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentTracker.Domain.Aggregates.Events.Enumerations;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Events.Entities;

public class EventLog : AuditableEntity, IAggregateRoot
{
    protected EventLog() { }
    public EventLog(Guid eventLogGUID, EventType eventType, string description, int userId)
    {
        Guard.Against.Default(eventLogGUID);
        Guard.Against.Null(eventType);
        Guard.Against.NegativeOrZero(userId);
        Guard.Against.NullOrEmpty(description);

        EventLogGUID = eventLogGUID;
        EventType = eventType;
        AddedBy = userId;
        Description = description;
        IsActive = true;
        AddedOn = DateTime.UtcNow;
    }

    public Guid EventLogGUID { get; private init; }
    public EventType EventType { get; private init; }
    public string Description { get; private init; }
    public bool IsActive { get; private init; }
}
