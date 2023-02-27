using Ardalis.Specification;

namespace PetAdoptionApp.SharedKernel.Interfaces;
// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T>
	where T : class, IAggregateRoot { }

// TODO: DISCOVER IF IT AND IREADREPOSITORY ENOUGH OR DELETE THEY
