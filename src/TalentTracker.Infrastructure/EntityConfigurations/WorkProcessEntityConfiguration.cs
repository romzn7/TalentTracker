using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentTracker.Domain.Aggregates.Container.Entities;

namespace TalentTracker.Infrastructure.EntityConfigurations;

internal class WorkProcessEntityConfiguration : IEntityTypeConfiguration<WorkProcess>
{
    public void Configure(EntityTypeBuilder<WorkProcess> builder)
    {
        builder.ToTable(nameof(WorkProcess).Pluralize().Pascalize(), TalentTrackerDBContext.DEFAULT_SCHEMA);

        // Primary Key
        builder.HasKey(x => x.Id);

        // Properties
        builder.Property(x => x.WorkProcessGuid)
            .IsRequired();

        builder.Property(x => x.WorkProcessCount)
            .IsRequired();

        // One-to-Many relationship with WorkProcessDetail
        builder.HasMany(x => x.WorkProcessDetails)
               .WithOne(d => d.WorkProcess)
               .HasForeignKey(d => d.WorkProcessID)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.WorkProcessIngredients)
               .WithOne() 
               .HasForeignKey(wpi => wpi.WorkProcessID)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
