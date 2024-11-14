using Ardalis.GuardClauses;
using TalentTracker.Domain.Aggregates.Container.Enumerations;
using TalentTracker.Domain.Aggregates.Container.ValueObjects;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Container.Entities;

public class ContainerIngredient : AuditableEntity, IAggregateRoot
{
    public Guid ContainerIngredientGUID { get; private set; }
    public int ContainerID { get; private set; }
    public int IngredientID { get; private set; }
    public MeasurementUnit MeasurementUnit { get; private set; }
    public DateTime Date { get; private set; }
    public Quantity Quantity { get; private set; }

    // Navigation Properties
    public Container Container { get; private set; }
    public Ingredient Ingredient { get; private set; }

    // Constructor for setting properties
    public ContainerIngredient(int ingredientID, MeasurementUnit measurementUnit,
                            DateTime date, Quantity quantity)
    {
        ContainerIngredientGUID = Guid.NewGuid();
        IngredientID = Guard.Against.NegativeOrZero(ingredientID);
        MeasurementUnit = Guard.Against.Default(measurementUnit);
        Date = Guard.Against.Default(date);
        Quantity = Guard.Against.Default(quantity);
    }
}