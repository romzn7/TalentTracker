using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentTracker.Domain.Aggregates.Container.Enumerations;

namespace TalentTracker.Infrastructure.EntityConfigurations;

internal class IngredientEntityConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable(nameof(Ingredient).Pluralize().Pascalize(), TalentTrackerDBContext.DEFAULT_SCHEMA);

        builder.HasKey(x => x.Id);

        builder.Property(ct => ct.Id)
            .HasDefaultValue(1)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
