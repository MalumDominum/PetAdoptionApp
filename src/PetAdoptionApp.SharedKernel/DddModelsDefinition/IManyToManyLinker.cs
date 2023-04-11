namespace PetAdoptionApp.SharedKernel.DddModelsDefinition;

// Apply this marker interface to intermediate entity
// to use Repository, but not build Controller for it
public interface IManyToManyLinker : IAggregateRoot { }
