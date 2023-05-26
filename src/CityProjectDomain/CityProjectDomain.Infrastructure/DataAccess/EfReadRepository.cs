using Ardalis.Specification.EntityFrameworkCore;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace CityProjectDomain.Infrastructure.DataAccess;

public class EfReadRepository<T> : RepositoryBase<T>, IReadRepository<T>
	where T : class, IAggregateRoot
{
	public EfReadRepository(AppDbContext dbContext) : base(dbContext) { }
}
