using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;

public class PetColor : IManyToManyLinker
{
	public Guid PetProfileId { get; set; }
	public PetProfile PetProfile { get; set; } = null!;

	public int ColorId { get; set; }
	public Color Color { get; set; } = null!;

	#region Constructors

	public PetColor(Guid petProfileId, int colorId)
	{
		PetProfileId = petProfileId;
		ColorId = colorId;
	}

	public PetColor() { }

	#endregion
}
