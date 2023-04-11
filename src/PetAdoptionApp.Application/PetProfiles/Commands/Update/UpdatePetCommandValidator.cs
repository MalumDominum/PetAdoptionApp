using FluentValidation;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Update;

public class UpdatePetCommandValidator : AbstractValidator<UpdatePetCommand>
{
	public UpdatePetCommandValidator()
	{
		//RuleFor(x => x.Email).NotNull();
	}
}
