using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentTracker.Domain.Aggregates.Container.Entities;

namespace TalentTracker.Infrastructure.EntityConfigurations;

internal class ContainerIngredientEntityConfiguration : IEntityTypeConfiguration<ContainerIngredient>
{
    public void Configure(EntityTypeBuilder<ContainerIngredient> builder)
    {
        builder.ToTable(nameof(ContainerIngredient).Pluralize().Pascalize(), TalentTrackerDBContext.DEFAULT_SCHEMA);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ContainerIngredientGUID)
            .IsRequired();

        builder.Property(x => x.ContainerID)
            .IsRequired();

        builder.Property(x => x.IngredientID)
            .IsRequired();

        builder.OwnsOne(x => x.MeasurementUnit, mu =>
        {
            mu.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(20); // Example length, based on your design

            mu.Property(m => m.UnitValue)
                .IsRequired();
        });

        builder.Property(x => x.Date)
            .IsRequired();

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.HasOne(x => x.Container)
            .WithMany(c => c.ContainerIngredients)
            .HasForeignKey(x => x.ContainerID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Ingredient)
            .WithMany()
            .HasForeignKey(x => x.IngredientID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(x => x.DomainEvents);
    }
}
