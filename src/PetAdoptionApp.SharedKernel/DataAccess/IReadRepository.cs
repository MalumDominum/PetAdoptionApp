using Ardalis.Specification;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.SharedKernel.DataAccess;

public interface IReadRepository<T> : IReadRepositoryBase<T>
	where T : class, IAggregateRoot { }
