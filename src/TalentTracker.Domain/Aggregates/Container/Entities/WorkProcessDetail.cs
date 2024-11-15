using Ardalis.GuardClauses;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Container.Entities;

public class WorkProcessDetail : AuditableEntity, IAggregateRoot
{
    public Guid WorkProcessDetailGuid { get; private set; }

    public long WorkProcessID { get; private set; }

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal TotalAlcohol { get; private set; }
    public int WaterChangeCount { get; private set; }

    // Navigation property to WorkProcess
    public WorkProcess WorkProcess { get; private set; }

    public WorkProcessDetail(DateTime startDate, DateTime endDate, decimal totalAlcohol, int waterChangeCount)
    {
        StartDate = Guard.Against.Default(startDate);
        EndDate = Guard.Against.Default(endDate);
        TotalAlcohol = Guard.Against.NegativeOrZero(totalAlcohol);
        WaterChangeCount = Guard.Against.NegativeOrZero(waterChangeCount);
    }
}
