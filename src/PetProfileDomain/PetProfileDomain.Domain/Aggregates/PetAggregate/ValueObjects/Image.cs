using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetProfileDomain.Domain.Aggregates.PetAggregate.ValueObjects;

public class Image : ValueObject
{
	public byte[] Source { get; init; } = null!;

	public Image(byte[] source) => Source = source;
	public Image() { }

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Source;
	}
}
