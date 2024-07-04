using Ardalis.GuardClauses;
using TalentTracker.Domain.Aggregates.Candidates.Events;
using TalentTracker.Domain.Aggregates.Candidates.ValueObjects;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Domain.Aggregates.Candidates.Entities;

public class Candidate : AuditableEntity, IAggregateRoot
{
    public Guid CandidateGUID { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string TimeIntervalToCall { get; private set; }
    public string FreeTextComment { get; private set; }

    public SocialMediaLinks SocialMediaLinks { get; set; }

    public Candidate(string firstName, string lastName, string phoneNumber, string email, string timeIntervalToCall, string freeTextComment)
    {
        FirstName = Guard.Against.NullOrEmpty(firstName);
        LastName = Guard.Against.NullOrEmpty(lastName);
        PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
        Email = Guard.Against.NullOrEmpty(email);
        TimeIntervalToCall = Guard.Against.NullOrEmpty(timeIntervalToCall);
        FreeTextComment = Guard.Against.NullOrEmpty(freeTextComment);

        _AddCandidateAddedEvent();
    }
    public void SetSocialMediaLinks(SocialMediaLinks socialMediaLinks) => SocialMediaLinks = Guard.Against.Null(socialMediaLinks);

    public void UpdateCandidate(string firstName, string lastName, string phoneNumber, string email, string timeIntervalToCall, string freeTextComment)
    {
        FirstName = Guard.Against.NullOrEmpty(firstName);
        LastName = Guard.Against.NullOrEmpty(lastName);
        PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
        Email = Guard.Against.NullOrEmpty(email);
        TimeIntervalToCall = Guard.Against.NullOrEmpty(timeIntervalToCall);
        FreeTextComment = Guard.Against.NullOrEmpty(freeTextComment);

        _AddCandidateUpdatedEvent();
    }
    #region Domain Events
    private void _AddCandidateAddedEvent()
        => AddDomainEvent(new CandidateAddedEvent(this.Id, this.CandidateGUID, this.Email, this.AddedBy));

    private void _AddCandidateUpdatedEvent()
        => AddDomainEvent(new CandidateUpdatedEvent(this.Id, this.CandidateGUID,  this.AddedBy));

    #endregion
}