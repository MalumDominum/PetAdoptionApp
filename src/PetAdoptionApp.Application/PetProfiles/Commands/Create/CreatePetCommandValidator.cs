using FluentValidation;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Create;

public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
{
	public CreatePetCommandValidator()
	{
		//RuleFor(x => x.Email).NotNull();
	}
}
