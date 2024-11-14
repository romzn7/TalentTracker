using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Container.ValueObjects;

public class Quantity : ValueObject
{
    public decimal Value { get; private set; }
    public Quantity()
    {
        
    }

    public Quantity(decimal value)
    {
        Value = Guard.Against.NegativeOrZero(value);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}