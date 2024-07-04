using Microsoft.Extensions.Logging;
using TalentTracker.Application.Common.Repositories;
using TalentTracker.Domain.Aggregates.Candidates.Entities;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Infrastructure.Repositories;

public class CandidateRepository : ICandidateRepository
{
    private readonly ILogger<CandidateRepository> _logger;
    private readonly TalentTrackerDBContext _dbContext;

    public CandidateRepository(ILogger<CandidateRepository> logger,
        TalentTrackerDBContext dbContext)
    {
        _logger = logger;
        _dbContext=dbContext;
    }
    public IUnitOfWork UnitOfWork => _dbContext;
    public async Task<Candidate> CreateAsync(Candidate candidate, CancellationToken cancellationToken)
    {
        try
        {
            if (candidate.IsTransient())
            {
                var taskEntity = await _dbContext
                                 .Candidates
                                 .AddAsync(candidate, cancellationToken);

                return taskEntity.Entity;
            }
            else return candidate;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{@candidate}", candidate);
            throw;
        }
    }
}