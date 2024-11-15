﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Container.Enumerations;

public class MeasurementUnitType : Enumeration, IAggregateRoot
{
    public static MeasurementUnitType Kg = new MeasurementUnitType(1, "Kg");
    public static MeasurementUnitType Dharni = new MeasurementUnitType(2, "Dharni");
    public MeasurementUnitType(int id, string name) : base(id, name)
    {
    }
}


public class MeasurementUnitTypeValueConverter : ValueConverter<MeasurementUnitType, string>
{
    public MeasurementUnitTypeValueConverter() : base(
        v => v.ToString(),
        v => (MeasurementUnitType)Enum.Parse(typeof(MeasurementUnitType), v))
    { }
}