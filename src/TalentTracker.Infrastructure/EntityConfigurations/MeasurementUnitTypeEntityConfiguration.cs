using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentTracker.Domain.Aggregates.Container.Enumerations;

namespace TalentTracker.Infrastructure.EntityConfigurations;

internal class MeasurementUnitTypeEntityConfiguration : IEntityTypeConfiguration<MeasurementUnitType>
{
    public void Configure(EntityTypeBuilder<MeasurementUnitType> builder)
    {
        builder.ToTable(nameof(MeasurementUnitType).Pluralize().Pascalize(), TalentTrackerDBContext.DEFAULT_SCHEMA);

        // Primary Key
        builder.HasKey(x => x.Id);

        builder.Property(ct => ct.Id)
            .HasDefaultValue(1)
            .ValueGeneratedNever()
            .HasConversion<int>()
            .IsRequired();

        // Properties
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
