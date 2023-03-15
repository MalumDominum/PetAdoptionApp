using Ardalis.Specification.EntityFrameworkCore;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Infrastructure.DataAccess;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
	where T : class, IAggregateRoot
{
	public EfRepository(AppDbContext dbContext) : base(dbContext) { }
}
