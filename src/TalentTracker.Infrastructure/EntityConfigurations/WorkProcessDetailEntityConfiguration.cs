using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentTracker.Domain.Aggregates.Container.Entities;

namespace TalentTracker.Infrastructure.EntityConfigurations;

internal class WorkProcessDetailEntityConfiguration : IEntityTypeConfiguration<WorkProcessDetail>
{
    public void Configure(EntityTypeBuilder<WorkProcessDetail> builder)
    {
        builder.ToTable(nameof(WorkProcessDetail).Pluralize().Pascalize(), TalentTrackerDBContext.DEFAULT_SCHEMA);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.EndDate).IsRequired();
        builder.Property(x => x.TotalAlcohol).IsRequired();
        builder.Property(x => x.WaterChangeCount).IsRequired();
    }
}
