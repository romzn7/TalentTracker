using Ardalis.GuardClauses;
using TalentTracker.Domain.Aggregates.Container.Enumerations;
using TalentTracker.Domain.Aggregates.Container.ValueObjects;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Container.Entities;

public class WorkProcessIngredient : AuditableEntity, IAggregateRoot
{
    public Guid WorkProcessIngredientGUID { get; private set; }
    public long WorkProcessID { get; private set; }
    public int IngredientID { get; private set; }
    public MeasurementUnit MeasurementUnit { get; private set; }

    //public MeasurementUnitType MeasurementUnitType { get; private set; }
    //public string MeasurementValue { get; private set; }
    public DateTime Date { get; private set; }
    public Quantity Quantity { get; private set; }

    // Navigation Properties
    public WorkProcess WorkProcess { get; private set; }
    public Ingredient Ingredient { get; private set; }

    public WorkProcessIngredient()
    {

    }

    // Constructor for setting properties
    public WorkProcessIngredient(int ingredientID, MeasurementUnit measurementUnit,
        //MeasurementUnitType measurementUnitType, string measurementValue, 
        DateTime date, Quantity quantity)
    {
        WorkProcessIngredientGUID = Guid.NewGuid();
        IngredientID = Guard.Against.NegativeOrZero(ingredientID);
        MeasurementUnit = Guard.Against.Default(measurementUnit);
        //MeasurementUnitType = Guard.Against.Default(measurementUnitType);
        //MeasurementValue = Guard.Against.NullOrEmpty(measurementValue);
        Date = Guard.Against.Default(date);
        Quantity = Guard.Against.Default(quantity);
    }
}