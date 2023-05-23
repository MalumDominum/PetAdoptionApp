using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace CityProjectDomain.Domain.Aggregates.ProjectAggregate;

public class Project : EntityBase<Guid>, IAggregateRoot
{
	public string Title { get; set; } = null!;

	public string Link { get; set; } = null!;

	public string Description { get; set; } = null!;
	
	public string CityName { get; set; } = null!;

	public Guid PublisherId { get; set; }

	public DateTime StartOfVoting { get; set; }
	public DateTime EndOfVoting { get; set; }

	public DateTime CreatedAt { get; set; }
}
