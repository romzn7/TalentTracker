using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TalentTracker.Domain.Aggregates.Candidates.Entities;
using TalentTracker.Domain.Aggregates.Events.Entities;
using TalentTracker.Domain.Aggregates.Events.Enumerations;
using TalentTracker.Infrastructure.EntityConfigurations;
using TalentTracker.Shared.DomainDesign;
using TalentTracker.Shared.Helpers;

namespace TalentTracker.Infrastructure;

public class TalentTrackerDBContext : DbContextBase<TalentTrackerDBContext>
{
    public static string DEFAULT_SCHEMA => "tt";

    public TalentTrackerDBContext(DbContextOptions<TalentTrackerDBContext> options, ITimestampHelper currentDateTimeHelper, IMediator mediator, ILogger<TalentTrackerDBContext> logger
        ) :
        base(options, currentDateTimeHelper, mediator, logger)
    {
        System.Diagnostics.Debug.WriteLine("TalentTrackerDBContext::ctor ->" + this.GetHashCode());
    }

    public virtual DbSet<EventLog> EventLogs { get; set; } = null!;
    public virtual DbSet<EventType> EventTypes { get; set; } = null!;
    public virtual DbSet<Candidate> Candidates { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
           .ApplyConfiguration(new EventLogEntityConfiguration())
           .ApplyConfiguration(new EventTypeEntityConfiguration())
           .ApplyConfiguration(new CandidateEntityConfiguration())
           ;
    }
}
