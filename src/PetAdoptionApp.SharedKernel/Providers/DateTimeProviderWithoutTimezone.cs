namespace PetAdoptionApp.SharedKernel.Providers;

public class DateTimeProviderWithoutTimezone : IDateTimeProvider
{
	public DateTime UtcNow => DateTime.UtcNow;
}
