using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Container.Enumerations;

public class Ingredient : Enumeration, IAggregateRoot
{
    public static Ingredient Shakhhar = new Ingredient(1, "Shakhhar");

    public Ingredient(int id, string name) : base(id, name)
    {
    }
}
