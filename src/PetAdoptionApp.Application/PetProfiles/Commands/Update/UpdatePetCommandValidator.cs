using FluentValidation;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Update;

public class UpdatePetCommandValidator : AbstractValidator<UpdatePetCommand>
{
	public UpdatePetCommandValidator()
	{
		const int maxColors = 4;
		RuleFor(x => x.ColorIds).Must(x => x == null || x.Count <= maxColors)
			.WithMessage($"The pet must have no more than {maxColors} colors");
	}
}
