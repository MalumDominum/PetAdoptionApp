namespace PetAdoptionApp.SharedKernel.Providers;

public interface IDateTimeProvider
{
	DateTime UtcNow { get; }
}
