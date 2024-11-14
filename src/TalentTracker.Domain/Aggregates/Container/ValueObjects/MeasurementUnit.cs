using Ardalis.GuardClauses;
using TalentTracker.Domain.Aggregates.Container.Enumerations;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Container.ValueObjects;

public class MeasurementUnit : ValueObject
{
    public MeasurementUnitType Type { get; private set; }
    public string Value { get; private set; }

    public MeasurementUnit()
    {

    }

    public MeasurementUnit(MeasurementUnitType measurementUnitType, string value)
    {
        Type = measurementUnitType;
        Value = Guard.Against.NullOrEmpty(value);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return Value;
    }
}