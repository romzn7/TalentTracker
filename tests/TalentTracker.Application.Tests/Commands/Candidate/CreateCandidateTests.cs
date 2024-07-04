using AutoFixture;
using FluentAssertions;
using FluentValidation;
using Moq;
using TalentTracker.Application.Commands.Candidate;
using TalentTracker.Application.Common.Repositories;
using TalentTracker.Domain.Aggregates.Candidates.ValueObjects;
using TalentTracker.Shared.DomainDesign;
using TalentTracker.Shared.Tests;

namespace TalentTracker.Application.Tests.Commands.Candidate;

internal class CreateCandidateTests : HandlerTestBase<CreateCandidate.Handler, CreateCandidate.Command, CreateCandidate.Response>
{
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

    public override void SetupServices()
    {
        base.SetupServices();

        InjectMockedReadOnlyRepository<IReadOnlyCandidateRepository, Domain.Aggregates.Candidates.Entities.Candidate>();
        InjectMockedRepository<ICandidateRepository, Domain.Aggregates.Candidates.Entities.Candidate>();
        InjectMockedScoped<IUnitOfWork>();

        _firstName = Fixture.Create<string>();
        _lastName = Fixture.Create<string>();
        _email = _GenerateRandomEmailAddress();
        _phoneNumber = Fixture.Create<string>();
        _timeIntervalToCall = Fixture.Create<string>();
        _freeTextComment = Fixture.Create<string>();
        _linkedinProfileUrl = Fixture.Create<string>();
        _githubProfileUrl = Fixture.Create<string>();

        _SocialMediaLinks = Fixture.Create<SocialMediaLinks>();

        Mocker.GetMock<IReadOnlyCandidateRepository>()
             .Setup(x => x.IsExist(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Fixture.Create<Domain.Aggregates.Candidates.Entities.Candidate>());

        Mocker.GetMock<ICandidateRepository>()
            .Setup(x => x.CreateAsync(It.IsAny<Domain.Aggregates.Candidates.Entities.Candidate>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Fixture.Create<Domain.Aggregates.Candidates.Entities.Candidate>());

    }

    [TestCase(null)]
    [TestCase("")]
    public void Validation_Should_Fail_When_FirstName_Null_Or_Empty(string firstName)
    {
        //arrange
        CommandQuery = new CreateCandidate.Command
        {
            FirstName = firstName,
            LastName= _lastName,
            Email = _email,
            PhoneNumber = _phoneNumber,
            TimeIntervalToCall = _timeIntervalToCall,
            FreeTextComment=_freeTextComment,
            LinkedinProfileUrl = _linkedinProfileUrl,
            GithubProfileUrl = _githubProfileUrl
        };
        // Act
        AsyncTestDelegate sut = () => Mediator.Send(CommandQuery);
        var assertion = Assert.ThrowsAsync<ValidationException>(sut)!;
        assertion.Errors.Should().Contain(x => x.PropertyName == nameof(CommandQuery.FirstName));
    }

    [TestCase(null)]
    [TestCase("")]
    public void Validation_Should_Fail_When_LastName_Null_Or_Empty(string lastName)
    {
        //arrange
        CommandQuery = new CreateCandidate.Command
        {
            FirstName = _firstName,
            LastName= lastName,
            Email = _email,
            PhoneNumber = _phoneNumber,
            TimeIntervalToCall = _timeIntervalToCall,
            FreeTextComment=_freeTextComment,
            LinkedinProfileUrl = _linkedinProfileUrl,
            GithubProfileUrl = _githubProfileUrl
        };
        // Act
        AsyncTestDelegate sut = () => Mediator.Send(CommandQuery);
        var assertion = Assert.ThrowsAsync<ValidationException>(sut)!;
        assertion.Errors.Should().Contain(x => x.PropertyName == nameof(CommandQuery.LastName));
    }

    [TestCase(null)]
    [TestCase("")]
    public void Validation_Should_Fail_When_Email_Null_Or_Empty(string email)
    {
        //arrange
        CommandQuery = new CreateCandidate.Command
        {
            FirstName = _firstName,
            LastName= _lastName,
            Email = email,
            PhoneNumber = _phoneNumber,
            TimeIntervalToCall = _timeIntervalToCall,
            FreeTextComment=_freeTextComment,
            LinkedinProfileUrl = _linkedinProfileUrl,
            GithubProfileUrl = _githubProfileUrl
        };
        // Act
        AsyncTestDelegate sut = () => Mediator.Send(CommandQuery);
        var assertion = Assert.ThrowsAsync<ValidationException>(sut)!;
        assertion.Errors.Should().Contain(x => x.PropertyName == nameof(CommandQuery.Email));
    }

    [TestCase(null)]
    [TestCase("")]
    public void Validation_Should_Fail_When_FreeTextComment_Null_Or_Empty(string freeTextComment)
    {
        //arrange
        CommandQuery = new CreateCandidate.Command
        {
            FirstName = _firstName,
            LastName= _lastName,
            Email = _email,
            PhoneNumber = _phoneNumber,
            TimeIntervalToCall = _timeIntervalToCall,
            FreeTextComment=freeTextComment,
            LinkedinProfileUrl = _linkedinProfileUrl,
            GithubProfileUrl = _githubProfileUrl
        };
        // Act
        AsyncTestDelegate sut = () => Mediator.Send(CommandQuery);
        var assertion = Assert.ThrowsAsync<ValidationException>(sut)!;
        assertion.Errors.Should().Contain(x => x.PropertyName == nameof(CommandQuery.FreeTextComment));
    }

    [Test]
    public async Task handler_should_succeed()
    {
        CommandQuery = new CreateCandidate.Command
        {
            FirstName = _firstName,
            LastName= _lastName,
            Email = _email,
            PhoneNumber = _phoneNumber,
            TimeIntervalToCall = _timeIntervalToCall,
            FreeTextComment=_freeTextComment,
            LinkedinProfileUrl = _linkedinProfileUrl,
            GithubProfileUrl = _githubProfileUrl
        };

        var response = await Mediator.Send(CommandQuery, new CancellationToken());
        response.Should().NotBeNull();

        Mocker.GetMock<IReadOnlyCandidateRepository>()
          .Verify(x => x.IsExist(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);

        Mocker.GetMock<ICandidateRepository>()
            .Verify(x => x.CreateAsync(It.IsAny<Domain.Aggregates.Candidates.Entities.Candidate>(), It.IsAny<CancellationToken>()), Times.Once);

        Mocker.GetMock<ICandidateRepository>()
            .Verify(x => x.UnitOfWork.SaveEntitiesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    private string _GenerateRandomEmailAddress()
    {
        var randomString = Path.GetRandomFileName().Replace(".", "");
        var email = $"{randomString}@example.com";
        return email;
    }
}
