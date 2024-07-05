using AutoFixture;
using FluentAssertions;
using TalentTracker.Domain.Aggregates.Candidates.Entities;
using TalentTracker.Domain.Aggregates.Candidates.Events;
using TalentTracker.Domain.Aggregates.Candidates.ValueObjects;

namespace TalentTracker.Domain.Tests.UnitTests;

public class CandidateTests
{
    private readonly Fixture _fixture = new Fixture();
    private Candidate _Candidate;
    private Guid _guid;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _phoneNumber;
    private string _timeIntervalToCall;
    private string _freeTextComment;
    private string _linkedinProfileUrl;
    private string _githubProfileUrl;
    private SocialMediaLinks _SocialMediaLinks;

    [SetUp]
    public void Setup()
    {
        _guid = _fixture.Create<Guid>();
        _firstName = _fixture.Create<string>();
        _lastName = _fixture.Create<string>();
        _email = _fixture.Create<string>();
        _phoneNumber = _fixture.Create<string>();
        _timeIntervalToCall = _fixture.Create<string>();
        _freeTextComment = _fixture.Create<string>();
        _linkedinProfileUrl = _fixture.Create<string>();
        _githubProfileUrl = _fixture.Create<string>();

        _Candidate = _fixture.Create<Candidate>();
        _SocialMediaLinks = new(_linkedinProfileUrl, _githubProfileUrl);
    }

    private Candidate _CreateInstance() => new(_firstName, _lastName, _phoneNumber, _email, _timeIntervalToCall, _freeTextComment);

    [TestCase("")]
    [TestCase(null)]
    public void Initialize_FirstName_Should_Fail(string firstName)
    {
        _firstName = firstName;
        TestDelegate td = () => _CreateInstance();

        var assertion = firstName == null ? Assert.Throws<ArgumentNullException>(td)! :
            Assert.Throws<ArgumentException>(td)!;

        assertion.ParamName.Should().Be("firstName");
    }

    [TestCase("")]
    [TestCase(null)]
    public void Initialize_LastName_Should_Fail(string lastName)
    {
        _lastName = lastName;
        TestDelegate td = () => _CreateInstance();

        var assertion = lastName == null ? Assert.Throws<ArgumentNullException>(td)! :
            Assert.Throws<ArgumentException>(td)!;

        assertion.ParamName.Should().Be("lastName");
    }

    [TestCase("")]
    [TestCase(null)]
    public void Initialize_Email_Should_Fail(string email)
    {
        _email = email;
        TestDelegate td = () => _CreateInstance();

        var assertion = email == null ? Assert.Throws<ArgumentNullException>(td)! :
            Assert.Throws<ArgumentException>(td)!;

        assertion.ParamName.Should().Be("email");
    }

    [TestCase("")]
    [TestCase(null)]
    public void Initialize_FreeTextComment_Should_Fail(string freeTextComment)
    {
        _freeTextComment = freeTextComment;
        TestDelegate td = () => _CreateInstance();

        var assertion = freeTextComment == null ? Assert.Throws<ArgumentNullException>(td)! :
            Assert.Throws<ArgumentException>(td)!;

        assertion.ParamName.Should().Be("freeTextComment");
    }

    [Test]
    public void Init_Should_Succeed()
    {
        _Candidate = _CreateInstance();
        _Candidate.SetSocialMediaLinks(new SocialMediaLinks(_linkedinProfileUrl, _githubProfileUrl));

        _Candidate.FirstName.Should().Be(_firstName);
        _Candidate.LastName.Should().Be(_lastName);
        _Candidate.Email.Should().Be(_email);
        _Candidate.PhoneNumber.Should().Be(_phoneNumber);
        _Candidate.TimeIntervalToCall.Should().Be(_timeIntervalToCall);
        _Candidate.FreeTextComment.Should().Be(_freeTextComment);
        _Candidate.SocialMediaLinks.Should().Be(_SocialMediaLinks);

        _Candidate.DomainEvents.Should().NotBeNull();
        _Candidate.DomainEvents.Should().NotBeEmpty();
        _Candidate.DomainEvents.Should().Contain(d => d.GetType() == typeof(CandidateAddedEvent));
    }

