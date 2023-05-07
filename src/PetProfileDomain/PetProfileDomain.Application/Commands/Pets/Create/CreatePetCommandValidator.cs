using PetProfileDomain.Application.Commands.Pets.Common;

namespace PetProfileDomain.Application.Commands.Pets.Create;

public class CreatePetCommandValidator : CreateUpdatePetCommandValidator<CreatePetCommand>
{
	public CreatePetCommandValidator() { }
}
