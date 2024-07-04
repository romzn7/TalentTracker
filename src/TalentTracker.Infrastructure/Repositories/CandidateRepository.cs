using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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

    public async Task<Candidate> UpdateAsync(Candidate candidate, CancellationToken cancellationToken)
    {
        try
        {
            if (!candidate.IsTransient())
            {

                return _dbContext
                .Candidates
                .Update(candidate)
                .Entity;
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

public class ReadOnlyCandidateRepository : IReadOnlyCandidateRepository
{
    private readonly ILogger<ReadOnlyCandidateRepository> _logger;
    private readonly TalentTrackerDBContext _dbContext;
    public ReadOnlyCandidateRepository(ILogger<ReadOnlyCandidateRepository> logger,
        TalentTrackerDBContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<Candidate> IsExist(string email, CancellationToken cancellationToken)
    {
        try
        {
            return await _dbContext
                         .Candidates
                         .FirstOrDefaultAsync(x => x.Email.Equals(email), cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{@email}", email);
            throw;
        }
    }


}