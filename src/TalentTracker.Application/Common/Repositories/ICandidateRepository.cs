using TalentTracker.Domain.Aggregates.Candidates.Entities;
using TalentTracker.Shared.DomainDesign;

namespace TalentTracker.Application.Common.Repositories;

public interface ICandidateRepository : IRepository<Candidate>
{
    Task<Candidate> CreateAsync(Candidate candidate, CancellationToken cancellationToken);
    Task<Candidate> UpdateAsync(Candidate candidate, CancellationToken cancellationToken);
}

public interface IReadOnlyCandidateRepository: IReadOnlyRepository<Candidate>
{
    Task<Candidate> IsExist(string email, CancellationToken cancellationToken);
}
