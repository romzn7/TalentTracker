using Ardalis.GuardClauses;
using TalentTracker.Domain.Aggregates.Container.Enumerations;
using TalentTracker.Domain.Aggregates.Container.ValueObjects;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Container.Entities;

public class WorkProcessIngredient : AuditableEntity, IAggregateRoot
{
    public Guid WorkProcessIngredientGUID { get; private set; }
    public int WorkProcessID { get; private set; }
    public int IngredientID { get; private set; }
    public MeasurementUnit MeasurementUnit { get; private set; }
    public DateTime Date { get; private set; }
    public Quantity Quantity { get; private set; }

    // Navigation Properties
    public WorkProcess WorkProcess { get; private set; }
    public Ingredient Ingredient { get; private set; }

    public WorkProcessIngredient()
    {
            
    }

    // Constructor for setting properties
    public WorkProcessIngredient(int ingredientID, MeasurementUnit measurementUnit, DateTime date, Quantity quantity)
    {
        WorkProcessIngredientGUID = Guid.NewGuid();
        IngredientID = Guard.Against.NegativeOrZero(ingredientID);
        MeasurementUnit = Guard.Against.Default(measurementUnit);
        Date = Guard.Against.Default(date);
        Quantity = Guard.Against.Default(quantity);
    }
}