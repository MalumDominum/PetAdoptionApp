using FluentValidation;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Create;

public class CreatePetCommandValidator : AbstractValidator<PetProfileCommand>
{
	public CreatePetCommandValidator()
	{
		//RuleFor(x => x.Email).NotNull();
	}
}
