namespace PetAdoptionApp.SharedKernel.Interfaces.Services;

public interface IDateTimeProvider
{
	DateTime UtcNow { get; }
}