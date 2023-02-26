using Ardalis.Specification;

namespace PetAdoptionApp.SharedKernel.Interfaces;
public interface IReadRepository<T> : IReadRepositoryBase<T>
	where T : class, IAggregateRoot { }
