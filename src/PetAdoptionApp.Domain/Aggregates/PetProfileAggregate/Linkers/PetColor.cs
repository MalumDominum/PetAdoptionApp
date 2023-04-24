using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Linkers;

public class PetColor : IManyToManyLinker, IEquatable<PetColor>
{
	public Guid PetProfileId { get; set; }
	public PetProfile PetProfile { get; set; } = null!;

	public int ColorId { get; init; }
	public Color Color { get; set; } = null!;

	#region Constructors

	public PetColor(int colorId) => ColorId = colorId;

	public PetColor() { }

	#endregion

	public override bool Equals(object? obj) => obj is PetColor color && Equals(color);

	public bool Equals(PetColor? other) => other != null && ColorId == other.ColorId;

	public override int GetHashCode() => ColorId.GetHashCode();
}
