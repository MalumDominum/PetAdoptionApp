using FluentValidation;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Create;

public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
{
	public CreatePetCommandValidator()
	{
		const int maxColors = 4;
		RuleFor(x => x.ColorIds).Must(x => x == null || x.Count <= maxColors)
			.WithMessage($"The pet must have no more than {maxColors} colors");

		RuleFor(x => x.BirthDate)
			.Must(x => x.IsValid())
				.WithMessage("This date is not valid")
			.Must(x => DateTime.Today.Year - x.Year < 50)
				.WithMessage("The age of the pet is too old")
			.Must(x => x.IsPast())
				.WithMessage("The date of birth cannot be later than today");
	}
}
