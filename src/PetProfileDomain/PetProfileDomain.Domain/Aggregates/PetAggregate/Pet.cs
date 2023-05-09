using PetAdoptionApp.SharedKernel.DddModelsDefinition;
using PetProfileDomain.Domain.Aggregates.ColorAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Linkers;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Nesting;
using PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;
using PetProfileDomain.Domain.Aggregates.SizeAggregate;
using PetProfileDomain.Domain.Aggregates.SpeciesAggregate;
using PetProfileDomain.Domain.Aggregates.StateAggregate;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate;

public class Pet : EntityBase<Guid>, IAggregateRoot
{
	public string Name { get; set; } = null!;

	public Gender Gender { get; set; } = null!;

	#region PartialPossibleDate BirthDate

	private PartialPossibleDate _birthDate = null!;
	public PartialPossibleDate BirthDate
	{
		get => _birthDate;
		set
		{
			BackfieldBirthDate = (DateOnly)value;
			_birthDate = value;
		}
	}
	public DateOnly BackfieldBirthDate { private set; get; }  // Property for filtering that is not available to the user

	#endregion

	public int SpeciesId { get; set; }
	public Species? Species { get; set; }

	public List<PetColor>? PetColors { get; set; }

	private readonly List<Color>? _colors;
	public IReadOnlyCollection<Color>? Colors => _colors?.AsReadOnly();

	public int? SizeId { get; set; }
	public Size? Size { get; set; }

	public PetDetails? Details { get; set; }

	public string Description { get; set; } = null!;
	
	//public Address Address { get; set; } = null!;

	public List<State>? States { get; set; } = null!;

	//private readonly List<string>? _photoAndVideoUrls;
	//public ReadOnlyCollection<string>? PhotoAndVideoUrls => _photoAndVideoUrls?.AsReadOnly();

	//public User Owner { get; set; }
	
	public DateTime CreatedAt { get; set; }
	public DateTime? EditedAt { get; set; }
	public DateTime? NewStatesAddedAt { get; set; } // Hidden property for ordering

	#region Constructors

	public Pet(List<Color>? colors) //, List<string>? photoAndVideoUrls)
	{
		_colors = colors;
		//_photoAndVideoUrls = photoAndVideoUrls;
	}
	
	public Pet() { }

	#endregion
}
