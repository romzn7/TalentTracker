using Ardalis.GuardClauses;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Container.Entities;

public class WorkProcess : AuditableEntity, IAggregateRoot
{
    public Guid WorkProcessGuid { get; private set; }
    public int WorkProcessCount { get; private set; }


    // Navigation property for WorkProcessDetails & WorkProcessIngredients
    public List<WorkProcessDetail> WorkProcessDetails { get; private set; } = new List<WorkProcessDetail>();
    public List<WorkProcessIngredient> WorkProcessIngredients { get; private set; } = new List<WorkProcessIngredient>();

    public WorkProcess(Guid workProcessGuid, int workProcessCount)
    {
        WorkProcessGuid = Guid.NewGuid();
        WorkProcessCount = Guard.Against.NegativeOrZero(workProcessCount);
    }
}
