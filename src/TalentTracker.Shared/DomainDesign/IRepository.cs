namespace TalentTracker.Shared.DomainDesign;

public interface IRepository<T>
where T : IQueryableEntity
{
    IUnitOfWork UnitOfWork { get; }
}

public interface IReadOnlyRepository<T> where T : IQueryableEntity
{ }
