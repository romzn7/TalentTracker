using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
