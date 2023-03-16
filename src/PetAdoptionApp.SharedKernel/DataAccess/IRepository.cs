using Ardalis.Specification;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.SharedKernel.DataAccess;

public interface IRepository<T> : IRepositoryBase<T>
	where T : EntityBase, IAggregateRoot { }
