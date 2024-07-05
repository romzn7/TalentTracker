namespace TalentTracker.Domain.Aggregates.Candidates.ValueObjects;

using Ardalis.GuardClauses;
using System.Collections.Generic;
using TalentTracker.Shared.DomainDesign;

public class SocialMediaLinks : ValueObject
{
    public string LinkedinProfileUrl { get; private set; }
    public string GithubProfileUrl { get; private set; }

    public SocialMediaLinks() { }

    public SocialMediaLinks(string linkedinProfileUrl, string githubProfileUrl)
    {
        LinkedinProfileUrl= linkedinProfileUrl;
        GithubProfileUrl= githubProfileUrl;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return LinkedinProfileUrl;
        yield return GithubProfileUrl;
    }

}
