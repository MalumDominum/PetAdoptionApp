using PetAdoptionApp.SharedKernel.DddModelsDefinition;
using PetProfileDomain.Domain.Aggregates.ColorAggregate;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.Linkers;

public class PetColor : IManyToManyLinker, IEquatable<PetColor>
{
	public Guid PetId { get; set; }
	public Pet Pet { get; set; } = null!;

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
