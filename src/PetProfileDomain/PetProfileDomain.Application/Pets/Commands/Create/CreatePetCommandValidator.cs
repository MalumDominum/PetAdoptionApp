using PetProfileDomain.Application.Pets.Commands.Common;

namespace PetProfileDomain.Application.Pets.Commands.Create;

public class CreatePetCommandValidator : CreateUpdatePetCommandValidator<CreatePetCommand>
{
	public CreatePetCommandValidator() { }
}
