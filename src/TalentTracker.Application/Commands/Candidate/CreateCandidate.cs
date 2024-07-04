using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using TalentTracker.Application.Common.Repositories;
using TalentTracker.Domain.Aggregates.Candidates.ValueObjects;
using TalentTracker.Shared.Mappings;

namespace TalentTracker.Application.Commands.Candidate;

public static class CreateCandidate
{
    #region Command
    public record Command : IRequest<Response>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TimeIntervalToCall { get; set; }
        public string FreeTextComment { get; set; }
        public string LinkedinProfileUrl { get; set; }
        public string GithubProfileUrl { get; set; }
    }
    #endregion

    #region Validation
    public class CreateCandidateValidator : AbstractValidator<Command>
    {
        public CreateCandidateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required.").WithName(x => x.FirstName);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required.").WithName(x => x.LastName);

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required.").WithName(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.FreeTextComment)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required.").WithName(x => x.FreeTextComment);
        }
    }
    #endregion

    #region Handler
    public sealed class Handler : IRequestHandler<Command, Response>
    {
        readonly ILogger<Handler> _logger;
        readonly IMapper _mapper;
        readonly ICandidateRepository _candidateRepository;
        public Handler(ILogger<Handler> logger,
            IMapper mapper,
            ICandidateRepository candidateRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _candidateRepository=candidateRepository;
        }
        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                Domain.Aggregates.Candidates.Entities.Candidate candidate = new(request.FirstName, request.LastName,
                                                                                request.PhoneNumber, request.Email,
                                                                                request.TimeIntervalToCall, request.FreeTextComment);

                candidate.SetSocialMediaLinks(new SocialMediaLinks(request.LinkedinProfileUrl, request.GithubProfileUrl));

                var response = await _candidateRepository.CreateAsync(candidate, cancellationToken);

                await _candidateRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                return _mapper.Map<Response>(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@request}", request);
                throw;
            }
        }
    }
    #endregion


    #region Response
    public record Response() : IMapFrom<Domain.Aggregates.Candidates.Entities.Candidate>
    {
        public Guid CandidateGUID { get; init; }
        public string Email { get; init; }

        public void Mapping(Profile profile) => profile.CreateMap<Domain.Aggregates.Candidates.Entities.Candidate, Response>();
    }
    #endregion
}