using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;
using TalentTracker.Domain.Aggregates.Candidates.Entities;

namespace TalentTracker.Infrastructure.EntityConfigurations;

internal class CandidateEntityConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.ToTable(nameof(Candidate).Humanize().Pluralize().Pascalize(), TalentTrackerDBContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.Property(o => o.Id)
             .UseHiLo("candidateseq", TalentTrackerDBContext.DEFAULT_SCHEMA);
        builder.Ignore(x => x.DomainEvents);

        builder.Property(x => x.CandidateGUID)
            .IsRequired(true);

        builder.Property(x => x.FirstName)
            .IsRequired(true);

        builder.Property(x => x.LastName)
            .IsRequired(true);

        builder.Property(x => x.Email)
            .IsRequired(true);

        builder.Property(x => x.PhoneNumber)
            .IsRequired(false);

        builder.Property(x => x.TimeIntervalToCall)
            .IsRequired(false);

        builder.Property(x => x.FreeTextComment)
            .IsRequired(true);

        builder.OwnsOne(x => x.SocialMediaLinks, sa =>
        {
            sa.Property(x => x.LinkedinProfileUrl).IsRequired(false);
            sa.Property(x => x.GithubProfileUrl).IsRequired(false);
        });
    }
}
