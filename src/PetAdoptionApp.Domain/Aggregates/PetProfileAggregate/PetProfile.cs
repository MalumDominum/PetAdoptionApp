using System.Collections.ObjectModel;
using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.Domain.Aggregates.HeightAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Nesting;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.ValueObjects;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;

public class PetProfile : EntityBase<Guid>, IAggregateRoot
{
	public string Name { get; set; } = null!;

	public Gender Gender { get; set; } = null!;

	//public DatePartially BirthDate { get; set; } = null!;

	//public int SpeciesId { get; set; }
	//public Species Species { get; set; } = null!;

	public List<int>? ColorIds;
	private readonly List<Color>? _colors;
	public IReadOnlyCollection<Color>? Colors => _colors?.AsReadOnly();

	//public Height Height { get; set; } = null!;

	//public PetProfileDetails? Details { get; set; }

	public string Description { get; set; } = null!;
	
	//public Address Address { get; set; } = null!;

	//public States States { get; set; } = null!;

	//private readonly List<string>? _photoAndVideoUrls;
	//public ReadOnlyCollection<string>? PhotoAndVideoUrls => _photoAndVideoUrls?.AsReadOnly();

	//public User Owner { get; set; }

	public DateTime StatusChangedAt { get; set; } // Hidden property for ordering

	public DateTime CreatedAt { get; set; }
	
	public DateTime? EditedAt { get; set; }

	#region Constructors

	public PetProfile(List<string>? photoAndVideoUrls, List<Color>? colors)
	{
		_colors = colors;
		//_photoAndVideoUrls = photoAndVideoUrls;
	}
	
	public PetProfile() { }

	#endregion
}