    [TestCase("")]
    [TestCase(null)]
    public void UpdateCandidate_FirstName_should_fail(string firstName)
    {
        // Arrange
        _Candidate = _CreateInstance();
        _firstName= firstName;
        // Act
        // Assert
        TestDelegate sut = () => _Candidate.UpdateCandidate(_guid, _firstName, _lastName, _phoneNumber, _email, _timeIntervalToCall, _freeTextComment);
        var assertion = firstName == null ? Assert.Throws<ArgumentNullException>(sut)! :
              Assert.Throws<ArgumentException>(sut)!;

        assertion.ParamName.Should().Be("firstName");
    }

    [TestCase("")]
    [TestCase(null)]
    public void UpdateCandidate_LastName_should_fail(string lastName)
    {
        // Arrange
        _Candidate = _CreateInstance();
        _lastName= lastName;
        // Act
        // Assert
        TestDelegate sut = () => _Candidate.UpdateCandidate(_guid, _firstName, _lastName, _phoneNumber, _email, _timeIntervalToCall, _freeTextComment);
        var assertion = lastName == null ? Assert.Throws<ArgumentNullException>(sut)! :
              Assert.Throws<ArgumentException>(sut)!;

        assertion.ParamName.Should().Be("lastName");
    }

    [TestCase("")]
    [TestCase(null)]
    public void UpdateCandidate_Email_should_fail(string freeTextComment)
    {
        // Arrange
        _Candidate = _CreateInstance();
        _email= freeTextComment;
        // Act
        // Assert
        TestDelegate sut = () => _Candidate.UpdateCandidate(_guid, _firstName, _lastName, _phoneNumber, _email, _timeIntervalToCall, _freeTextComment);
        var assertion = freeTextComment == null ? Assert.Throws<ArgumentNullException>(sut)! :
              Assert.Throws<ArgumentException>(sut)!;

        assertion.ParamName.Should().Be("email");
    }

    [TestCase("")]
    [TestCase(null)]
    public void UpdateCandidate_FreeTextComment_should_fail(string freeTextComment)
    {
        // Arrange
        _Candidate = _CreateInstance();
        _freeTextComment= freeTextComment;
        // Act
        // Assert
        TestDelegate sut = () => _Candidate.UpdateCandidate(_guid, _firstName, _lastName, _phoneNumber, _email, _timeIntervalToCall, _freeTextComment);
        var assertion = freeTextComment == null ? Assert.Throws<ArgumentNullException>(sut)! :
              Assert.Throws<ArgumentException>(sut)!;

        assertion.ParamName.Should().Be("freeTextComment");
    }

    [Test]
    public void UpdateCandidate_Should_Succeed()
    {
        _Candidate = _CreateInstance();

        _Candidate.UpdateCandidate(_guid, _firstName, _lastName, _phoneNumber, _email, _timeIntervalToCall, _freeTextComment);
        _Candidate.SetSocialMediaLinks(new SocialMediaLinks(_linkedinProfileUrl, _githubProfileUrl));

        _Candidate.FirstName.Should().Be(_firstName);
        _Candidate.LastName.Should().Be(_lastName);
        _Candidate.Email.Should().Be(_email);
        _Candidate.PhoneNumber.Should().Be(_phoneNumber);
        _Candidate.TimeIntervalToCall.Should().Be(_timeIntervalToCall);
        _Candidate.FreeTextComment.Should().Be(_freeTextComment);
        _Candidate.SocialMediaLinks.Should().Be(_SocialMediaLinks);

        _Candidate.DomainEvents.Should().NotBeNull();
        _Candidate.DomainEvents.Should().NotBeEmpty();
        _Candidate.DomainEvents.Should().Contain(d => d.GetType() == typeof(CandidateUpdatedEvent));
    }
}
