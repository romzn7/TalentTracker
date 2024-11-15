using Ardalis.GuardClauses;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Container.Entities;

public class Container : AuditableEntity, IAggregateRoot
{
    public Container()
    {

    }
    public Guid ContainerGUID { get; private set; }
    public string Name { get; private set; }
    public List<WorkProcess> WorkProcesses { get; private set; } = new();

    public Container(string name)
    {
        this.Name = Guard.Against.NullOrEmpty(name);
    }

    public void UpdateContainer(Guid guid, string name)
    {
        this.ContainerGUID=Guard.Against.Default(guid);
        this.Name=Guard.Against.NullOrEmpty(name);
    }
}
