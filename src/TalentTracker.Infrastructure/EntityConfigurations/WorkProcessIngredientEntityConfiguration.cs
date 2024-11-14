using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalentTracker.Domain.Aggregates.Container.Entities;
using TalentTracker.Domain.Aggregates.Container.ValueObjects;

namespace TalentTracker.Infrastructure.EntityConfigurations;

internal class WorkProcessIngredientEntityConfiguration : IEntityTypeConfiguration<WorkProcessIngredient>
{
    public void Configure(EntityTypeBuilder<WorkProcessIngredient> builder)
    {
        builder.ToTable(nameof(WorkProcessIngredient).Pluralize().Pascalize(), TalentTrackerDBContext.DEFAULT_SCHEMA);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.WorkProcessIngredientGUID)
            .IsRequired();

        builder.Property(x => x.WorkProcessID)
            .IsRequired();

        builder.Property(x => x.IngredientID)
            .IsRequired();

        // Configure MeasurementUnit as an owned type (value object)
        builder.OwnsOne(x => x.MeasurementUnit, mu =>
        {
            mu.Property(p => p.Type)
               .IsRequired()
               .HasConversion<int>();

            mu.Property(p => p.Value)
               .IsRequired();
        });

        builder.Property(x => x.Date)
            .IsRequired();

        builder.OwnsOne(x => x.Quantity, q =>
        {
            q.Property(p => p.Value)
            .HasColumnName("Value")
            .IsRequired();
        });

        builder.HasOne(x => x.Ingredient)
            .WithMany()
            .HasForeignKey(x => x.IngredientID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(x => x.DomainEvents);
    }
}
